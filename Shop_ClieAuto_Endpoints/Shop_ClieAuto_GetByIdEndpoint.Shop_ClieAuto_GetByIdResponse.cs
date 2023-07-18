using ApplicationCore.Entites;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_GetByIdResponse : BaseResponse
    {
        public Shop_ClieAuto_Dto Shop_ClieAuto { get; set; }
        public Shop_ClieAuto_GetByIdResponse(Guid correlationId) : base(correlationId) { }
        public Shop_ClieAuto_GetByIdResponse() { }
    }
}
