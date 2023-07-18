using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_DeleteEndpoint : IEndpoint<IResult, Shop_Cliente_DeleteRequest, IRepository<Shop_Cliente>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/shop-clientes/{shopClienteId}",
                async (long Shop_Cliente_Id, IRepository<Shop_Cliente> clienteRepository) =>
                {
                    return await HandleAsync(new Shop_Cliente_DeleteRequest(Shop_Cliente_Id), clienteRepository);
                })
                .Produces<Shop_Cliente_DeleteResponse>()
                .WithTags("Shop_Cliente_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Cliente_DeleteRequest request, IRepository<Shop_Cliente> clienteRepository)
        {
            var response = new Shop_Cliente_DeleteResponse(request.CorrelationId());

            var clienteToDelete = await clienteRepository.GetByIdAsync(request.Shop_Cliente_Id);
            if(clienteToDelete is null)
            {
                return Results.NotFound();
            }
            await clienteRepository.DeleteAsync(clienteToDelete);
            return Results.Ok(response);
        }
    }
}
