using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day04\Day04\input.txt");
            problema1(file);
            problema2(file);
            Console.ReadKey();
        }
        static void problema1(string[] file)
        {
            int sum = 0;
            int diff;
            foreach (string line in file)
            {
                // Convert the input line into an integer array that has the 4 key values
                int[] ranges = Array.ConvertAll(line.Split(',', '-'), s => int.Parse(s));
                // The only way one elf completly overlap the other is when the difference of the start and end of each
                // other is equal or less than 0
                diff = (ranges[0] - ranges[2]) * (ranges[1] - ranges[3]);
                if (diff <= 0) sum++;
            }
            Console.WriteLine(sum);
        }
        static void problema2(string[] file)
        {
            int sum = 0;
            foreach (string line in file)
            {
                // Convert the input line into an integer array that has the 4 key values
                int[] ranges = Array.ConvertAll(line.Split(',', '-'), s => int.Parse(s));
                // The only way one elf overlap the other is when one of then starts before the other ends
                // If elf 1 starts after elf 2 starts but before elf 2 ends
                if (ranges[0] >= ranges[2] && ranges[0] <= ranges[3]) sum++;
                // Or if elf 2 starts after elf 1 starts but before elf 1 ends
                else if (ranges[2] >= ranges[0] && ranges[2] <= ranges[1]) sum++;
            }
            Console.WriteLine(sum);
        }
    }
}
