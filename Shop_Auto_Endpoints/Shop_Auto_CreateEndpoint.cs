using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using ApplicationCore.Specifications;
using ApplicationCore.Exceptions;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_CreateEndpoint : IEndpoint<IResult, Shop_Auto_CreateRequest, IRepository<Shop_Auto>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/shop-autos",
                async (Shop_Auto_CreateRequest request, IRepository<Shop_Auto> autoRepository) =>
                {
                    return await HandleAsync(request, autoRepository);
                })
                .Produces<Shop_Auto_CreateResponse>()
                .WithTags("Shop_Auto_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_Auto_CreateRequest request, IRepository<Shop_Auto> autoRepository)
        {
            var response = new Shop_Auto_CreateResponse(request.CorrelationId());

            var shop_Auto_Specification = new Shop_Auto_Specification(request.Shop_Auto_Marca, request.Shop_Auto_Modelo, request.Shop_Auto_Tipo, request.Shop_Auto_Year, request.Shop_Auto_Cilindraje);
            var existingShopAuto = await autoRepository.CountAsync(shop_Auto_Specification);
            if(existingShopAuto > 0)
            {
                throw new DuplicateException($"Un Auto con los atributos {request.Shop_Auto_Marca}, {request.Shop_Auto_Modelo}, {request.Shop_Auto_Tipo}, {request.Shop_Auto_Year} y {request.Shop_Auto_Cilindraje} ya existe!");
            }

            var newAuto = new Shop_Auto(request.Shop_Auto_Marca, request.Shop_Auto_Modelo, request.Shop_Auto_Year, request.Shop_Auto_Tipo, request.Shop_Auto_Cilindraje);
            newAuto = await autoRepository.AddAsync(newAuto);

            if(newAuto.Id != 0)
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

            var dto = new Shop_Auto_Dto
            {
                Id = newAuto.Id,
                Marca = newAuto.Marca,
                Modelo = newAuto.Modelo,
                Tipo = newAuto.Tipo,
                Year = newAuto.Year,
                Cilindraje = newAuto.Cilindraje
            };
            response.Shop_Auto = dto;
            return Results.Created($"api/shop-autos/{dto.Id}", response);
        }
    }
}
