namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_CreateResponse : BaseResponse
    {
        public Shop_AutoSistema_Dto Shop_AutoSistema { get; set; }
        public Shop_AutoSistema_CreateResponse() { }
        public Shop_AutoSistema_CreateResponse(Guid correlationId) : base(correlationId) { }
    }
}
