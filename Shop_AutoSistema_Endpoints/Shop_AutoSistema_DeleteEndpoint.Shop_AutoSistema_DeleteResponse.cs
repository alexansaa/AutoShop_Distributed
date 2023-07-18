namespace SagaMotors_API.Shop_AutoSistema_Endpoints
{
    public class Shop_AutoSistema_DeleteResponse : BaseResponse
    {
        public string Status { get; set; } = "Deleted";
        public Shop_AutoSistema_DeleteResponse()
        {

        }

        public Shop_AutoSistema_DeleteResponse(Guid correlationId) : base(correlationId) { }
    }
}
