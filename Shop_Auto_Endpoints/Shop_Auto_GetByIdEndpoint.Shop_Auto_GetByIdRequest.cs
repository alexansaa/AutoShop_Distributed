namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_GetByIdRequest : BaseRequest
    {
        public long Shop_Auto_Id { get; set; }
        public Shop_Auto_GetByIdRequest(long Shop_Auto_Id)
        {
            this.Shop_Auto_Id = Shop_Auto_Id;
        }
    }
}
