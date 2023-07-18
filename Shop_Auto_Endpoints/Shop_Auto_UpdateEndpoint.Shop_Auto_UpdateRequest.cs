using System.ComponentModel.DataAnnotations;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_UpdateRequest : BaseRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Shop_AutoId { get; set; }
        [Required]
        public string Shop_Auto_Marca { get; set; }
        [Required]
        public string Shop_Auto_Modelo { get; set; }
        [Required]
        public string Shop_Auto_Tipo { get; set; }
        [Required]
        public int Shop_Auto_Year { get; set; }
        [Required]
        public double Shop_Auto_Cilidraje { get; set; }
    }
}
