using System.Text.RegularExpressions;

namespace Asp.Omeno.Service.Common.Constants
{
    public static class ValidatorRegex
    {
        public static string Email = @"^(?=[a-zA-Z0-9@._%+-]{6,254}$)[a-zA-Z0-9._%+-]{1,64}@(?:[a-zA-Z0-9-]{1,63}\.){1,8}[a-zA-Z]{2,63}$";
        public static string FirstName = @"[A-Z][a-z]+$";
        public static string LastName = @"[A-Z][a-z]+$";
        public static string UserName = @"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$";
        public static string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{6,}$";

        public static bool MatchRegex(string regexVal, string data)
        {

            Regex regex = new Regex(regexVal);

            Match match = regex.Match(data);

            if (match.Success) return true;

            else return false;
        }
    }
}
