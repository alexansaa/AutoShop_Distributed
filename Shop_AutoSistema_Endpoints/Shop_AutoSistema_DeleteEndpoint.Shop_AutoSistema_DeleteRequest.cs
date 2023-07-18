namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_DeleteRequest : BaseRequest
    {
        public long Shop_AutoSistema_Id { get; set; }
        public Shop_AutoSistema_DeleteRequest(long shop_AutoSistema_Id)
        {
            Shop_AutoSistema_Id = shop_AutoSistema_Id;
        }
    }
}
