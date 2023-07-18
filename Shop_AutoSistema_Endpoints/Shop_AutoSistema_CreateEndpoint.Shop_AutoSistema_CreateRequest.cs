namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_CreateRequest : BaseRequest
    {
        public long Shop_AutoId { get; set; }
        public long Shop_SistemaId { get; set; }
    }
}
