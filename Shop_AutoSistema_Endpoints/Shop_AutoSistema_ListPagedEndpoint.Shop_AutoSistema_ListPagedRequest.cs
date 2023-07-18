namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_ListPagedRequest : BaseRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long? Shop_AutoId { get; set; }
        public long? Shop_SistemaId { get; set;}
        public Shop_AutoSistema_ListPagedRequest(int? PageSize, int? PageIndex, long? Shop_AutoId, long? Shop_SistemaId)
        {
            this.PageSize = PageSize ?? 0;
            this.PageIndex = PageIndex ?? 0;
            this.Shop_AutoId = Shop_AutoId;
            this.Shop_SistemaId = Shop_SistemaId;
        }
    }
}
