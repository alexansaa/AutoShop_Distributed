namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_GetByIdRequest : BaseRequest
    {
        public long Shop_Cliente_Id { get; set; }
        public Shop_Cliente_GetByIdRequest(long shop_Cliente_Id)
        {
            Shop_Cliente_Id = shop_Cliente_Id;
        }
    }
}
