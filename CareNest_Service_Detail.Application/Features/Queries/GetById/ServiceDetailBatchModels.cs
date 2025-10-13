using System.ComponentModel.DataAnnotations;

namespace CareNest_Service_Detail.Application.Features.Queries.GetById
{
    public class GetByIdsRequest
    {
        [Required]
        public List<string> Ids { get; set; } = new List<string>();

        public List<string>? Fields { get; set; }
    }

    public class ServiceDetailBatchItem
    {
        public string? Id { get; set; }
        public string? ServiceId { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? DurationTime { get; set; }
        public bool? Status { get; set; }
        public double? Discount { get; set; }
        public bool? IsDefault { get; set; }
        public string? ImgUrls { get; set; }
        public string? ServiceName { get; set; }
    }

    public class GetByIdsResponse
    {
        public List<ServiceDetailBatchItem> Items { get; set; } = new List<ServiceDetailBatchItem>();
        public List<string> NotFoundIds { get; set; } = new List<string>();
        public int Total { get; set; }
    }
}


