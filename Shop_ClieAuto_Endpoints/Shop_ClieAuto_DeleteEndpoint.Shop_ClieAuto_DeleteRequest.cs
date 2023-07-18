namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_DeleteRequest : BaseRequest
    {
        public long Shop_ClieAuto_Id { get; set; }
        public Shop_ClieAuto_DeleteRequest()
        {

        }
        public Shop_ClieAuto_DeleteRequest(long shop_ClieAuto_Id)
        {
            Shop_ClieAuto_Id = shop_ClieAuto_Id;
        }
    }
}
