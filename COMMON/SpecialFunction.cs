using System.Web;

namespace COMMON
{
    public static class SpecialFunction
    {
        static string str;

        static readonly string[] a = {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };

        static readonly string[] b = {
            "hundred", "thousand", "lakh", "crore"
        };

        static readonly string[] c = {
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen"
        };

        static readonly string[] d = {
            "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        public static string ConvertNumToWord(int number)
        {
            if (number == 0)
                return "Zero";

            str = "";
            int c = 1;
            int rm;

            while (number != 0)
            {
                switch (c)
                {
                    case 1: // units and tens
                        rm = number % 100;
                        Pass(rm);
                        if (number > 100 && number % 100 != 0)
                        {
                            Display(" and ");
                        }
                        number /= 100;
                        break;

                    case 2: // hundreds
                        rm = number % 10;
                        if (rm != 0)
                        {
                            Display(" ");
                            Display(b[0]);
                            Display(" ");
                            Pass(rm);
                        }
                        number /= 10;
                        break;

                    case 3: // thousands
                        rm = number % 100;
                        if (rm != 0)
                        {
                            Display(" ");
                            Display(b[1]);
                            Display(" ");
                            Pass(rm);
                        }
                        number /= 100;
                        break;

                    case 4: // lakhs
                        rm = number % 100;
                        if (rm != 0)
                        {
                            Display(" ");
                            Display(b[2]);
                            Display(" ");
                            Pass(rm);
                        }
                        number /= 100;
                        break;

                    case 5: // crores
                        rm = number % 100;
                        if (rm != 0)
                        {
                            Display(" ");
                            Display(b[3]);
                            Display(" ");
                            Pass(rm);
                        }
                        number /= 100;
                        break;
                }
                c++;
            }

            // Capitalize first letter
            return CapitalizeFirstLetter(str.Trim());
        }

        public static void Pass(int number)
        {
            int rm, q;
            if (number < 10)
            {
                Display(a[number]);
            }
            else if (number >= 10 && number < 20)
            {
                Display(c[number - 10]);
            }
            else if (number >= 20)
            {
                rm = number % 10;
                q = number / 10;
                if (rm != 0)
                {
                    Display(a[rm]);
                    Display(" ");
                }
                Display(d[q - 2]);
            }
        }

        public static void Display(string s)
        {
            str += s;
        }

        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
    public static class NetworkHelper
    {
        public static string GetIPAddress(HttpRequest request)
        {
            string ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length > 0)
                    return addresses[0].Trim();
            }
            return request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
