namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_CreateResponse : BaseResponse
    {
        public Shop_ClieAuto_Dto Shop_ClieAuto { get; set; }
        public Shop_ClieAuto_CreateResponse ()
        {

        }
        public Shop_ClieAuto_CreateResponse (Guid correlationId) : base(correlationId) { }
    }
}
