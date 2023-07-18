namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_GetByIdResponse : BaseResponse
    {
        public Shop_Cliente_Dto Shop_Cliente { get; set; }
        public Shop_Cliente_GetByIdResponse(Guid correlationId) : base(correlationId)
        {

        }
        public Shop_Cliente_GetByIdResponse() { }
    }
}
