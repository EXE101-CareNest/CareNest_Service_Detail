namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class ServiceDetailByIdResponse
    {
        public string? Id { get; set; }
        public string? ServiceId { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int DurationTime { get; set; }
        public bool Status { get; set; }
        public double Discount { get; set; }
        public bool IsDefault { get; set; } = true;
        public string? ImgUrls { get; set; }
        public string? ServiceName { get; set; }
    }
}


