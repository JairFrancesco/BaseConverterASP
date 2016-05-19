using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ConvertidordeBase.Models
{
    public static class BaseConvert
    {
        public static string Convert(long number, int fromBase, int toBase) {

            if (fromBase == toBase)
            {
                return number.ToString();
            }
            else
            {
                if (fromBase == 10 && toBase == 2 && number<256)
                {

                    long result = 0;
                    long temp = number;
                    int binaryCount = 128;
                    int counter = 7;
                    /*try
                    {*/
                        while (binaryCount>=1)
                        {
                            if (temp >= binaryCount)
                            {
                                result = result + (long)Math.Pow(10, counter);
                                temp = number - binaryCount;
                            }
                            binaryCount /= 2;
                            counter--;
                        }
                        return result.ToString();
                    /*}
                    catch (Exception)
                    {
                        return result.ToString();
                        throw;
                    }*/
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
    }

}