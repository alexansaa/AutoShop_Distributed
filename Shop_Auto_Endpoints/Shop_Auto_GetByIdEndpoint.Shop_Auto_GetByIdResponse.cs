namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_GetByIdResponse : BaseResponse
    {
        public Shop_Auto_GetByIdResponse(Guid correlationId) : base(correlationId)
        {
        }

        public Shop_Auto_GetByIdResponse()
        {

        }

        public Shop_Auto_Dto Shop_Auto { get; set; }
    }
}
