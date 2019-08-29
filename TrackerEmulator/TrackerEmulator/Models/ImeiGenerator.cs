// TrackerEmulator ImeiGenerator.cs
// Created by Nikita Neverov at 29.08.2019 17:25

using System;
using System.Text;

namespace TrackerEmulator.Models
{
    public static class ImeiGenerator
    {
        public static string Generate()
        {
            var random = new Random();
            var sb = new StringBuilder(14);

            string[]
                rbi = new string[]
                {
                    "01", "10", "30", "33", "35", "44", "45", "49", "50", "51", "52", "53", "54", "86", "91", "98", "99"
                };

            sb.Append(rbi[random.Next(0, rbi.Length - 1)]);

            for (var i = 2; i < 14; i++)
            {
                sb[i] = Convert.ToChar(random.Next(0, 9));
            }

            //len_offset = (len + 1) % 2;
            //for (pos = 0; pos < len - 1; pos++)
            //{
            //    if ((pos + len_offset) % 2)
            //    {
            //        t = str[pos] * 2;
            //        if (t > 9)
            //        {
            //            t -= 9;
            //        }
            //        sum += t;
            //    }
            //    else
            //    {
            //        sum += str[pos];
            //    }
            //}

            var offset = 16 % 2;
            var sum = 0;
            for (var i = 0; i < 14; i++)
            {
                if ((i + offset) % 2 != 0)
                {
                    var t = sb[i] * 2;
                    if (t > 9)
                    {
                        t -= 9
                    }

                    sum += t;

                }
                else
                {
                    {}
                }
            }
        }
    }
}
