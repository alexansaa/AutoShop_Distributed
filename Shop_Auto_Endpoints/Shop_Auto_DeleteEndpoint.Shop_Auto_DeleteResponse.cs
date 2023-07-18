namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_DeleteResponse : BaseResponse
    {
        public Shop_Auto_DeleteResponse(Guid correlationId) : base(correlationId)
        {

        }

        public Shop_Auto_DeleteResponse()
        {

        }

        public string Status { get; set; } = "Deleted";
    }
}
