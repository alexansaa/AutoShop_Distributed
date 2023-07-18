using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_DeleteEndpoint : IEndpoint<IResult, Shop_SistemaAuto_DeleteRequest, IRepository<Shop_SistemasAutomotrices>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/shop-sistemasAutomotrices/{shopSistemaAutoId}",
                async (long shopSistemaAutoId, IRepository<Shop_SistemasAutomotrices> clieAutoRepository) =>
                {
                    return await HandleAsync(new Shop_SistemaAuto_DeleteRequest(shopSistemaAutoId), clieAutoRepository);
                })
                .Produces<Shop_SistemaAuto_DeleteResponse>()
                .WithTags("Shop_SistemaAutomotriz_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_SistemaAuto_DeleteRequest request, IRepository<Shop_SistemasAutomotrices> clieAutoRepository)
        {
            var response = new Shop_SistemaAuto_DeleteResponse(request.CorrelationId());

            var clientToDelete = await clieAutoRepository.GetByIdAsync(request.Shop_SistemaAuto_Id);

            if (clientToDelete == null)
            {
                return Results.NotFound();
            }

            await clieAutoRepository.DeleteAsync(clientToDelete);
            return Results.Ok(response);
        }
    }
}
