using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_DeleteEndpoint : IEndpoint<IResult, Shop_AutoSistema_DeleteRequest, IRepository<Shop_AutoSistema>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/shop-autoSistema/{shopAutoSistemaId}",
                async (long shop_AutoSistema_Id, IRepository<Shop_AutoSistema> autoSistemaRepository) =>
                {
                    return await HandleAsync(new Shop_AutoSistema_DeleteRequest(shop_AutoSistema_Id), autoSistemaRepository);
                })
                .Produces<Shop_AutoSistema_DeleteResponse>()
                .WithTags("Shop_AutoSistema_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_AutoSistema_DeleteRequest request, IRepository<Shop_AutoSistema> autoSistemaRepository)
        {
            var response = new Shop_AutoSistema_DeleteResponse(request.CorrelationId());

            var itemToDelte = await autoSistemaRepository.GetByIdAsync(request.Shop_AutoSistema_Id);

            if (itemToDelte is null)
            {
                return Results.NotFound();
            }

            await autoSistemaRepository.DeleteAsync(itemToDelte);
            return Results.Ok(response);
        }
    }
}
