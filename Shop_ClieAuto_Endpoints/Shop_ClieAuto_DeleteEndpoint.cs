using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_DeleteEndpoint : IEndpoint<IResult, Shop_ClieAuto_DeleteRequest, IRepository<Shop_ClieAuto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/shop-clieAutos/{shopClieAutoId}",
                async (long shopClieAutoId, IRepository<Shop_ClieAuto> clieAutoRepository) =>
                {
                    return await HandleAsync(new Shop_ClieAuto_DeleteRequest(shopClieAutoId), clieAutoRepository);
                })
                .Produces<Shop_ClieAuto_DeleteResponse>()
                .WithTags("Shop_ClieAuto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_ClieAuto_DeleteRequest request, IRepository<Shop_ClieAuto> clieAutoRepository)
        {
            var response = new Shop_ClieAuto_DeleteResponse(request.CorrelationId());

            var clieAutoToDelete = await clieAutoRepository.GetByIdAsync(request.Shop_ClieAuto_Id);

            if(clieAutoToDelete == null)
            {
                return Results.NotFound();
            }
            await clieAutoRepository.DeleteAsync(clieAutoToDelete);
            return Results.Ok(response);
        }
    }
}
