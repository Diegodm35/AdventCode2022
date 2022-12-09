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
        }

        
        static void problema1(string[] file)
        {
            // Se convertira cada valor a int y se sumara a un acumulador
            // Si el valor no se puede parsear
            // comparar con este valor con el valor maximo y guardar el mayor
            // reiniciar el acumulador
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
            System.Console.WriteLine("Suma: " + maxSum);
            System.Console.ReadKey();
        }
        private static void problema2(string[] file)
        {
            // Se convertira cada valor a int y se sumara a un acumulador
            // Si el valor no se puede parsear
            // guardar el valor en un array
            // reiniciar el acumulador
            // Ordenar
            int sum = 0;
            var sumList = new List<int>();
            int index = 0;
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
                    index++;
                }
            }
            sumList.Sort();
            // sum the 3 last elements of an arraylist 
            // 
            int sumMax = sumList.Skip(Math.Max(0, sumList.Count() - 3)).Take(3).Sum();
            System.Console.WriteLine("Suma: " + sumMax);
            System.Console.ReadKey();
        }
    }
}
