using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_UpdateEndpoint : IEndpoint<IResult, Shop_Auto_UpdateRequest, IRepository<Shop_Auto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("api/shop-autos",
                async (Shop_Auto_UpdateRequest request, IRepository<Shop_Auto> autoRepository) =>
                {
                    return await HandleAsync(request, autoRepository);
                })
                .Produces<Shop_Auto_UpdateResponse>()
                .WithTags("Shop_Auto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Auto_UpdateRequest request, IRepository<Shop_Auto> autoRepository)
        {
            var response = new Shop_Auto_UpdateResponse(request.CorrelationId());

            var existingItem = await autoRepository.GetByIdAsync(request.Shop_AutoId);
            if(existingItem == null)
            {
                return Results.NotFound();
            }

            Shop_Auto.Shop_Auto_Details details = new(request.Shop_Auto_Marca, request.Shop_Auto_Modelo, request.Shop_Auto_Tipo, request.Shop_Auto_Year, request.Shop_Auto_Cilidraje);
            existingItem.UpdateDetails(details);

            await autoRepository.UpdateAsync(existingItem);

            var dto = new Shop_Auto_Dto
            {
                Id = existingItem.Id,
                Marca = existingItem.Marca,
                Modelo = existingItem.Modelo,
                Tipo = existingItem.Tipo,
                Year = existingItem.Year,
                Cilindraje = existingItem.Cilindraje
            };
            response.Shop_Auto = dto;
            return Results.Ok(response);

        }
    }
}
