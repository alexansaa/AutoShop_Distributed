namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_UpdateResponse : BaseResponse
    {
        public Shop_SistemaAuto_Dto Shop_SistemaAuto { get; set; }
        public Shop_SistemaAuto_UpdateResponse()
        {

        }

        public Shop_SistemaAuto_UpdateResponse(Guid correlationId) : base(correlationId)
        {

        }

    }
}
