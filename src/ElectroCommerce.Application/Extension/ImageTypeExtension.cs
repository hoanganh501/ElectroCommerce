using Domain.Enum;
using ElectroCommerce.Application.Enum;

namespace ElectroCommerce.Application.Extension
{
    public static class ImageTypeExtension
    {
        public static ImageTypeApplication ToApplication(this ImageType type)
        {
            return type switch
            {
                ImageType.Thumbnail => ImageTypeApplication.Thumbnail,
                ImageType.Variant => ImageTypeApplication.Variant,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid ImageType")
            };
        }

        public static ImageType ToDomain(this ImageTypeApplication type)
        {
            return type switch
            {
                ImageTypeApplication.Thumbnail => ImageType.Thumbnail,
                ImageTypeApplication.Variant => ImageType.Variant,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid ImageTypeApplication")
            };
        }
    }
}
