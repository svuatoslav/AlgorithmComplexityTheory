using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmComplexityTheory
{
    internal sealed class FourthLaboratoryWork : LaboratoryWorksGraphs
    {
        private readonly List<Vertex[]> _graphs = new();
        private readonly Queue<Vertex> _queue = new();
        private readonly Stopwatch stopwatch;
        private sealed class Vertex
        {
            readonly internal int[] IndexVertexes = null;
            readonly internal bool End = false;
            internal bool Marked = false;
            public Vertex(int[] indexVertexes, bool end)
            {
                IndexVertexes = indexVertexes;
                End = end;
            }
        }
        public FourthLaboratoryWork(int start_node, int goal_node, int k)
        {
            //var Vertexes = new Vertex[1000000];
            //Vertexes[0] = new Vertex(new int[] { 1 }, false);
            //for (int i = 1; i < Vertexes.Length - 1; i++)
            //        Vertexes[i] = new Vertex(new int[] { i - 1, i + 1 }, false);
            //Vertexes[Vertexes.Length - 1] = new Vertex(new int[] { Vertexes.Length - 2 }, true);
            //_graphs.Add(Vertexes);
            int[] test = new int[] { 10000, 1000 };
            int mnEdgeForVertex = 2;
            Tests(test, mnEdgeForVertex);
            stopwatch = new Stopwatch();
            foreach (var graph in _graphs)
            {
                stopwatch.Start();
                bool result = BFS(start_node, k, graph);
                stopwatch.Stop();
                _queue.Clear();
                int edge = 0;
                for (int i = 0; i < graph.Length; i++)
                    foreach (var indexVertex in graph[i].IndexVertexes)
                        if (i < indexVertex)
                            edge++;
                Console.WriteLine(result);
                Console.WriteLine($"Практическая сложность: {stopwatch.ElapsedTicks} тактов");//{stopwatch.ElapsedMilliseconds} миллисекунд {stopwatch.ElapsedTicks} тактов
                //Console.WriteLine($"Теоретическая сложность: {graph.Length} вершин + {edge} ребер = O({graph.Length + edge})");
                Console.WriteLine($"Теоретическая сложность: {graph.Length} вершин + {edge} ребер = O({Math.Max(graph.Length, edge)})");
                stopwatch.Reset();
            }
            Console.ReadKey();
        }
        private bool BFS(int start_node, int k, Vertex[] Vertexes)
        {
            int start = k;
            int level = Vertexes[start_node].IndexVertexes.Length;
            _queue.Enqueue(Vertexes[start_node]);
            Vertexes[start_node].Marked = true;
            while (_queue.Count != 0)
            {
                if (k == 0)
                    break;
                var node = _queue.Dequeue();
                if (node.End)
                {
                    Console.WriteLine($"{start - k} шагов");
                    return true;
                }
                foreach (var child in node.IndexVertexes)
                    if (Vertexes[child].Marked == false)
                    {
                        _queue.Enqueue(Vertexes[child]);
                        Vertexes[child].Marked = true;
                    }
                if (level == 0)
                {
                    k--;
                    level = _queue.Count - 1;
                }
                else
                    level--;
            }
            Console.WriteLine($"{start - k} шагов");
            return false;
        }
        private void Tests(int[] numberVertices, int minEdgeForVertex)
        {
            Random random = new Random();
            for (int i = 0; i != numberVertices.Length; i++)
            {
                //int goal_node = random.Next(numberVertices[i] / 2, numberVertices[i]);
                int goal_node = numberVertices[i] - 1;
                var graph = new Vertex[numberVertices[i]];
                var Graph = new Dictionary<int, int[]>();

                int numberIndexVertex = random.Next(1, minEdgeForVertex + 1);
                var indexVerteces = new int[numberIndexVertex];
                for (int j = 0; j < numberIndexVertex; j++)
                {
                    //var number =  random.Next(1, numberVertices[i]);
                    var number = random.Next(1, 1 + numberVertices[i] / (numberVertices[i] / 2));
                    if (indexVerteces.Contains(number))
                    {
                        j--;
                        continue;
                    }
                    indexVerteces[j] = number;
                }
                Array.Sort(indexVerteces);
                Graph.Add(0, indexVerteces);

                List<int> indexVertec = new();
                for (int j = 1; j < numberVertices[i]; j++)
                {
                    numberIndexVertex = random.Next(1, minEdgeForVertex + 1);
                    if(numberVertices[i] - j <= numberIndexVertex)
                        numberIndexVertex = 1;
                    for (int k = 0; k < Graph.Count; k++)
                        if (Graph[k].Contains(j))// из предыдущих 
                            indexVertec.Add(k);
                    if (j < numberVertices[i] - 1)
                    {
                        //indexVertec.Add(random.Next(j + 1, numberVertices[i]));//для связности
                        if ((j + 1) + numberVertices[i] / (numberVertices[i] / 2) < numberVertices[i])
                            indexVertec.Add(random.Next(j + 1, (j + 1) + numberVertices[i] / (numberVertices[i] / 2)));
                        else
                            indexVertec.Add(random.Next(j + 1, numberVertices[i]));
                        for (int k = indexVertec.Count, number; k < numberIndexVertex; k++)// новые связи
                        {
                            //number = random.Next(j + 1, numberVertices[i]);
                            if ((j + 1) + numberVertices[i] / (numberVertices[i] / 2) < numberVertices[i])
                                number = random.Next(j + 1, (j + 1) + numberVertices[i] / (numberVertices[i] / 2));
                            else
                                number = random.Next(j + 1, numberVertices[i]);
                            if (indexVertec.Contains(number))
                            {
                                k--;
                                continue;
                            }
                            indexVertec.Add(number);
                        }
                    }
                    indexVertec.Sort();
                    indexVerteces = new int[indexVertec.Count];
                    indexVertec.CopyTo(indexVerteces);
                    Graph.Add(j, indexVerteces);
                    indexVertec.Clear();
                }
                foreach (var v in Graph)
                    if (v.Key != goal_node)
                        graph[v.Key] = new Vertex(v.Value, false);
                    else
                        graph[v.Key] = new Vertex(v.Value, true);
                _graphs.Add(graph);
            }
        }
    }
}