namespace SagaMotors_API.Shop_Auto_Endpoints
{
    public class Shop_Auto_ListPagedResponse : BaseResponse
    {
        public Shop_Auto_ListPagedResponse(Guid correlationId) : base(correlationId) { }

        public Shop_Auto_ListPagedResponse() { }

        public List<Shop_Auto_Dto> Shop_Autos { get; set; } = new List<Shop_Auto_Dto>();
        public int PageCount {get; set;}
    }
}
