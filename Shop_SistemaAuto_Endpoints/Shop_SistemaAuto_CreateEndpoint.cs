using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using ApplicationCore.Specifications;
using ApplicationCore.Exceptions;

namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_CreateEndpoint : IEndpoint<IResult, Shop_SistemaAuto_CreateRequest, IRepository<Shop_SistemasAutomotrices>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/shop-sistemasAutomotrices",
                async (Shop_SistemaAuto_CreateRequest request, IRepository<Shop_SistemasAutomotrices> sisAutomotrizRepository) =>
                {
                    return await HandleAsync(request, sisAutomotrizRepository);
                })
                .Produces<Shop_SistemaAuto_CreateResponse>()
                .WithTags("Shop_SistemaAutomotriz_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_SistemaAuto_CreateRequest request, IRepository<Shop_SistemasAutomotrices> sisAutomotrizRepository)
        {
            var response = new Shop_SistemaAuto_CreateResponse(request.CorrelationId());

            var shop_sistemaAuto_specification = new Shop_SistemaAuto_Specification(request.Name, request.Descripcion, request.Detalle); ;

            var existingShopSistemaAuto = await sisAutomotrizRepository.CountAsync(shop_sistemaAuto_specification);

            if(existingShopSistemaAuto > 0)
            {
                throw new DuplicateException($"Un sistema automotriz con los atributos {request.Name}, {request.Detalle}, {request.Descripcion} ya existe!");
            }

            var newsistemaAuto = new Shop_SistemasAutomotrices(request.Name, request.Descripcion, request.Detalle);

            newsistemaAuto = await sisAutomotrizRepository.AddAsync(newsistemaAuto);

            if(newsistemaAuto.Id != 0)
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

            var dto = new Shop_SistemaAuto_Dto
            {
                Id = newsistemaAuto.Id,
                Name = newsistemaAuto.Name,
                Descripcion = newsistemaAuto.Descripcion,
                Detalle = newsistemaAuto.Detalle
            };

            response.Shop_SistemaAuto = dto;
            return Results.Ok(response);
        }
    }
}
