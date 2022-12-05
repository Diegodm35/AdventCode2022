using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day03\Day03\input.txt");
            problema1(file);
            problema2(file);
            System.Console.ReadKey();
        }
        static void problema1(string[] file)
        {
            int midSize, sum = 0;
            foreach (string line in file)
            {
                midSize = line.Length / 2;
                string[] arr1 = new string[midSize];
                string[] arr2 = new string[midSize];
                for (int i = 0; i < midSize; i++)
                {
                    arr1[i] = line[i].ToString();
                    arr2[i] = line[i + midSize].ToString();
                }
                string[] intersectArr = arr1.Intersect(arr2).ToArray();
                char match = intersectArr[0].ToCharArray()[0];
                if (char.IsUpper(match)) sum += match - 38;
                else sum += match - 96;            
            }
            System.Console.WriteLine(sum);
        }
        static void problema2(string[] file)
        {
            string arr1, arr2, arr3;
            int sum = 0;
            char match;
            for (int i = 0; i < file.Length; i = i + 3)
            {
                arr1 = file[i];
                arr2 = file[i + 1];
                arr3 = file[i + 2];
                match = arr1.Intersect(arr2).Intersect(arr3).ToArray()[0];
                if (char.IsUpper(match)) sum += match - 38;
                else sum += match - 96;
            }
            System.Console.WriteLine(sum);
        }
    }
}
