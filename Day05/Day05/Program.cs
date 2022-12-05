using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day05\Day05\input.txt");
            problema1(file);
            Console.WriteLine();
            problema2(file);
            Console.ReadKey();
        }
        static void problema1(string[] file)
        {
            // define an array of stacks
            Stack<char>[] stacks = Enumerable.Range(1, 9).Select(k => new Stack<char>()).ToArray();
            string[] auxArr = new string[9];
            int lineLeght = file[0].Length;
            int i = 0;
            for (; i < file.Length; i++)
            {
                if (file[i + 1] == "") break;
                for (int j = 1; j < lineLeght; j += 4)
                {
                    if (file[i][j] != ' ') auxArr[(j - 1) / 4] += file[i][j];
                }
            }
            // Make the stacks
            for (int j = 0; j < 9; j++)
            {
                for (int k = auxArr[j].Length - 1; k >= 0; k--)
                {
                    stacks[j].Push(auxArr[j][k]);
                }
            }
            // Jump two irrelevant lines
            i += 2;
            // This string array save the original line
            string[] lineArr;
            for (; i < file.Length; i++)
            {
                lineArr = file[i].Split(' ');
                // Move
                for (int j = 0; j < int.Parse(lineArr[1]); j++)
                {
                    char c = stacks[int.Parse(lineArr[3]) - 1].Pop();
                    stacks[int.Parse(lineArr[5]) - 1].Push(c);
                }
            }
            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek());
            }
        }
        static void problema2(string[] file)
        {
            Stack<char>[] stacks = Enumerable.Range(1, 9).Select(k => new Stack<char>()).ToArray();
            string[] auxArr = new string[9];
            int lineLeght = file[0].Length;
            int i = 0;
            for (; i < file.Length; i++)
            {
                if (file[i + 1] == "") break;
                for (int j = 1; j < lineLeght; j += 4)
                {
                    if (file[i][j] != ' ') auxArr[(j - 1) / 4] += file[i][j];
                }
            }
            // Make the stacks
            for (int j = 0; j < 9; j++)
            {
                for (int k = auxArr[j].Length - 1; k >= 0; k--)
                {
                    stacks[j].Push(auxArr[j][k]);
                }
            }
            // Jump two irrelevant lines
            i += 2;
            // This string array save the original line
            string[] lineArr;
            string boxToMove;
            for (; i < file.Length; i++)
            {
                boxToMove = "";
                lineArr = file[i].Split(' ');
                // Move
                // Load the boxes to move in the ArrayList
                for (int j = 0; j < int.Parse(lineArr[1]); j++)
                    boxToMove += stacks[int.Parse(lineArr[3]) - 1].Pop();
                // Move the boxes to the destination stack
                for (int j = boxToMove.Length - 1; j >= 0; j--)
                    stacks[int.Parse(lineArr[5]) - 1].Push((char)boxToMove[j]);
            }
            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek());
            }
        }
    }
}
