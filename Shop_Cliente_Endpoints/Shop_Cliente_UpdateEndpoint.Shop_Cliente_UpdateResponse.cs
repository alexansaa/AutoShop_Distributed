namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_UpdateResponse : BaseResponse
    {
        public Shop_Cliente_UpdateResponse(Guid correlationId) : base(correlationId) { }
        public Shop_Cliente_UpdateResponse()
        {

        }

        public Shop_Cliente_Dto Shop_Cliente { get; set; }

    }
}
