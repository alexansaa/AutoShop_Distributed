namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_DeleteRequest : BaseRequest
    {
        public long Shop_Cliente_Id { get; init; }
        public Shop_Cliente_DeleteRequest(long Shop_Cliente_Id)
        {
            this.Shop_Cliente_Id = Shop_Cliente_Id;
        }
    }
}
