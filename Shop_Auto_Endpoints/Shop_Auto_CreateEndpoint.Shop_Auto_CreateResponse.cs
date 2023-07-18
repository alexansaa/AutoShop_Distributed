namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_CreateResponse : BaseResponse
    {
        public Shop_Auto_CreateResponse(Guid correlationId) : base(correlationId) { }
        public Shop_Auto_CreateResponse() { }
        public Shop_Auto_Dto Shop_Auto {  get; set; }
    }
}
