using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_GetByIdEndpoint : IEndpoint<IResult, Shop_Auto_GetByIdRequest, IRepository<Shop_Auto>>
    {
        void IEndpoint.AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop-autos/{shopAutoId}",
                async (long shopAutoId, IRepository<Shop_Auto> autoRepository) =>
                {
                    return await HandleAsync(new Shop_Auto_GetByIdRequest(shopAutoId), autoRepository);
                })
                .Produces<Shop_Auto_GetByIdRequest>()
                .WithTags("Shop_Auto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Auto_GetByIdRequest request, IRepository<Shop_Auto> autoRepository)
        {
            var response = new Shop_Auto_GetByIdResponse(request.CorrelationId());

            var item = await autoRepository.GetByIdAsync(request.Shop_Auto_Id);
            if(item is null)
            {
                return Results.NotFound();
            }
            response.Shop_Auto = new Shop_Auto_Dto
            {
                Id = item.Id,
                Marca = item.Marca,
                Modelo = item.Modelo,
                Year = item.Year,
                Tipo = item.Tipo,
                Cilindraje = item.Cilindraje
            };
            return Results.Ok(response);

        }
    }
}
