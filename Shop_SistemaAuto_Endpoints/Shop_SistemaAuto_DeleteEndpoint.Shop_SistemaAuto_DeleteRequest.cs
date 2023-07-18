namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_DeleteRequest : BaseRequest
    {
        public long Shop_SistemaAuto_Id { get; set; }
        public Shop_SistemaAuto_DeleteRequest(long Shop_SistemaAuto_Id)
        {
            this.Shop_SistemaAuto_Id = Shop_SistemaAuto_Id;
        }
    }
}
