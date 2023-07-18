namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_CreateResponse : BaseResponse
    {
        public Shop_SistemaAuto_Dto Shop_SistemaAuto { get; set; }
        public Shop_SistemaAuto_CreateResponse() { }
        public Shop_SistemaAuto_CreateResponse(Guid correlationId) : base(correlationId) { }
    }
}
