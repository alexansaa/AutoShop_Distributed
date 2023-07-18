using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using ApplicationCore.Specifications;
using ApplicationCore.Exceptions;

namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_CreateEndpoint : IEndpoint<IResult, Shop_AutoSistema_CreateRequest, IRepository<Shop_AutoSistema>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/shop-autoSistema",
                async (Shop_AutoSistema_CreateRequest request, IRepository<Shop_AutoSistema> autoSistemaRepository) =>
                {
                    return await HandleAsync(request, autoSistemaRepository);
                })
                .Produces<Shop_AutoSistema_CreateResponse>()
                .WithTags("Shop_AutoSistema_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_AutoSistema_CreateRequest request, IRepository<Shop_AutoSistema> autoSistemaRepository)
        {
            var response = new Shop_AutoSistema_CreateResponse(request.CorrelationId());

            var shop_autoSistema_specification = new Shop_AutoSistema_Specification(request.Shop_AutoId, request.Shop_SistemaId);

            var existingAutoSistema = await autoSistemaRepository.CountAsync(shop_autoSistema_specification);

            if(existingAutoSistema > 0)
            {
                throw new DuplicateException($"Un par Auto Sistema con los atributos {request.Shop_AutoId}, {request.Shop_SistemaId} ya existe!");
            }

            var newAutoSistema = new Shop_AutoSistema(request.Shop_AutoId, request.Shop_SistemaId);
            newAutoSistema = await autoSistemaRepository.AddAsync(newAutoSistema);

            if(newAutoSistema.Id != 0)
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

            var dto = new Shop_AutoSistema_Dto
            {
                Id = newAutoSistema.Id,
                Shop_AutoId = newAutoSistema.Shop_AutoId,
                Shop_SistemaId = newAutoSistema.Shop_SistemaId
            };
            response.Shop_AutoSistema = dto;
            return Results.Ok(response);

        }
    }
}
