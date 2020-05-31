using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LabRab_7
{
    class rational_number : IComparable<rational_number>, IEquatable<rational_number>
    {
        private readonly long N;
        private readonly long M;

        private static long FindGCD(long A, long B)
        {
            A = Math.Abs(A);
            B = Math.Abs(B);
            if (A == 0) return B;
            else if (B == 0) return A;
            else if (A == B) return A;
            else if (A == 1 || B == 1) return 1;
            else if ((A % 2 == 0) && (B % 2 == 0)) return 2 * FindGCD(A / 2, B / 2);
            else if ((a % 2 == 0) && (b % 2 != 0)) return FindGCD(A / 2, B);
            else if ((A % 2 != 0) && (B % 2 == 0)) return FindGCD(A, B / 2);
            else return FindGCD(B, (int)Math.Abs(A - B));
        }

        public rational_number(long _n, long _m)
        {     
            long GCD = FindGCD(_n, _m);
            N = _n / GCD;
            M = _m / GCD;
        }

        public int CompareTo(rational_number Num2)
        {
            if ((double)this > (double)Num2)
                return 1;
            else if ((double)this < (double)Num2)
                return -1;
            else
                return 0;
        }

        public int CompareTo(object other)
        {
            if (other is rational_number)
                return CompareTo((rational_number)other);
            else
                throw new InvalidOperationException("CompareTo: not a rational number");
        }

        public override bool Equals(object other)
        {
            if(other == null)
            {
                return false;
            }
            if(other is rational_number)
            {
                return Equals((rational_number)other);
            }
            return false;
        }

        public bool Equals(rational_number other)
        {
            if (other == null)
                return false;
            else
                return (N == other.N && M == other.M);
        }

        public override int GetHashCode()
        {
            return (int)(N*17 + M);
        }

        public static rational_number operator +(rational_number Num1, rational_number Num2)
        {
            long MmGCD = FindGCD(Num1.M, Num2.M);
            long NewN = Num1.N * (Num2.M / MmGCD) + Num2.N * (Num1.M / MmGCD);
            long NewM = Num1.M * (Num2.M / MmGCD);
            return new rational_number(NewN, NewM);
        }

        public static rational_number operator -(rational_number Num1, rational_number Num2)
        {
            long MmGCD = FindGCD(Num1.M, Num2.M);
            long NewN = Num1.N * (Num2.M / MmGCD) - Num2.N * (Num1.M / MmGCD);
            long NewM = Num1.M * (Num2.M / MmGCD);
            return new rational_number(NewN, NewM);
        }

        public static rational_number operator *(rational_number Num1, rational_number Num2)
        {
            long NewN = Num1.N * Num2.N;
            long NewM = Num1.M * Num2.M;
            return new rational_number(NewN, NewM);
        }

        public static rational_number operator /(rational_number Num1, rational_number Num2)
        {
            long NewN = Num1.N / Num2.N;
            long NewM = Num1.M / Num2.M;
            return new rational_number(NewN, NewM);
        }

        public static bool operator <(rational_number Num1, rational_number Num2)
        {
            return Num1.CompareTo(Num2) < 0;
        }

        public static bool operator >(rational_number Num1, rational_number Num2)
        {
            return Num1.CompareTo(Num2) > 0;
        }

        public static bool operator <=(rational_number Num1, rational_number Num2)
        {
            return Num1.CompareTo(Num2) <= 0;
        }

        public static bool operator >=(rational_number Num1, rational_number Num2)
        {
            return Num1.CompareTo(Num2) >= 0;
        }

        public static explicit operator long(rational_number Num)
        {
            return Num.n / Num.m;
        }

        public static explicit operator double(rational_number Num)
        {
            return (double)Num.n / Num.m;
        }

        // public string RationalToString()
        // {
        //     string Str = $"{n}/{m}";
        //     return Str;
        // }

        public override string ToString()
        {
            string Str = $"{n}/{m}";
            return Str;   
        }

        public string RationalToStringDouble()
        {
            string Str = $"{(double)n/m)}";
            return Str;
        }

        public static rational_number StringToRational(string Str)
        {
            string Pattern1 = @"^\d{1,9}\s*\/\s*\d{1,9}$";
            string Pattern2 = @"^\d{1,9}\s*\.\s*\d{1,9}$";
            if (Regex.IsMatch(Str, Pattern1))
            {

                string[] Numbers = Str.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                long N = long.Parse(Numbers[0]);
                long M = long.Parse(Numbers[1]);
                if (M == 0)
                {
                    Console.WriteLine("The denominator cannot be equal to zero");
                    return null;
                }
                else
                {
                    return new rational_number(N, M);
                }
            }
            else if (Regex.IsMatch(Str, Pattern2))
            {
                string[] Numbers = Str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                long N = long.Parse(Numbers[0] + Numbers[1]);
                long M = (long)Math.Pow(10, Numbers[1].Length);
                if (M == 0)
                {
                    Console.WriteLine("The denominator cannot be equal to zero");
                    return null;
                }
                else
                {
                    return new rational_number(N, M);
                }
            }
            else
            {
                return null;
            }
        }
    }
}