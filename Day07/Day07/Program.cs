using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\Diegodm\Projects\AdventCode2022\Day07\Day07\test1.txt");
            problema1(file);
            Console.WriteLine();
            problema2(file);
            Console.ReadKey();
        }


        private static void problema1(string[] file)
        {
            Graph graph = new Graph();
            Node parentNode = new Node("");
            foreach (string line in file)
            {
                string[] lineArr= line.Split(' ');
                Node node;
                if (lineArr.Contains(".."))
                {
                    parentNode = parentNode.Parent;
                }
                else if (lineArr[1].Equals("cd"))
                {
                    node = new Node(lineArr[2], parentNode);
                    graph.AddNode(node);
                    parentNode.AddChild(node);
                    parentNode = node;
                }
                else if (!lineArr[1].Equals("ls"))
                {
                    // nodos hoja (ficheros)
                    if (int.TryParse(lineArr[0], out int tam))
                    {
                        node = new Node(lineArr[1], parentNode, tam);
                        parentNode.AddChild(node);
                        graph.AddNode(node);
                    }
                }
            }
            Console.WriteLine(graph.ToString());
            graph.SumSubDirectories();
            Console.WriteLine(graph.ToString());
        }

        private static void problema2(string[] file)
        {

        }
    }
    internal class Graph
    {
        private List<Node> Nodes = new List<Node>();
        public void AddNode(Node node)
        {
            Nodes.Add(node); 
        }
        public override string ToString()
        {
            string result = "";
            foreach (Node node in Nodes)
            {
                result += node.ToString() + "\n";
            }
            return result;
        }

        internal void SumSubDirectories()
        {
            foreach (Node node in Nodes)
            {
                _ = node.SumSubDirectories();
            }
        }
    }
    internal class Node
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }
        public Node(string name, Node parent = null, int weight = 0)
        {
            Name = name;
            Weight = weight;
            Children = new List<Node>();
            Parent = parent;
        }
        public void AddChild(Node child)
        {
            Children.Add(child);
        }
        public override string ToString()
        {
            return Name + ": " + Weight + " Childs: " + Children.Count + " Parent: " + Parent?.Name;
        }

        internal int SumSubDirectories()
        {
            int sum = Weight;
            foreach (Node node in Children)
            {
                sum += node.SumSubDirectories();
            }
            this.Weight = sum;
            return sum;
        }
    }
}
