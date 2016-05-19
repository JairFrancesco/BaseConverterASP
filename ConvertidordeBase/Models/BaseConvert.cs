using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ConvertidordeBase.Models
{
    public static class BaseConvert
    {
        public static string ConvertBase(string num, int fromBase, int toBase) {
            long number;
            if (fromBase != 16)
            {
                number = Convert.ToInt64(num);
            }
            else
            {
                number = 0;
            }
            if (fromBase == toBase)
            {
                return num;
            }
            else
            {
                if (fromBase == 10 && toBase == 2) //&& number<256)
                {
                    int counter = (int)Math.Truncate(Math.Log(number, 2));
                    long binaryCount = (long)Math.Pow(2, counter);
                    long result = 0;
                    long temp = number;
                    while (binaryCount >= 1)
                    {
                        if (temp >= binaryCount)
                        {
                            result = result + (long)Math.Pow(10, counter);
                            temp = number % binaryCount;
                        }
                        binaryCount /= 2;
                        counter = counter - 1;
                    }
                    return result.ToString();
                }
                else if (fromBase == 16)
                {
                    long tmp = HexadecimalToDecimal(num);
                    if (toBase == 10)
                    {
                        return tmp.ToString();
                    }
                    else
                    {
                        return DecimalToN(tmp, toBase).ToString();
                    }
                }
                else if (toBase == 16)
                {
                    long tmp;
                    if (fromBase == 10)
                    {
                        return HexadecimalToDecimal(num).ToString();
                        //tmp = NToDecimal(number, fromBase);
                    }
                    tmp = NToDecimal(number, fromBase);
                    return DecimalToHexadecimal(tmp);
                }
                else if (fromBase == 10)
                {
                    return DecimalToN(number, toBase).ToString();
                }
                else if (toBase == 10)
                {
                    return NToDecimal(number, fromBase).ToString();
                }
                else
                {
                    long tmp = NToDecimal(number, fromBase);
                    return DecimalToN(tmp, toBase).ToString();
                }
            }
        }

        public static long NToDecimal(long number, int fromBase)
        {
            string baseNumber = number.ToString();
            int length = baseNumber.Length - 1;
            long newNumber = 0;
            foreach (char item in baseNumber)
            {
                newNumber += (long)char.GetNumericValue(item) * (long)(Math.Pow(fromBase, length));
                length--;
            }
            return newNumber;
        }
        public static long DecimalToN(long number, int toBase)
        {
            long remainder = number;
            string newNumber = "";
            while (remainder >= toBase)
            {
                newNumber = (remainder % toBase).ToString() + newNumber;
                remainder /= toBase;
            }
            newNumber = remainder.ToString() + newNumber;
            return long.Parse(newNumber);

        }

        public static string DecimalToHexadecimal(long number) {
            long remainder = number;
            string newNumber = "";
            while (remainder >= 16)
            {
                if (remainder % 16 > 9)
                {
                    if (remainder % 16 == 10)
                    {
                        newNumber = "A" + newNumber;
                    }
                    else if (remainder % 16 == 11)
                    {
                        newNumber = "B" + newNumber;
                    }
                    else if (remainder % 16 == 12)
                    {
                        newNumber = "C" + newNumber;
                    }
                    else if (remainder % 16 == 13)
                    {
                        newNumber = "D" + newNumber;
                    }
                    else if (remainder % 16 == 14)
                    {
                        newNumber = "E" + newNumber;
                    }
                    else if (remainder % 16 == 15)
                    {
                        newNumber = "F" + newNumber;
                    }
                }
                else
                {
                    newNumber = (remainder % 16).ToString() + newNumber;
                }
                remainder /= 16;
            }
            if (remainder > 9)
            {
                if (remainder == 10)
                {
                    newNumber = "A" + newNumber;
                }
                else if (remainder == 11)
                {
                    newNumber = "B" + newNumber;
                }
                else if (remainder == 12)
                {
                    newNumber = "C" + newNumber;
                }
                else if (remainder == 13)
                {
                    newNumber = "D" + newNumber;
                }
                else if (remainder == 14)
                {
                    newNumber = "E" + newNumber;
                }
                else if (remainder == 15)
                {
                    newNumber = "F" + newNumber;
                }
            }
            else
            {
                newNumber = remainder.ToString() + newNumber;
            }
            return newNumber;
        }
        public static long HexadecimalToDecimal(string number) {
            try
            {

                long tmp = 0;
                long newNumber = 0;
                int length = number.Length - 1;
                foreach (var item in number)
                {
                    if (char.ToString(item) == "A")
                    {
                        tmp = 10;
                    }
                    else if (char.ToString(item) == "B")
                    {
                        tmp = 11;
                    }
                    else if (char.ToString(item) == "C")
                    {
                        tmp = 12;
                    }
                    else if (char.ToString(item) == "D")
                    {
                        tmp = 13;
                    }
                    else if (char.ToString(item) == "E")
                    {
                        tmp = 14;
                    }
                    else if (char.ToString(item) == "F")
                    {
                        tmp = 15;
                    }
                    else {
                        tmp = (long)char.GetNumericValue(item);
                    }
                    newNumber += tmp * (long)(Math.Pow(16, length));
                    length--;
                }
                return newNumber;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }

}