using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.ToolLibrary
{
    public class RandomAdv : Random
    {
        public RandomAdv()
        {

        }

        public RandomAdv(int Seed) : base(Seed)
        {

        }


        public string NextString(int length)
        {
            string randomString = string.Empty;
            int randomChar = 0;

            for (int i = 0; i < length; i++)
            {
                int isUpperCase = this.Next(0, 2); //0 = lowerCase, 1 = uppercase, 2 = numeric, 3 = sign
                if (isUpperCase == 0)
                {
                    randomChar = this.Next('a', 'z' + 1);                    
                }
                else
                {
                    randomChar = this.Next('A', 'Z' + 1);
                }

                randomString += (char)randomChar;
            }

            return randomString;
        }
    }
}
