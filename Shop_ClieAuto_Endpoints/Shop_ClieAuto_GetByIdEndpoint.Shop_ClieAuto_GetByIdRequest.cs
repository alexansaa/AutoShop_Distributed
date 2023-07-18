namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_GetByIdRequest : BaseRequest
    {
        public long Shop_ClieAuto_Id { get; set; }
        public Shop_ClieAuto_GetByIdRequest(long Shop_ClieAuto_Id)
        {
            this.Shop_ClieAuto_Id = Shop_ClieAuto_Id;
        }

    }
}
