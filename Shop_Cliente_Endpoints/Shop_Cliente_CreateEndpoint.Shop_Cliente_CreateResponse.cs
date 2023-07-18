namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_CreateResponse : BaseResponse
    {
        public Shop_Cliente_Dto Shop_cliente { get; set; }
        public Shop_Cliente_CreateResponse() { }
        public Shop_Cliente_CreateResponse(Guid correlationId) : base(correlationId) { }
    }
}
