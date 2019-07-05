using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PawPos.Infrastructure.Extension
{
    public static class Mail
    {
        public static bool IsValidEmail(this string mail)
        {
            var regex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            return Regex.IsMatch(mail, regex);
        }
    }
}
