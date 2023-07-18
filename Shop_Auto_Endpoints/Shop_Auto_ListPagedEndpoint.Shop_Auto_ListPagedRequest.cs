using JetBrains.Annotations;

namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_ListPagedRequest : BaseRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Tipo { get; set; }
        public int? Year { get; set; }
        public double? Cilindraje { get; set; }
        public Shop_Auto_ListPagedRequest(int? PageSize, int? PageIndex, string? marca, string? modelo, string? tipo, int? year, double? cilindraje)
        {
            this.PageSize = PageSize ?? 0;
            this.PageIndex = PageIndex ?? 0;
            Marca = marca;
            Modelo = modelo;
            Tipo = tipo;
            Year = year;
            Cilindraje = cilindraje;
        }
    }
}
