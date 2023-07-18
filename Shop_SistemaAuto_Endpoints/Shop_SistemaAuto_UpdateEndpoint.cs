using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_UpdateEndpoint : IEndpoint<IResult, Shop_SistemaAuto_UpdateRequest, IRepository<Shop_SistemasAutomotrices>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("api/shop-sistemasAutomotrices/",
                async (Shop_SistemaAuto_UpdateRequest request, IRepository<Shop_SistemasAutomotrices> sistemasAutoRepository) =>
                {
                    return await HandleAsync(request, sistemasAutoRepository);
                })
                .Produces<Shop_SistemaAuto_UpdateResponse>()
                .WithTags("Shop_SistemaAutomotriz_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_SistemaAuto_UpdateRequest request, IRepository<Shop_SistemasAutomotrices> sistemaAutoRepository)
        {
            var response = new Shop_SistemaAuto_UpdateResponse(request.CorrelationId());

            var existingItem = await sistemaAutoRepository.GetByIdAsync(request.Id);

            if (existingItem == null)
            {
                return Results.NotFound();
            }

            Shop_SistemasAutomotrices.Shop_SistemasAutomotrices_Details details = new (request.Name, request.Descripcion, request.Descripcion);

            existingItem.UpdateDetails(details);

            await sistemaAutoRepository.UpdateAsync(existingItem);

            var dto = new Shop_SistemaAuto_Dto
            {
                Id = request.Id,
                Name = request.Name,
                Descripcion = request.Descripcion,
                Detalle = request.Detalle
            };

            response.Shop_SistemaAuto = dto;
            return Results.Ok(response);

        }
    }
}
