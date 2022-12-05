using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Program
    {
        // Rock = X, A  1
        // Paper = Y, B  2
        // Scissor = Z, C  3
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day02\Day02\input.txt");
            problema1(file);
            problema2(file);
            System.Console.ReadKey();
        }
        static void problema1(string[] file)
        {
            int sum = 0;
            foreach (string line in file)
            {
                string[] lineSplit = line.Split(' ');
                // Rock
                if (lineSplit[1] == "X")
                {
                    sum += 1;
                    if (lineSplit[0] == "C") sum += 6;
                    else if (lineSplit[0] == "A") sum += 3;
                }
                // Paper
                else if (lineSplit[1] == "Y")
                {
                    sum += 2;
                    if (lineSplit[0] == "A") sum += 6;
                    else if (lineSplit[0] == "B") sum += 3;
                }
                // Scissors
                else if (lineSplit[1] == "Z")
                {
                    sum += 3;
                    if (lineSplit[0] == "B") sum += 6;
                    else if (lineSplit[0] == "C") sum += 3;
                }
            }
            System.Console.WriteLine(sum);
        }
        static void problema2(string[] file)
        {
            int sum = 0;
            foreach (string line in file)
            {
                string[] lineSplit = line.Split(' ');
                // Lose
                if (lineSplit[1] == "X")
                {
                    if (lineSplit[0] == "A") sum += 3;
                    else if (lineSplit[0] == "B") sum += 1;
                    else if (lineSplit[0] == "C") sum += 2;
                }
                // Draw
                else if (lineSplit[1] == "Y")
                {
                    sum += 3;
                    if (lineSplit[0] == "A") sum += 1;
                    else if (lineSplit[0] == "B") sum += 2;
                    else if (lineSplit[0] == "C") sum += 3;
                }
                // Win
                else if (lineSplit[1] == "Z")
                {
                    sum += 6;
                    if (lineSplit[0] == "A") sum += 2;
                    else if (lineSplit[0] == "B") sum += 3;
                    else if (lineSplit[0] == "C") sum += 1;
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
