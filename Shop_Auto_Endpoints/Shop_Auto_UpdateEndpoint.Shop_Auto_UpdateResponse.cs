namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_UpdateResponse : BaseResponse
    {
        public Shop_Auto_UpdateResponse(Guid correlationId) : base (correlationId)
        {

        }

        public Shop_Auto_UpdateResponse() { }

        public Shop_Auto_Dto Shop_Auto { get; set; }
    }
}
