using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawPos.Infrastructure
{
    public static class KeyGenerator
    {
        public static string GenerateKey(int length)
        {
            Random random = new Random();

            const string chars = "abcdefghijklmnoprstuvyzqw0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());


        }
    }
}
