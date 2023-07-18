using System.ComponentModel.DataAnnotations;

namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_UpdateRequest : BaseRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Shop_Cliente_Id { get; set; }
        [Required]
        public string Ruc { get; set; }
        [Required]
        public string Shop_Cliente_NombreComercial { get; set; }
        [Required]
        public string Shop_Cliente_Nombre1 { get; set; }
        [Required]
        public string Shop_Cliente_Nombre2 { get; set; }
        [Required]
        public string Shop_Cliente_Apellido1 { get; set; }
        [Required]
        public string Shop_Cliente_Apellido2 { get; set; }
        [Required]
        public string Shop_Cliente_Direccion1 { get; set; }
        [Required]
        public string Shop_Cliente_Direccion2 { get; set; }
        [Required]
        public string Shop_Cliente_Telefono1 { get; set; }
        [Required]
        public string Shop_Cliente_Telefono2 { get; set; }
        [Required]
        public string Shop_Cliente_Telefono3 { get; set; }
        [Required]
        public string Shop_Cliente_Email { get; set; }
        [Required]
        public int Shop_Cliente_Estrellas { get; set; }
        [Required]
        public double Shop_Cliente_CupoCredito { get; set; }
        [Required]
        public int Shop_Cliente_PlazoCredito { get; set; }
    }
}
