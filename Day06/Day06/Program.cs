using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day06\Day06\input.txt");
            problema1(file);
            Console.WriteLine();
            problema2(file);
            Console.ReadKey();
        }
        static void problema1(string[] file)
        {
            Queue<char> queue = new Queue<char>();
            int index = 0;
            foreach (char i in file[0])
            {
                if (queue.Count() < 4)
                {
                    queue.Enqueue(i);
                }
                else
                {
                    if (queue.Distinct().Count() == queue.Count())
                    {
                        break;
                    }
                    queue.Dequeue();
                    queue.Enqueue(i);
                }
                index++;
            }
            Console.WriteLine(index);
        }
        static void problema2(string[] file)
        {
            Queue<char> queue = new Queue<char>();
            int index = 0;
            foreach (char i in file[0])
            {
                if (queue.Count() < 14)
                {
                    queue.Enqueue(i);
                }
                else
                {
                    if (queue.Distinct().Count() == queue.Count())
                    {
                        break;
                    }
                    queue.Dequeue();
                    queue.Enqueue(i);
                }
                index++;
            }
            Console.WriteLine(index);
        }
    }
}
