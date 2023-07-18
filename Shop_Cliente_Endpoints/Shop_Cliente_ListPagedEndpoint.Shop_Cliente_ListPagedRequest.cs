namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_ListPagedRequest : BaseRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? Ruc { get; set; }
        public string? NombreComercial { get; set; }
        public string? Nombre1 { get; set; }
        public string? Nombre2 { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public int? Estrellas { get; set; }
        public Shop_Cliente_ListPagedRequest(int? PageSize, int? PageIndex, string? Ruc, string? NombreComercial, string? Nombre1, string? Nombre2,
            string? Apellido1, string? Apellido2, int? Estrellas)
        {
            this.PageSize = PageSize ?? 0;
            this.PageIndex = PageIndex ?? 0;
            this.Ruc = Ruc;
            this.NombreComercial = NombreComercial;
            this.Nombre1 = Nombre1;
            this.Nombre2 = Nombre2;
            this.Apellido1 = Apellido1;
            this.Apellido2 = Apellido2;
            this.Estrellas = Estrellas;
        }
    }
}
