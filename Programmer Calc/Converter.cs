using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer_Calc
{
    class Converter
    {
        public Converter()
        {

        }

        #region From Binary
        // From Binary
        public string binaToOcta(string input)
        {
            string tempResult = "";
            while ((input.Length % 3) != 0)
            {
                input = "0" + input;
            }

            for (int i = 0; i < (input.Length / 3); i++)
            {
                /*
                    Starting from the last 3 digits of the string
                    Converting each into one digit
                */
                string ch = input.Substring(i * 3, 3);
                switch (ch)
                {
                    case "000":
                        tempResult += "0";
                        break;
                    case "001":
                        tempResult += "1";
                        break;
                    case "010":
                        tempResult += "2";
                        break;
                    case "011":
                        tempResult += "3";
                        break;
                    case "100":
                        tempResult += "4";
                        break;
                    case "101":
                        tempResult += "5";
                        break;
                    case "110":
                        tempResult += "6";
                        break;
                    case "111":
                        tempResult += "7";
                        break;
                }
            }

            return tempResult;
        }

        public string binaToDeci(string input)
        {
            ulong tempResult = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[input.Length - i - 1] == '1')
                    tempResult += (ulong)Math.Pow(2, i);
            }
            return tempResult.ToString();
        }

        public string binaToHex(string input)
        {
            string tempResult = "";
            while ((input.Length % 4) != 0)
            {
                input = "0" + input;
            }

            for (int i = 0; i < (input.Length / 4); i++)
            {
                /*
                    Starting from the last 3 digits of the string
                    Converting each into one digit
                */
                string ch = input.Substring(i * 4, 4);
                switch (ch)
                {
                    case "0000":
                        tempResult += "0";
                        break;
                    case "0001":
                        tempResult += "1";
                        break;
                    case "0010":
                        tempResult += "2";
                        break;
                    case "0011":
                        tempResult += "3";
                        break;
                    case "0100":
                        tempResult += "4";
                        break;
                    case "0101":
                        tempResult += "5";
                        break;
                    case "0110":
                        tempResult += "6";
                        break;
                    case "0111":
                        tempResult += "7";
                        break;
                    case "1000":
                        tempResult += "8";
                        break;
                    case "1001":
                        tempResult += "9";
                        break;
                    case "1010":
                        tempResult += "A";
                        break;
                    case "1011":
                        tempResult += "B";
                        break;
                    case "1100":
                        tempResult += "C";
                        break;
                    case "1101":
                        tempResult += "D";
                        break;
                    case "1110":
                        tempResult += "E";
                        break;
                    case "1111":
                        tempResult += "F";
                        break;
                }
            }

            return tempResult;
        }

        // From Octal
        public string octaToBina(string input)
        {
            string tempResult = "";
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                switch (ch)
                {
                    case '0':
                        tempResult += "000";
                        break;
                    case '1':
                        tempResult += "001";
                        break;
                    case '2':
                        tempResult += "010";
                        break;
                    case '3':
                        tempResult += "011";
                        break;
                    case '4':
                        tempResult += "100";
                        break;
                    case '5':
                        tempResult += "101";
                        break;
                    case '6':
                        tempResult += "110";
                        break;
                    case '7':
                        tempResult += "111";
                        break;
                }
            }

            return tempResult;
        }

        public string octaToDeci(string input)
        {
            return binaToDeci(octaToBina(input));
        }

        public string octaToHex(string input)
        {
            return binaToHex(octaToBina(input));
        }
        #endregion

        #region From Deci
        // From Decimal
        public string deciToBina(string input)
        {
            ulong num;
            ulong quot;
            bool canParse = ulong.TryParse(input, out num);
            string reversed = "";
            string tempResult = "";

            while (num >= 1)
            {
                quot = num / 2;
                reversed += (num % 2).ToString();
                num = quot;
            }

            // Reversing the value
            for (int i = reversed.Length - 1; i >= 0; i--)
            {
                tempResult = tempResult + reversed[i];
            }

            return tempResult;
        }

        public string deciToOcta(string input)
        {
            return binaToOcta(deciToBina(input));
        }

        public string deciToHex(string input)
        {
            return binaToHex(deciToBina(input));
        }
        #endregion

        #region From Hex
        // From Hex
        public string hexaToBina(string input)
        {
            string tempResult = "";
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                switch (ch)
                {
                    case '0':
                        tempResult += "0000";
                        break;
                    case '1':
                        tempResult += "0001";
                        break;
                    case '2':
                        tempResult += "0010";
                        break;
                    case '3':
                        tempResult += "0011";
                        break;
                    case '4':
                        tempResult += "0100";
                        break;
                    case '5':
                        tempResult += "0101";
                        break;
                    case '6':
                        tempResult += "0110";
                        break;
                    case '7':
                        tempResult += "0111";
                        break;
                    case '8':
                        tempResult += "1000";
                        break;
                    case '9':
                        tempResult += "1001";
                        break;
                    case 'A':
                        tempResult += "1010";
                        break;
                    case 'B':
                        tempResult += "1011";
                        break;
                    case 'C':
                        tempResult += "1100";
                        break;
                    case 'D':
                        tempResult += "1101";
                        break;
                    case 'E':
                        tempResult += "1110";
                        break;
                    case 'F':
                        tempResult += "1111";
                        break;
                }
            }

            return tempResult;
        }

        public string hexaToOcta(string input)
        {
            return binaToOcta(hexaToBina(input));
        }

        public string hexaToDeci(string input)
        {
            return binaToDeci(hexaToBina(input));
        }
        #endregion

        // returns true if the number has less than or equal to 64 bits in binary (<= 18446744073709551615)
        // returns false if the number has more than 64 bits in binary (> 18446744073709551615)
        public bool checkSize(string input, string type)
        {
            string tempResult = "";
            UInt64 parsed = 0;
            bool canParse;
            if (type.Equals("bina"))
            {
                tempResult = binaToDeci(input);
                canParse = UInt64.TryParse(tempResult, out parsed);

                return canParse;
            }
            else if (type.Equals("octa"))
            {
                tempResult = octaToDeci(input);
                canParse = UInt64.TryParse(tempResult, out parsed);

                return canParse;
            }
            else if (type.Equals("hexa"))
            {
                tempResult = hexaToDeci(input);
                canParse = UInt64.TryParse(tempResult, out parsed);

                return canParse;
            }
            else if (type.Equals("deci"))
            {
                canParse = UInt64.TryParse(tempResult, out parsed);

                return canParse;
            }

            return true;
        }
    }
}
