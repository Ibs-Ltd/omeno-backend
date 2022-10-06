using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Common.Constants
{
    public static class ValidatorMessages
    {
        public static string NotEmpty(this string msg)
        {
            return $"{msg} must not be empty";
        }
        public static string NotFound(this string msg)
        {
            return $"{msg} can not be found!";
        }
        public static string MinLength(this string msg)
        {
            return $"{msg} must be at last {Conditions.PasswordMinLength} characters";
        }
        public static string FormatNotMatch(this string msg)
        {
            return $"Please provide a valid {msg}";
        }
        public static string AlreadyExists(this string msg)
        {
            return $"{msg} is already registered";
        }

        public static string Errors(IList<string> errors)
        {
            JArray asd = new JArray();
            asd.Add(errors);
            JObject result = new JObject();
            result["Errors"] = asd;
            return result.ToString();
        }
    }
}
