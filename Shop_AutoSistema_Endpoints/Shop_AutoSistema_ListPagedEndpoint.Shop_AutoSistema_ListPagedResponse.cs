using ApplicationCore.Entites;

namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_ListPagedResponse : BaseResponse
    {
        public int PageCount { get; set; }
        public List<Shop_AutoSistema_Dto> Shop_AutoSistemas { get; set; } = new List<Shop_AutoSistema_Dto>();
        public Shop_AutoSistema_ListPagedResponse()
        {

        }
        public Shop_AutoSistema_ListPagedResponse(Guid correlationId) : base(correlationId)
        {

        }
    }
}
