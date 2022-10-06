using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Asp.Omeno.Service.Common.Extensions
{
    public static class DecodeExtension
    {
        public static string Decode(this string value, Encoding encoding)
        {
            var bytes = WebEncoders.Base64UrlDecode(value);

            return encoding.GetString(bytes);
        }
    }
}
