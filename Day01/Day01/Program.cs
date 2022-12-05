using System;
using System.Collections;
using System.Collections.Generic;
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
            problema1();
            problema2();
        }

        private static void problema2()
        {
            // Guardar en un array cada valor
            string[] filePath = System.IO.File.ReadAllLines("C:\\Users\\Diegodm\\Projects\\AdventCode2022\\Day01\\Day01\\input.txt");
            // Se convertira cada valor a int y se sumara a un acumulador
            // Si el valor no se puede parsear
            // guardar el valor en un array
            // reiniciar el acumulador
            // Ordenar
            int sum = 0;
            var sumList = new ArrayList();
            int index = 0;
            foreach (var item in filePath)
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
            int sumMax = (int)sumList[--index] + (int)sumList[--index] + (int)sumList[--index];
            System.Console.WriteLine("Suma: " + sumMax);
            System.Console.ReadKey();
        }

        static void problema1()
        {
            // Guardar en un array cada valor
            string[] filePath = System.IO.File.ReadAllLines("C:\\Users\\Diegodm\\Projects\\AdventCode2022\\Day01\\Day01\\input.txt");
            // Se convertira cada valor a int y se sumara a un acumulador
            // Si el valor no se puede parsear
            // comparar con este valor con el valor maximo y guardar el mayor
            // reiniciar el acumulador
            int sum = 0;
            int maxSum = 0;
            foreach (var item in filePath)
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
    }
}
