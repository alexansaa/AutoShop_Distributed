namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_DeleteResponse : BaseResponse
    {
        public string Status { get; set; } = "Deleted";

        public Shop_Cliente_DeleteResponse(Guid correlationId) : base(correlationId)
        {

        }
    }
}
