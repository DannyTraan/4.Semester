using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace GoFTemplateMethod
{
    public class ArrayGenerator
    {
        public ArrayGenerator()
        {
            int min = 0;
            int max = 20;

            int[] test2 = new int[5];

            Random rannum = new Random();

            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = rannum.Next(min, max);
                Console.WriteLine($"{test2[i]}");
            }
        }
    }
}
