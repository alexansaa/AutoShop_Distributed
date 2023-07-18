using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Server.HttpSys;
using MinimalApi.Endpoint;
using ApplicationCore.Specifications;
using ApplicationCore.Exceptions;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_CreateEndpoint : IEndpoint<IResult, Shop_Cliente_CreateRequest, IRepository<Shop_Cliente>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/shop-clientes",
                async (Shop_Cliente_CreateRequest request, IRepository<Shop_Cliente> clienteRepository) =>
                {
                    return await HandleAsync(request, clienteRepository);
                })
                .Produces<Shop_Cliente_CreateResponse>()
                .WithTags("Shop_Cliente_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Cliente_CreateRequest request, IRepository<Shop_Cliente> clienreRepository)
        {
            var response = new Shop_Cliente_CreateResponse(request.CorrelationId());

            var shop_cliente_specification = new Shop_Cliente_Specification(request.Ruc, request.NombreComercial, request.Nombre1, request.Nombre2,
                request.Apellido1, request.Apellido2, request.Direccion1, request.Direccion2, request.Telefono1, request.Telefono2, request.Telefono3,
                request.Email, request.Fecha_Registro, request.Estrellas, request.CupoCredito, request.PlazoCredito);

            var exisitingShopCliente = await clienreRepository.CountAsync(shop_cliente_specification);

            if(exisitingShopCliente > 0)
            {
                throw new DuplicateException($"Un Cliente con los atributos {request.Ruc}, {request.NombreComercial}, etc. ya existe!");
            }

            var newcliente = new Shop_Cliente(request.Ruc, request.NombreComercial, request.Nombre1, request.Nombre2, request.Apellido1, request.Apellido2,
                request.Direccion1, request.Direccion2, request.Telefono1, request.Email, request.CupoCredito, request.PlazoCredito, request.Telefono2, request.Telefono3, request.Estrellas);

            newcliente = await clienreRepository.AddAsync(newcliente);

            if(newcliente.Id != 0)
            {
                //Aqui podemos implementar la opcion de subir una foto para el nuevo auto implementado
                //ver el proyecto e-shopOnWeb de microsoft
                //existe un tema de seguridad que se debe observar:
                //We disabled the upload functionality and added a default/placeholder image to this sample due to a potential security risk 
                //  pointed out by the community. More info in this issue: https://github.com/dotnet-architecture/eShopOnWeb/issues/537 
                //  In production, we recommend uploading to a blob storage and deliver the image via CDN after a verification process.
                //ejemplo:
                //newItem.UpdatePictureUri("eCatalog-item-default.png");
                //await itemRepository.UpdateAsync(newItem);
            }

            var dto = new Shop_Cliente_Dto
            {
                Id = newcliente.Id,
                Ruc = request.Ruc,
                NombreComercial = request.NombreComercial,
                Nombre1 = request.Nombre1,
                Nombre2 = request.Nombre2,
                Apellido1 = request.Apellido1,
                Apellido2 = request.Apellido2,
                Direccion1 = request.Direccion1,
                Direccion2 = request.Direccion2,
                Telefono1 = request.Telefono1,
                Telefono2 = request.Telefono2,
                Telefono3 = request.Telefono3,
                Email = request.Email,
                Fecha_Registro = request.Fecha_Registro,
                Estrellas = request.Estrellas,
                CupoCredito = request.CupoCredito,
                PlazoCredito = request.PlazoCredito
            };
            response.Shop_cliente = dto;
            return Results.Ok(response);
        }
    }
}
