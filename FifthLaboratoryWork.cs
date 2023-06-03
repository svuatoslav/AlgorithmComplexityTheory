using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmComplexityTheory
{
    internal class FifthLaboratoryWork
    {
        private readonly List<Dictionary<int, List<int>>> _graphs = new();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<Dictionary<Color, List<int>>> _certificates = new();
        public FifthLaboratoryWork()
        {
            Data();
            for (int i = 0; i < _graphs.Count; i++)
            {
                int maxArrayInCokor = _certificates[i].Values.Max(x => x.Count);
                int maxArrayInEdgeVertex = _graphs[i].Values.Max(x => x.Count);
                _stopwatch.Reset();
                _stopwatch.Start();
                bool result = Verifier(_graphs[i], _certificates[i]);
                _stopwatch.Stop();
                Console.WriteLine(result);
                Console.WriteLine($"Практическая сложность: {_stopwatch.ElapsedTicks} тактов");//{_stopwatch.ElapsedMilliseconds} миллисекунд {_stopwatch.ElapsedTicks} тактов
                Console.WriteLine($"Теоретическая сложность: O({_certificates[i].Count} * {maxArrayInCokor} * ({maxArrayInCokor} + {maxArrayInEdgeVertex}) = O({_certificates[i].Count * maxArrayInCokor * Math.Max(maxArrayInCokor, maxArrayInEdgeVertex)})");
            }
            Console.ReadKey();
        }
        private bool Verifier(Dictionary<int, List<int>> graph, Dictionary<Color, List<int>> certificate)
        {
            foreach (var array in certificate.Values)
                foreach (var index in array)
                    if (array.Intersect(graph[index]).Any())//O(M + N)
                        return false;
            return true;
        }
        private void Data()
        {
            Dictionary<int, List<int>> Graph;
            Dictionary<Color, List<int>> certificate;
            Graph = new Dictionary<int, List<int>>()
            {
                [0] = new List<int>() { 1, 2, 3, 4, 5, 6, 7 },
                [1] = new List<int>() { 0 },
                [2] = new List<int>() { 0 },
                [3] = new List<int>() { 0, 4 },//!!!
                [4] = new List<int>() { 0, 8 },
                [5] = new List<int>() { 5 },
                [6] = new List<int>() { 0, 8, 9 },
                [7] = new List<int>() { 0, 10, 13 },//!!!
                [8] = new List<int>() { 4, 11 },
                [9] = new List<int>() { 6 },
                [10] = new List<int>() { 11, 12, 13 },
                [11] = new List<int>() { 8, 10 },
                [12] = new List<int>() { 10 },
                [13] = new List<int>() { 10 },
            };
            _graphs.Add(Graph);
            certificate = new Dictionary<Color, List<int>>()
            {
                [Color.Red] = new List<int>() { 0, 8, 10 },
                [Color.Blue] = new List<int>() { 1, 2, 3, 4, 9, 12 },
                [Color.Green] = new List<int>() { 5, 6, 7, 11, 13 },
            };
            _certificates.Add(certificate);
            Graph = new Dictionary<int, List<int>>()
            {
                [0] = new List<int>() { 1, 4, 7, 10, 13, 19, 20 },
                [1] = new List<int>() { 2, 3 },
                [2] = new List<int>() { 1 },
                [3] = new List<int>() { 1 },
                [4] = new List<int>() { 5, 6 },
                [5] = new List<int>() { 4 },
                [6] = new List<int>() { 4 },
                [7] = new List<int>() { 8, 9 },
                [8] = new List<int>() { 7 },
                [9] = new List<int>() { 7 },
                [10] = new List<int>() { 11, 12, 14 },
                [11] = new List<int>() { 10 },
                [12] = new List<int>() { 10 },
                [13] = new List<int>() { 0 },
                [14] = new List<int>() { 10, 15, 16, 17, 21 },
                [15] = new List<int>() { 14 },
                [16] = new List<int>() { 14 },
                [17] = new List<int>() { 14 },
                [18] = new List<int>() { 19 },
                [19] = new List<int>() { 0, 14, 18 },
            };
            _graphs.Add(Graph);
            certificate = new Dictionary<Color, List<int>>()
            {
                [Color.Red] = new List<int>() { 0, 2, 5, 8, 11, 14 },
                [Color.Blue] = new List<int>() { 1, 4, 7, 10, 15, 17, 18 },
                [Color.Green] = new List<int>() { 3, 6, 9, 12, 13, 16, 19 },
            };
            _certificates.Add(certificate);
            Graph = new Dictionary<int, List<int>>()
            {
                [0] = new List<int>() { 1, 4, 7, 10, 13, 19, 20 },
                [1] = new List<int>() { 2, 3 },
                [2] = new List<int>() { 1 },
                [3] = new List<int>() { 1 },
                [4] = new List<int>() { 5, 6 },
                [5] = new List<int>() { 4 },
                [6] = new List<int>() { 4 },
                [7] = new List<int>() { 8, 9 },
                [8] = new List<int>() { 7 },
                [9] = new List<int>() { 7 },
                [10] = new List<int>() { 11, 12, 14 },
                [11] = new List<int>() { 10 },
                [12] = new List<int>() { 10 },
                [13] = new List<int>() { 0 },
                [14] = new List<int>() { 10, 15, 16, 17, 21 },
                [15] = new List<int>() { 14 },
                [16] = new List<int>() { 14 },
                [17] = new List<int>() { 14 },
                [18] = new List<int>() { 19 },
                [19] = new List<int>() { 0, 14, 18 },
                [20] = new List<int>() { 0, 22 },
                [21] = new List<int>() { 14, 22 },
                [22] = new List<int>() { 20, 21, 23, 26 },
                [23] = new List<int>() { 22, 24, 25 },
                [24] = new List<int>() { 23 },
                [25] = new List<int>() { 23 },
                [26] = new List<int>() { 22, 27, 28, 29 },
                [27] = new List<int>() { 26 },
                [28] = new List<int>() { 26 },
                [29] = new List<int>() { 26 }
            };
            _graphs.Add(Graph);
            certificate = new Dictionary<Color, List<int>>()
            {
                [Color.Red] = new List<int>() { 0, 2, 5, 8, 11, 14, 22, 27, 28, 29 },
                [Color.Blue] = new List<int>() { 1, 4, 7, 10, 15, 17, 18, 23 },
                [Color.Green] = new List<int>() { 3, 6, 9, 12, 13, 16, 19, 20, 21, 24, 25, 26 },
            };
            _certificates.Add(certificate);
            Graph = new Dictionary<int, List<int>>()
            {
                [0] = new List<int>() { 1, 4, 7, 10, 13, 19, 20 },
                [1] = new List<int>() { 2, 3 },
                [2] = new List<int>() { 1 },
                [3] = new List<int>() { 1 },
                [4] = new List<int>() { 5, 6 },
                [5] = new List<int>() { 4 },
                [6] = new List<int>() { 4 },
                [7] = new List<int>() { 8, 9 },
                [8] = new List<int>() { 7 },
                [9] = new List<int>() { 7 },
                [10] = new List<int>() { 11, 12, 14 },
                [11] = new List<int>() { 10 },
                [12] = new List<int>() { 10 },
                [13] = new List<int>() { 0 },
                [14] = new List<int>() { 10, 15, 16, 17, 21 },
                [15] = new List<int>() { 14 },
                [16] = new List<int>() { 14 },
                [17] = new List<int>() { 14 },
                [18] = new List<int>() { 19 },
                [19] = new List<int>() { 0, 14, 18 },
                [20] = new List<int>() { 0, 22 },
                [21] = new List<int>() { 14, 22 },
                [22] = new List<int>() { 20, 21, 23, 26 },
                [23] = new List<int>() { 22, 24, 25 },
                [24] = new List<int>() { 23 },
                [25] = new List<int>() { 23 },
                [26] = new List<int>() { 22, 27, 28, 29 },
                [27] = new List<int>() { 26 },
                [28] = new List<int>() { 26 },
                [29] = new List<int>() { 26 }
            };
            _graphs.Add(Graph);
            certificate = new Dictionary<Color, List<int>>()
            {
                [Color.Red] = new List<int>() { 0, 2, 5, 8, 11, 14, 22, 27, 28 },
                [Color.Blue] = new List<int>() { 1, 4, 7, 10, 15, 17, 18, 23 },
                [Color.Green] = new List<int>() { 3, 6, 9, 12, 13, 16, 19, 20, 21, 24, 25, 26, 29 },
            };
            _certificates.Add(certificate);
            Graph = new Dictionary<int, List<int>>()
            {
                [0] = new List<int>() { 1, 2, 3, 4, 5, 6, 7 },
                [1] = new List<int>() { 0 },
                [2] = new List<int>() { 0 },
                [3] = new List<int>() { 0 },
                [4] = new List<int>() { 0, 8 },
                [5] = new List<int>() { 0 },
                [6] = new List<int>() { 0, 8, 9 },
                [7] = new List<int>() { 0, 10 },
                [8] = new List<int>() { 4, 11 },
                [9] = new List<int>() { 6 },
                [10] = new List<int>() { 7, 11, 12, 13 },
                [11] = new List<int>() { 8, 10 },
                [12] = new List<int>() { 10 },
                [13] = new List<int>() { 10 },
            };
            _graphs.Add(Graph);
            certificate = new Dictionary<Color, List<int>>()
            {
                [Color.Red] = new List<int>() { 0, 11 },
                [Color.Blue] = new List<int>() { 1, 2, 3, 7, 8, 9, 12, 13 },
                [Color.Green] = new List<int>() {4, 5, 6, 10 },
            };
            _certificates.Add(certificate);
        }
        private enum Color
        {
            Red,
            Blue,
            Green
        }
    }
}
