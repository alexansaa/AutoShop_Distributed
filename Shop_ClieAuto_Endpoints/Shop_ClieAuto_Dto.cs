namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_Dto
    {
        public long Id { get; set; }
        public long Shop_ClienteId { get; set; }
        public long Shop_AutoId { get; set; }
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        public string Motor_Numeracion { get; set; }
        public string Chasis_Numeracion { get; set; }
        public string Uso { get; set; }
        public string Observacion { get; set; }
    }
}
