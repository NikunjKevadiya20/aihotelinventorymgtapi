using Microsoft.AspNetCore.Http;
using SkiaSharp;
using System;
 
namespace HotelBooking.Entity.Common.Helper
{
    public static class ImageHelper
    {

        public static async Task CompressWithSkia(IFormFile file, string path)
        {
            const long maxSize = 200 * 1024;
            const long oneMbSize = 1 * 1024 * 1024;

            //  Small file: WebP, NO compression loss
            if (file.Length <= maxSize)
            {
                using var stream = file.OpenReadStream();
                using var bitmapSmall = SKBitmap.Decode(stream);

                if (bitmapSmall == null)
                    throw new Exception("Invalid image file");

                using var imageSmall = SKImage.FromBitmap(bitmapSmall);

                // quality = 100 → preserve quality
                using var dataSmall = imageSmall.Encode(SKEncodedImageFormat.Webp, 100);

                await File.WriteAllBytesAsync(path, dataSmall.ToArray());
                return;
            }

            // Existing logic untouched
            using var input = file.OpenReadStream();
            using var bitmap = SKBitmap.Decode(input);

            if (bitmap == null)
                throw new Exception("Invalid image file");

            using var image = SKImage.FromBitmap(bitmap);

            int quality;

            if (file.Length > oneMbSize)
            {
                quality = 20;
            }
            else
            {
                quality = 85;
            }

            using var data = image.Encode(SKEncodedImageFormat.Webp, quality);



            await File.WriteAllBytesAsync(path, data.ToArray());
        }

    }
}
