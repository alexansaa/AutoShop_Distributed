namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_CreateRequest : BaseRequest
    {
        public string Ruc { get; set; }
        public string NombreComercial { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Estrellas { get; set; }
        public double CupoCredito { get; set; }
        public int PlazoCredito { get; set; }
    }
}
