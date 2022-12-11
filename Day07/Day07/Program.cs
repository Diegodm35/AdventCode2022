using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day07\Day07\input.txt");
            problema1(file);
            Console.WriteLine();
            problema2(file);
            Console.ReadKey();
        }

        private static void problema1(string[] file)
        {
            IDictionary<string, List<string>> dirTree = new Dictionary<string, List<string>>();
            string key = "";
            string[] lineArr;
            // Crear el arbol de directorios
            foreach (string line in file)
            {
                lineArr = line.Split(' ');
                if (lineArr.Contains(".."))
                {
                    continue;
                }
                else if (lineArr.Contains("cd"))
                {
                    key = lineArr[2];
                    dirTree.Add(key, new List<string>() { "0" });
                }
                else if (!lineArr.Contains("ls"))
                {
                    if (lineArr[0].Equals("dir"))
                    {
                        dirTree[key].Add(lineArr[1]);
                    }
                    else
                    {
                        dirTree[key][0] = (int.Parse(dirTree[key][0]) + int.Parse(lineArr[0])).ToString();
                    }
                }
            }
            string subDir, subDirTam;
            // Si tiene subdirectorios hay que sumarle el tamaño
            foreach (var i in dirTree)
            {
                if(i.Value.Count() > 1)
                {
                    for (int j = 1; j < i.Value.Count;j++)
                    {
                        subDir = i.Value[j];
                        subDirTam = dirTree[subDir][0];
                        i.Value[0] = (int.Parse(i.Value[0]) + int.Parse(subDirTam)).ToString();
                    }
                }
            }
            int sum = 0;
            foreach (var i in dirTree)
            {
                if (int.Parse(i.Value[0]) < 100000)
                {
                    sum += int.Parse(i.Value[0]);
                }
            }
            Console.WriteLine(sum);
        }


        //private static void problema1(string[] file)
        //{
        //    string[] fileMatrix = file.Select(x => x.Split(' ')[0]).ToArray();
        //    int sum = 0;
        //    List<int> dirSize = new List<int>();
        //    foreach (string i in fileMatrix)
        //    {
        //        if (i == "$")
        //        {
        //            if (sum <= 100000)
        //            {
        //                dirSize.Add(sum);
        //            }
        //            sum = 0;
        //        }
        //        if (int.TryParse(i, out int number))
        //        {
        //            sum += number;
        //        }
        //    }
        //    // Last sum is not checked
        //    if (sum <= 100000)
        //        dirSize.Add(sum);
        //    Console.WriteLine(dirSize.Sum());
        //}

        private static void problema2(string[] file)
        {

        }
    }
}
