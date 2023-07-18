using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_UpdateEndpoint : IEndpoint<IResult, Shop_Cliente_UpdateRequest, IRepository<Shop_Cliente>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("api/shop-clientes",
                async (Shop_Cliente_UpdateRequest request, IRepository<Shop_Cliente> clienteRepository) =>
                {
                    return await HandleAsync(request, clienteRepository);
                })
                .Produces<Shop_Cliente_UpdateResponse>()
                .WithTags("Shop_Cliente_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Cliente_UpdateRequest request, IRepository<Shop_Cliente> clienteRepository)
        {
            var response = new Shop_Cliente_UpdateResponse(request.CorrelationId());

            var existingItem = await clienteRepository.GetByIdAsync(request.Shop_Cliente_Id);
            if(existingItem == null)
            {
                return Results.NotFound();
            }

            Shop_Cliente.Shop_Cliente_Details details = new(request.Ruc, request.Shop_Cliente_NombreComercial, request.Shop_Cliente_Nombre1, request.Shop_Cliente_Nombre2,
                request.Shop_Cliente_Apellido1, request.Shop_Cliente_Apellido2, request.Shop_Cliente_Direccion1, request.Shop_Cliente_Direccion2, request.Shop_Cliente_Telefono1,
                request.Shop_Cliente_Telefono2, request.Shop_Cliente_Telefono3, request.Shop_Cliente_Email, request.Shop_Cliente_Estrellas, request.Shop_Cliente_CupoCredito, request.Shop_Cliente_PlazoCredito);

            existingItem.UpdateDetails(details);

            await clienteRepository.UpdateAsync(existingItem);

            var dto = new Shop_Cliente_Dto
            {
                Id = request.Shop_Cliente_Id,
                Ruc = request.Ruc,
                NombreComercial = request.Shop_Cliente_NombreComercial,
                Nombre1 = request.Shop_Cliente_Nombre1,
                Nombre2 = request.Shop_Cliente_Nombre2,
                Apellido1 = request.Shop_Cliente_Apellido1,
                Apellido2 = request.Shop_Cliente_Apellido2,
                Direccion1 = request.Shop_Cliente_Direccion1,
                Direccion2 = request.Shop_Cliente_Direccion2,
                Telefono1 = request.Shop_Cliente_Telefono1,
                Telefono2 = request.Shop_Cliente_Telefono2,
                Telefono3 = request.Shop_Cliente_Telefono3,
                Email = request.Shop_Cliente_Email,
                Estrellas = request.Shop_Cliente_Estrellas,
                CupoCredito = request.Shop_Cliente_CupoCredito,
                PlazoCredito = request.Shop_Cliente_PlazoCredito
            };

            response.Shop_Cliente = dto;
            return Results.Ok(response);
        }
    }
}
