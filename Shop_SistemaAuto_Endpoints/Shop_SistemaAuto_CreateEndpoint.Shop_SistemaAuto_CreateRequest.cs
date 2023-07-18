namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_CreateRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
    }
}
