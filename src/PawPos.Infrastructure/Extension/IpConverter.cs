using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Infrastructure.Extension
{
    public static class IpConverter
    {
        public static long IPToLong(this string IPaddress)
        {
            int i;
            string[] arrDec;
            long num = 0;
            if (IPaddress == "")
            {
                return 0;
            }

            else
            {
                if (IPaddress.Contains(","))
                {
                    string[] Ips = IPaddress.Split(',');

                    if (Ips.Length > 0)
                    {
                        IPaddress = Ips[Ips.Length - 1];
                    }
                }
                arrDec = IPaddress.Split('.');
                for (i = arrDec.Length - 1; i >= 0; i = i - 1)
                {
                    num += (long)((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
                }
                return num;
            }
        }
        public static string LongToIP(this long longIP)
        {
            string ip = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int num = (int)(longIP / Math.Pow(256, (3 - i)));
                longIP = longIP - (long)(num * Math.Pow(256, (3 - i)));
                if (i == 0)
                    ip = num.ToString();
                else
                    ip = ip + "." + num.ToString();
            }
            return ip;
        }
    }
}
