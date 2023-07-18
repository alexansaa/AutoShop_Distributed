using System.ComponentModel.DataAnnotations;

namespace SagaMotors_API.Shop_SistemaAuto_Endpoints
{
    public class Shop_SistemaAuto_UpdateRequest : BaseRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Detalle { get; set; }
    }
}
