using System.ComponentModel.DataAnnotations;

namespace SagaMotors_API.Shop_ClieAuto_Endpoints
{
    public class Shop_ClieAuto_UpdateRequest : BaseRequest
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long Id { get; set; }
        [Required] 
        public long Shop_ClienteId { get; set; }
        [Required]
        public long Shop_AutoId { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Kilometraje { get; set; }
        [Required]
        public string Motor_Numeracion { get; set; }
        [Required]
        public string Chasis_Numeracion { get; set; }
        [Required]
        public string Uso { get; set; }
        [Required]
        public string Observacion { get; set; }
    }
}
