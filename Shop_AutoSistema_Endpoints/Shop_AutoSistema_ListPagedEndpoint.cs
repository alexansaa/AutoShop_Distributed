using ApplicationCore.Entites;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using MinimalApi.Endpoint;

namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_ListPagedEndpoint : IEndpoint<IResult, Shop_AutoSistema_ListPagedRequest, IRepository<Shop_AutoSistema>>
    {
        public readonly IMapper _mapper;
        public Shop_AutoSistema_ListPagedEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/shop-autoSistema",
                async (int? pageSize, int? pageIndex, long? shop_AutoId, long? shop_SistemaId, IRepository<Shop_AutoSistema> autoSistemaRequest) =>
                {
                    return await HandleAsync(new Shop_AutoSistema_ListPagedRequest(pageSize, pageIndex, shop_AutoId, shop_SistemaId), autoSistemaRequest);
                })
                .Produces<Shop_AutoSistema_ListPagedResponse>()
                .WithTags("Shop_AutoSistema_Endpoints");
        }

        public async Task<IResult> HandleAsync(Shop_AutoSistema_ListPagedRequest request, IRepository<Shop_AutoSistema> autoSistemaRepository)
        {
            await Task.Delay(1000);
            var response = new Shop_AutoSistema_ListPagedResponse(request.CorrelationId());

            var filterSpec = new Shop_AutoSistema_FilterSpecification(request.Shop_AutoId, request.Shop_SistemaId);
            long totalAutoSistemas = await autoSistemaRepository.CountAsync(filterSpec);

            var pagedSpec = new Shop_AutoSistema_FilterPaginatedSpecification(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                Shop_SistemaId: request.Shop_SistemaId,
                Shop_AutoId: request.Shop_AutoId);

            var autoSistemas = await autoSistemaRepository.ListAsync(pagedSpec);

            response.Shop_AutoSistemas.AddRange(autoSistemas.Select(_mapper.Map<Shop_AutoSistema_Dto>));

            foreach(Shop_AutoSistema_Dto item in response.Shop_AutoSistemas)
            {
                //Aqui podemos componer la uri de una imagen para el item
                //item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);
            }
            if(request.PageSize > 0)
            {
                response.PageCount = int.Parse(Math.Ceiling((decimal)totalAutoSistemas / request.PageSize).ToString());
            }
            else
            {
                response.PageCount = totalAutoSistemas > 0 ? 1 : 0;
            }

            return Results.Ok(response);


        }
    }
}
