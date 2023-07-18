using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using ApplicationCore.Entites;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_GetByIdEndpoint : IEndpoint<IResult, Shop_ClieAuto_GetByIdRequest, IRepository<Shop_ClieAuto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop-clieAutos/{shopClieAutoId}",
                async (long shopClieAutoId, IRepository<Shop_ClieAuto> clieAutoRepository) =>
                {
                    return await HandleAsync(new Shop_ClieAuto_GetByIdRequest(shopClieAutoId), clieAutoRepository);
                })
                .Produces<Shop_ClieAuto_GetByIdResponse>()
                .WithTags("Shop_ClieAuto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_ClieAuto_GetByIdRequest request, IRepository<Shop_ClieAuto> clieAutoRepository)
        {
            var response = new Shop_ClieAuto_GetByIdResponse(request.CorrelationId());

            var clieAuto = await clieAutoRepository.GetByIdAsync(request.Shop_ClieAuto_Id);
            if(clieAuto == null)
            {
                return Results.NotFound();
            }
            response.Shop_ClieAuto = new Shop_ClieAuto_Dto
            {
                Id = clieAuto.Id,
                Shop_ClienteId = clieAuto.Shop_ClienteId,
                Shop_AutoId = clieAuto.Shop_AutoId,
                Color = clieAuto.Color,
                Kilometraje = clieAuto.Kilometraje,
                Motor_Numeracion = clieAuto.Motor_Numeracion,
                Chasis_Numeracion = clieAuto.Chasis_Numeracion,
                Uso = clieAuto.Uso,
                Observacion = clieAuto.Observacion
            };
            return Results.Ok(response);
        }
    }
}
