﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LabRab_7
{
    class Program
    {
        static void Calculate()
        {
            Console.Write("Input first number: ");
            rational_number Num1 = rational_number.StringToRational(Console.ReadLine());
            Console.Write("Input second number: ");
            rational_number Num2 = rational_number.StringToRational(Console.ReadLine());
            if(Num1 == null || Num2 == null)
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            else
            {
                rational_number a = Num1 + Num2;
                Console.WriteLine($"Addiction: {(int)(Num1 + Num2)} or {(double)(Num1 + Num2)} or {(Num1 + Num2).ToString()}");
                Console.WriteLine($"Subtraction: {(int)(Num1 - Num2)} or {(double)(Num1 - Num2)} or {(Num1 - Num2).ToString()}");
                Console.WriteLine($"Multiplication: {(int)(Num1 * Num2)} or {(double)(Num1 * Num2)} or {(Num1 * Num2).ToString()}");
                Console.WriteLine($"Division: {(int)(Num1 / Num2)} or {(double)(Num1 / Num2)} or {(Num1 / Num2).ToString()}");
                Console.WriteLine($"Comparison:");
                Console.WriteLine($"{Num1.ToString()} < {Num2.ToString()} --- {Num1 < Num2}");
                Console.WriteLine($"{Num1.ToString()} > {Num2.ToString()} --- {Num1 > Num2}");
                Console.WriteLine($"{Num1.ToString()} <= {Num2.ToString()} --- {Num1 <= Num2}");
                Console.WriteLine($"{Num1.ToString()} >= {Num2.ToString()} --- {Num1 >= Num2}");
                Console.WriteLine($"{Num1.ToString()} == {Num2.ToString()} --- {Num1.Equals(Num2)}");
                Console.WriteLine($"{Num1.ToString()} != {Num2.ToString()} --- {!Num1.Equals(Num2)}");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            int Choice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Input two rational numbers and show all operation");
                Console.WriteLine("2. Exit");
                Console.WriteLine("Input your choice: ");
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.Clear();
                        Calculate();
                        break;
                    case 2:
                        return;
                }
            } while (Choice != 2);
        }
    }
}