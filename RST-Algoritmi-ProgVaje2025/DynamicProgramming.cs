
namespace RST_Algoritmi_ProgVaje2025
{
    public class DynamicProgramming
    {
        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto v
        /// običajni rekurzivni funkciji.
        /// </summary>
        public static long PascalovaIdentiteta(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            return PascalovaIdentiteta(n - 1, k - 1) + PascalovaIdentiteta(n - 1, k);
        }

        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto v
        /// rekurzivni funkciji z memoizacijo.
        /// </summary>
        public static long PascalovaIdentitetaMemo(int n, int k, Dictionary<(int N, int K), long> dicStore)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            if (!dicStore.ContainsKey((n - 1, k - 1)))
            {
                dicStore[(n - 1, k - 1)] = PascalovaIdentitetaMemo(n - 1, k - 1, dicStore);
            }
            if (!dicStore.ContainsKey((n - 1, k)))
            {
                dicStore[(n - 1, k)] = PascalovaIdentitetaMemo(n - 1, k, dicStore);
            }

            return dicStore[(n - 1, k - 1)] + dicStore[(n - 1, k)];
        }

        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto s tabulacijo.
        /// </summary>
        public static long PascalovaIdentitetaTabu(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            Dictionary<(int, int), long> dicStore = new Dictionary<(int, int), long>();
            dicStore[(1, 1)] = 1;

            // Vrednosti n
            for (int i = 2; i <= n; i++)
            {
                // Diagonalne elemente zapišemo ločeno
                dicStore[(i, i)] = 1;
                // Elemente prve vrstice tudi
                dicStore[(i, 1)] = i;

                // Vrednosti k
                for (int j = 2; j <= Math.Min(i - 1, k); j++)
                {
                    dicStore[(i, j)] = dicStore[(i - 1, j - 1)] + dicStore[(i - 1, j)];
                }
            }

            return dicStore[(n, k)];
        }

        /// <summary>
        /// Computes the (weighted) distance from the start vertex to all other vertices in the graph
        /// </summary>
        public static Dictionary<int, DijkstraVertex> Dijkstra(Graph g, int startVertex)
        {
            Dictionary<int, DijkstraVertex> dicData = new Dictionary<int, DijkstraVertex>();

            // Initialize all Dijkstra objects
            foreach (var v in g.Vertices)
            {
                DijkstraVertex dObj = new DijkstraVertex(v) { Potential = int.MaxValue, TempDistance = int.MaxValue };
                dicData.Add(v, dObj);
            }

            int currentVertex = startVertex;
            dicData[currentVertex].TempDistance = 0;

            PriorityQueue<int, int> queVerts = new PriorityQueue<int, int>();
            queVerts.Enqueue(currentVertex, dicData[currentVertex].TempDistance);

            while (queVerts.Count > 0)
            {
                currentVertex = queVerts.Dequeue();
                dicData[currentVertex].Potential = dicData[currentVertex].TempDistance;

                foreach (var edge in g.IncidentEdges[currentVertex])
                {
                    int otherVertex = edge.Start == currentVertex ? edge.End : edge.Start;
                    if (dicData[otherVertex].Potential < int.MaxValue)
                        continue;

                    dicData[otherVertex].TempDistance = 
                        Math.Min(dicData[otherVertex].TempDistance, dicData[currentVertex].Potential + edge.Weight);
                    queVerts.Enqueue(otherVertex, dicData[otherVertex].TempDistance);
                }
            }

            return dicData;
        }


        public class DijkstraVertex
        {
            public DijkstraVertex(int vertex)
            {
                this.Vertex = vertex;
            }

            public int Vertex { get; }
            public int Potential { get; set; }
            public int TempDistance { get; set; }

            public override string ToString()
            {
                return $"{Vertex} - td: {TempDistance}; pt: {Potential}";
            }
        }
    }
}
