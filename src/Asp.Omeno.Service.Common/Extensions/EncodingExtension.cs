using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Asp.Omeno.Service.Common.Extensions
{
    public static class EncodingExtension
    {
        public static string Encode(this string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);

            return WebEncoders.Base64UrlEncode(bytes);
        }
    }
}
