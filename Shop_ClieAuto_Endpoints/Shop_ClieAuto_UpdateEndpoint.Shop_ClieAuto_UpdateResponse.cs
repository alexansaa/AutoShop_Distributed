namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_UpdateResponse : BaseResponse
    {
        public Shop_ClieAuto_Dto Shop_ClieAuto { get; set; }
        public Shop_ClieAuto_UpdateResponse()
        {

        }
        public Shop_ClieAuto_UpdateResponse(Guid correlationId) : base(correlationId) { }
    }
}
