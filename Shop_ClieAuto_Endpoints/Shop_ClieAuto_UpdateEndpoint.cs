using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_UpdateEndpoint : IEndpoint<IResult, Shop_ClieAuto_UpdateRequest, IRepository<Shop_ClieAuto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("api/shop-clieAutos/{shopClieAutoId}",
                async (Shop_ClieAuto_UpdateRequest request, IRepository<Shop_ClieAuto> clieAutoRepository) =>
                {
                    return await HandleAsync(request, clieAutoRepository);
                })
                .Produces<Shop_ClieAuto_UpdateResponse>()
                .WithTags("Shop_ClieAuto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_ClieAuto_UpdateRequest request, IRepository<Shop_ClieAuto> clieAutoRepository)
        {
            var response = new Shop_ClieAuto_UpdateResponse(request.CorrelationId());

            var existingItem = await clieAutoRepository.GetByIdAsync(request.Id);

            if (existingItem == null)
            {
                return Results.NotFound();
            }

            Shop_ClieAuto.Shop_ClieAuto_Details details = new(request.Shop_ClienteId, request.Shop_AutoId, request.Color, request.Kilometraje, request.Motor_Numeracion, request.Chasis_Numeracion, request.Uso, request.Observacion);
            existingItem.UpdateDetails(details);

            await clieAutoRepository.UpdateAsync(existingItem);

            var dto = new Shop_ClieAuto_Dto
            {
                Id = request.Id,
                Shop_ClienteId = request.Shop_ClienteId,
                Shop_AutoId = request.Shop_AutoId,
                Color = request.Color,
                Kilometraje = request.Kilometraje,
                Motor_Numeracion = request.Motor_Numeracion,
                Chasis_Numeracion = request.Chasis_Numeracion,
                Uso = request.Uso,
                Observacion = request.Observacion
            };

            response.Shop_ClieAuto = dto;
            return Results.Ok(response);
        }
    }
}
