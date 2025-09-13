using CareNest_Service_Detail.Application.Interfaces.CQRS.Commands;
using CareNest_Service_Detail.Domain.Entitites;

namespace CareNest_Service_Detail.Application.Features.Commands.Create
{
    public class CreateCommand : ICommand<Service_Detail>
    {
        /// <summary>
        /// Id của loại dịch vụ (category)
        /// </summary>
        public string? ServiceCategoryId { get; set; }
        /// <summary>
        /// tên chi tiết
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// giá
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// thời gian thực hiện 
        /// </summary>
        public int DurationTime { get; set; }
        /// <summary>
        /// trạng thái dịch vụ (1: hoạt động, 0: không hoạt động)
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// giảm giá (%)
        /// </summary>
        public double Discount { get; set; }
        /// <summary>
        /// mặt định hay không
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// đường dẫn hình ảnh
        /// </summary>
        public string? ImgUrls { get; set; }
    }
}
