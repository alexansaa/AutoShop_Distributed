using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_ListPagedEndpoint : IEndpoint<IResult, Shop_Auto_ListPagedRequest, IRepository<Shop_Auto>>
    {
        private readonly IMapper _mapper;

        public Shop_Auto_ListPagedEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop-autos",
                async (int? pageSize, int? pageIndex, string? marca, string? modelo, string? tipo, int? year, double? cilindraje, IRepository<Shop_Auto> autoRepository) =>
                {
                    return await HandleAsync(new Shop_Auto_ListPagedRequest(pageSize, pageIndex, marca, modelo, tipo, year, cilindraje), autoRepository);
                })
                .Produces<Shop_Auto_ListPagedResponse>()
                .WithTags("Shop_Auto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Auto_ListPagedRequest request, IRepository<Shop_Auto> autoRepository)
        {
            await Task.Delay(1000);
            var response = new Shop_Auto_ListPagedResponse(request.CorrelationId());

            var filterSpec = new Shop_Auto_FilterSpecification(request.Marca, request.Modelo, request.Tipo, request.Year, request.Cilindraje);
            int totalAutos = await autoRepository.CountAsync(filterSpec);

            var pagedSpec = new Shop_Auto_FilterPaginatedSpecification(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                marca: request.Marca,
                modelo: request.Modelo,
                tipo: request.Tipo,
                year: request.Year,
                cilindraje:  request.Cilindraje);

            var autos = await autoRepository.ListAsync(pagedSpec);

            response.Shop_Autos.AddRange(autos.Select(_mapper.Map<Shop_Auto_Dto>));

            foreach(Shop_Auto_Dto item in response.Shop_Autos)
            {
                //Aqui podemos componer la uri de una imagen para el item
                //item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);
            }

            if(request.PageSize > 0)
            {
                response.PageCount = int.Parse(Math.Ceiling((decimal)totalAutos / request.PageSize).ToString());
            }
            else
            {
                response.PageCount = totalAutos > 0 ? 1 : 0;
            }

            return Results.Ok(response);
        }
    }
}
