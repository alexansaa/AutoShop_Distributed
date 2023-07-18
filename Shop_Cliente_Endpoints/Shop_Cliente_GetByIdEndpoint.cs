using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_GetByIdEndpoint : IEndpoint<IResult, Shop_Cliente_GetByIdRequest, IRepository<Shop_Cliente>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop-clientes/{shopClienteId}",
                async (long clienteShopId, IRepository<Shop_Cliente> clienteRepository) =>
                {
                    return await HandleAsync(new Shop_Cliente_GetByIdRequest(clienteShopId), clienteRepository);
                })
                .Produces<Shop_Cliente_GetByIdResponse>()
                .WithTags("Shop_Cliente_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Cliente_GetByIdRequest request, IRepository<Shop_Cliente> clienteRepository)
        {
            var response = new Shop_Cliente_GetByIdResponse(request.CorrelationId());

            var cliente = await clienteRepository.GetByIdAsync(request.Shop_Cliente_Id);
            if(cliente is null)
            {
                return Results.NotFound();
            }
            response.Shop_Cliente = new Shop_Cliente_Dto
            {
                Id = cliente.Id,
                Ruc = cliente.Ruc,
                NombreComercial = cliente.NombreComercial,
                Nombre1 = cliente.Nombre1,
                Nombre2 = cliente.Nombre2,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                Direccion1 = cliente.Direccion1,
                Direccion2 = cliente.Direccion2,
                Telefono1 = cliente.Telefono1,
                Telefono2 = cliente.Telefono2,
                Telefono3 = cliente.Telefono3,
                Email = cliente.Email,
                Fecha_Registro = cliente.Fecha_Registro,
                Estrellas = cliente.Estrellas,
                CupoCredito = cliente.CupoCredito,
                PlazoCredito = cliente.PlazoCredito
            };
            return Results.Ok(response);
        }
    }
}
