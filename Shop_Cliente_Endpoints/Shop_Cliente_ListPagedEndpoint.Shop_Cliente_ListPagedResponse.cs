namespace SagaMotors_API.Shop_Cliente_Endpoints
{
    public class Shop_Cliente_ListPagedResponse : BaseResponse
    {
        public List<Shop_Cliente_Dto> Shop_Clientes { get; set; } = new List<Shop_Cliente_Dto>();
        public int PageCount { get; set; }
        public Shop_Cliente_ListPagedResponse(Guid correlationId) : base(correlationId) { }
        public Shop_Cliente_ListPagedResponse() { }


    }
}
