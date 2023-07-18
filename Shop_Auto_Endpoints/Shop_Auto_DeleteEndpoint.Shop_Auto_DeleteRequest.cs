namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_DeleteRequest : BaseRequest
    {
        public long Shop_AutoId { get; init; }
        public Shop_Auto_DeleteRequest(long Shop_AutoId) 
        {
            this.Shop_AutoId = Shop_AutoId;
        }
    }
}
