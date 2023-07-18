using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_DeleteEndpoint : IEndpoint<IResult, Shop_Auto_DeleteRequest, IRepository<Shop_Auto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/shop-autos/{shopAutoId}",
                async (long shopAutoId, IRepository<Shop_Auto> autoRepository) =>
                {
                    return await HandleAsync(new Shop_Auto_DeleteRequest(shopAutoId), autoRepository);
                })
                .Produces<Shop_Auto_DeleteResponse>()
                .WithTags("Shop_Auto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Auto_DeleteRequest request, IRepository<Shop_Auto> autoRepository)
        {
            var response = new Shop_Auto_DeleteResponse(request.CorrelationId());

            var autoToDelete = await autoRepository.GetByIdAsync(request.Shop_AutoId);
            if(autoToDelete is null) 
            {
                return Results.NotFound();
            }

            await autoRepository.DeleteAsync(autoToDelete);

            return Results.Ok(response);
        }
    }
}
