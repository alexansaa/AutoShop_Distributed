namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_DeleteResponse : BaseResponse
    {
        public string Status { get; set; } = "Deleted";
        public Shop_ClieAuto_DeleteResponse(Guid correlationId) : base(correlationId) { }
    }
}
