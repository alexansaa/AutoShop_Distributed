using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.Specification;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MinimalApi.Endpoint;
using SagaMotors_API.Shop_Auto_Endpoints;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_ListPagedEndpoint : IEndpoint<IResult, Shop_Cliente_ListPagedRequest, IRepository<Shop_Cliente>>
    {
        private readonly IMapper _mapper;
        public Shop_Cliente_ListPagedEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop_clientes",
                async (int? PageSize, int? PageIndex, string? Ruc, string? NombreComercial, string? Nombre1, string? Nombre2, string? Apellido1, string? Apellido2, int? Estrellas, IRepository<Shop_Cliente> clienteRepository) =>
                {
                    return await HandleAsync(new Shop_Cliente_ListPagedRequest(PageSize, PageIndex, Ruc, NombreComercial, Nombre1, Nombre2, Apellido1, Apellido2, Estrellas), clienteRepository);
                })
                .Produces<Shop_Cliente_ListPagedResponse>()
                .WithTags("Shop_Cliente_Endpoints");
    }

        public async Task<IResult> HandleAsync(Shop_Cliente_ListPagedRequest request, IRepository<Shop_Cliente> clienteRepository)
        {
            await Task.Delay(1000);
            var response = new Shop_Cliente_ListPagedResponse(request.CorrelationId());

            var filterSpec = new Shop_Cliente_FilterSpecification(request.Ruc, request.NombreComercial, request.Nombre1, request.Nombre2, request.Apellido1, request.Apellido2, request.Estrellas);
            int totalClientes = await clienteRepository.CountAsync(filterSpec);

            var pagedSpec = new Shop_Cliente_FilterPaginatedSpecification(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                Ruc: request.Ruc,
                NombreComercial: request.NombreComercial,
                Nombre1: request.Nombre1,
                Nombre2: request.Nombre2,
                Apellido1: request.Apellido1,
                Apellido2: request.Apellido2,
                Estrellas: request.Estrellas);

            var clientes = await clienteRepository.ListAsync(pagedSpec);

            response.Shop_Clientes.AddRange(clientes.Select(_mapper.Map<Shop_Cliente_Dto>));

            foreach(Shop_Cliente_Dto item in response.Shop_Clientes)
            {
                //Aqui podemos componer la uri de una imagen para el item
                //item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);
            }

            if(request.PageSize > 0)
            {
                response.PageCount = int.Parse(Math.Ceiling((decimal)totalClientes / request.PageSize).ToString());
            }
            else
            {
                response.PageCount = totalClientes > 0 ? 1 : 0;
            }

            return Results.Ok(response);
        }
    }
}
