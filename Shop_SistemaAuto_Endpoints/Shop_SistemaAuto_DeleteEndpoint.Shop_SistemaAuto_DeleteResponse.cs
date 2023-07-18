namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_DeleteResponse : BaseResponse
    {
        public string Status { get; set; } = "Deleted";
        public Shop_SistemaAuto_DeleteResponse(Guid correlationId) : base(correlationId) { }
    }
}
