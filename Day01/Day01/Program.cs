using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines("C:\\Users\\Diegodm\\Projects\\AdventCode2022\\Day01\\Day01\\input.txt");
            problema1(file);
            problema2(file);
            Console.ReadKey();
        }

        
        static void problema1(string[] file)
        {
            int sum = 0;
            int maxSum = 0;
            foreach (var item in file)
            {
                int number;
                if (int.TryParse(item, out number))
                {
                    sum += number;
                }
                else
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                    sum = 0;
                }
            }
            Console.WriteLine("Suma: " + maxSum);
        }
        private static void problema2(string[] file)
        {
            int sum = 0;
            var sumList = new List<int>();
            foreach (var item in file)
            {
                int number;
                if (int.TryParse(item, out number))
                {
                    sum += number;
                }
                else
                {
                    sumList.Add(sum);
                    sum = 0;
                }
            }
            sumList.Sort();
            int sumMax = sumList.Skip(Math.Max(0, sumList.Count() - 3)).Sum();
            Console.WriteLine("Suma: " + sumMax);
        }
    }
}
