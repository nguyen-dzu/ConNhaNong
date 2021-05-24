using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConNhaNong.Services
{
    public static class IDServices
    {
        public static string RandomIDUser()
        {
            string s = "US";
            Random random = new Random();

                for (int i = 0; i <= 3; i++)
                {
                    int r = random.Next(0, 2);
                    if (r == 0)
                    {
                        int ran = random.Next(0, 9);
                        s += ran.ToString();
                    }
                    else
                    {
                        int ran = random.Next('A', 'Z');
                        s += ((char)ran).ToString();
                    }
                }
                return s;
        }
        public static string RandomIDProduct()
        {
            string s = "SP";
            Random random = new Random();

            for (int i = 0; i <= 5; i++)
            {
                int r = random.Next(0, 2);
                if (r == 0)
                {
                    int ran = random.Next(0, 9);
                    s += ran.ToString();
                }
                else
                {
                    int ran = random.Next('A', 'Z');
                    s += ((char)ran).ToString();
                }
            }
            return s;
        }
    }
}