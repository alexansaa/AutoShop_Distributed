namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_CreateRequest : BaseRequest
    {
        public string Shop_Auto_Marca { get; set; }
        public string Shop_Auto_Modelo { get; set;}
        public string Shop_Auto_Tipo { get; set;}
        public int Shop_Auto_Year { get; set;}
        public double Shop_Auto_Cilindraje { get; set;}
    }
}
