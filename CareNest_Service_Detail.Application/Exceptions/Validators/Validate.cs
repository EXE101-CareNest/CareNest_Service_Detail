using CareNest_Service_Detail.Application.Features.Commands.Create;
using CareNest_Service_Detail.Application.Features.Commands.Update;
using CareNest_Service_Detail.Domain.Commons.Constant;
using System.Text.RegularExpressions;

namespace CareNest_Service_Detail.Application.Exceptions.Validators
{
    public class Validate
    {
        /// <summary>
        /// kiểm tra toàn bộ tạo dịch vụ
        /// </summary>
        /// <param name="command"></param>
        public static void ValidateCreate(CreateCommand command)
        {
            ValidateName(command.Name);
            ValidatePrice(command.Price);
            ValidateDiscount(command.Discount);
            ValidateDuration(command.DurationTime);
            ValidateServiceCategoryId(command.ServiceId);
        }
        /// <summary>
        /// kiểm tra cập nhật dịch vụ
        /// </summary>
        /// <param name="command"></param>
        public static void ValidateUpdate(UpdateCommand command)
        {
            ValidateName(command.Name);
            ValidatePrice(command.Price);
            ValidateDiscount(command.Discount);
            ValidateDuration(command.DurationTime);
            ValidateServiceCategoryId(command.ServiceId);
        }
        /// <summary>
        /// Valiđ tên dịch vụ
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="BadRequestException"></exception>
        public static void ValidateName(string? name)
        {
            //-Không được để trống.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException(MessageConstant.MissingName);
            }
            //- Giới hạn độ dài(ví dụ 1 - 100 ký tự).
            if (name.Length == 0 || name.Length > 100)
            {
                throw new BadRequestException(MessageConstant.Exceed100CharsName);
            }
            //- Không chứa ký tự đặc biệt (!@#$^*&<>?)
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
            {
                throw new BadRequestException(MessageConstant.SpecialCharacterName);
            }
        }
        /// <summary>
        /// valid id service category
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="BadRequestException"></exception>
        public static void ValidateServiceCategoryId(string? id)
        {
            // id của chủ shop không được trống
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new BadRequestException(MessageConstant.MissingServiceCategoryId);
            }
        }

        /// <summary>
        /// valid price
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="BadRequestException"></exception>
        public static void ValidatePrice(int? price)
        {
            if (price < 0)
            {
                throw new BadRequestException(MessageConstant.InvalidPrice);
            }
        }
        /// <summary>
        /// valid Duration
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="BadRequestException"></exception>
        public static void ValidateDuration(int? duration)
        {
            if (duration < 0)
            {
                throw new BadRequestException(MessageConstant.InvalidDuration);
            }
        }
        /// <summary>
        /// valid discount
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="BadRequestException"></exception>
        public static void ValidateDiscount(double? discount)
        {
            if (discount < 0)
            {
                throw new BadRequestException(MessageConstant.InvalidDiscount);
            }
        }
    }
}
