using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using MinimalApi.Endpoint;
using ApplicationCore.Exceptions;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_CreateEndpoint : IEndpoint<IResult, Shop_ClieAuto_CreateRequest, IRepository<Shop_ClieAuto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/shop-clieAutos",
                async (Shop_ClieAuto_CreateRequest request, IRepository<Shop_ClieAuto> clieAutoRepository) =>
                {
                    return await HandleAsync(request, clieAutoRepository);
                })
                .Produces<Shop_ClieAuto_CreateResponse>()
                .WithTags("Shop_ClieAuto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_ClieAuto_CreateRequest request, IRepository<Shop_ClieAuto> clieautoRepository)
        {
            var response = new Shop_ClieAuto_CreateResponse(request.CorrelationId());

            var shop_clieAuto_specification = new Shop_ClieAuto_Specification(request.Motor_Numeracion, request.Chasis_Numeracion);

            var existingShopClieAuto = await clieautoRepository.CountAsync(shop_clieAuto_specification);

            if(existingShopClieAuto > 0)
            {
                throw new DuplicateException($"Un auto con los atributos {request.Motor_Numeracion}, {request.Chasis_Numeracion} ya existe!");
            }

            var newClieAuto = new Shop_ClieAuto(request.Shop_ClienteId, request.Shop_AutoId, request.Color, request.Kilometraje, request.Motor_Numeracion, request.Chasis_Numeracion, request.Uso, request.Observacion);

            newClieAuto = await clieautoRepository.AddAsync(newClieAuto);

            if(newClieAuto.Id != 0)
            {
                //Aqui podemos implementar la opcion de subir una foto para el nuevo auto implementado
                //ver el proyecto e-shopOnWeb de microsoft
                //existe un tema de seguridad que se debe observar:
                //We disabled the upload functionality and added a default/placeholder image to this sample due to a potential security risk 
                //  pointed out by the community. More info in this issue: https://github.com/dotnet-architecture/eShopOnWeb/issues/537 
                //  In production, we recommend uploading to a blob storage and deliver the image via CDN after a verification process.
                //ejemplo:
                //newItem.UpdatePictureUri("eCatalog-item-default.png");
                //await itemRepository.UpdateAsync(newItem);
            }

            var dto = new Shop_ClieAuto_Dto
            {
                Id = newClieAuto.Id,
                Shop_ClienteId = newClieAuto.Id,
                Shop_AutoId = newClieAuto.Id,
                Color = newClieAuto.Color,
                Kilometraje = newClieAuto.Kilometraje,
                Motor_Numeracion = newClieAuto.Motor_Numeracion,
                Chasis_Numeracion = newClieAuto.Chasis_Numeracion,
                Uso = newClieAuto.Uso,
                Observacion = newClieAuto.Observacion
            };
            response.Shop_ClieAuto = dto;
            return Results.Created($"api/shop-clieAuto/{dto.Id}", response);
        }
    }
}
