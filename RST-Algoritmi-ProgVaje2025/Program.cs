using System.Diagnostics;

namespace RST_Algoritmi_ProgVaje2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ****************
            // Požrešna metoda
            /*
            Graph g = new Graph();
            g.AddEdge(new Edge(1, 2, 3));
            g.AddEdge(new Edge(1, 6, 2));
            g.AddEdge(new Edge(2, 3, 4));
            g.AddEdge(new Edge(2, 7, 1));
            g.AddEdge(new Edge(3, 4, 1));
            g.AddEdge(new Edge(3, 7, 2));
            g.AddEdge(new Edge(4, 5, 2));
            g.AddEdge(new Edge(4, 6, 3));
            g.AddEdge(new Edge(6, 7, 2));
            g.AddEdge(new Edge(6, 8, 3));
            g.AddEdge(new Edge(7, 8, 1));

            // Testiranje Primovega algoritma
            Console.WriteLine("Skupna teža po Primu: " + g.FindMinimalSpanningTreeWithPrim());
            // g.GetConnectedComponents();
            // g.ContainsCycle();
            Console.WriteLine("Skupna teža po Kruskalu: " + g.FindMinimalSpanningTreeWithKruskal()); 
            Console.Read();
            */

            // ****************
            // Dinamično programiranje
            /*
            int n = 32; //5000;
            int k = 16;  //1300;

            Console.WriteLine($"Vrednost binomskega simbola {n} nad {k} je:");

            Stopwatch swTimer = Stopwatch.StartNew();
            // Osnovno rekurzivno funkcijo moramo pri večjih vrednostih n in k zakomentirati,
            // ker ne bo uspela izračunati v realnem času
            long resultRec = DynamicProgramming.PascalovaIdentiteta(n, k);
            Console.WriteLine($"-\tz navadno rekurzijo: {resultRec} (v času: {swTimer.Elapsed.TotalSeconds:0.000})");

            swTimer.Restart();
            Dictionary<(int N, int K), long> dicStore = new();
            long resultMemo = DynamicProgramming.PascalovaIdentitetaMemo(n, k, dicStore);
            Console.WriteLine($"-\tz memoizacijo: {resultMemo} (v času: {swTimer.Elapsed.TotalSeconds:0.000})");

            swTimer.Restart();
            long resultTabu = DynamicProgramming.PascalovaIdentitetaTabu(n,k);
            Console.WriteLine($"-\ts tabulacijo: {resultTabu} (v času: {swTimer.Elapsed.TotalSeconds:0.000})");
            */

            //  Dijkstrov algoritem
            Graph g = new Graph();
            g.AddEdge(new Edge(0, 1, 1));
            g.AddEdge(new Edge(0, 2, 2));
            g.AddEdge(new Edge(1, 4, 3));
            g.AddEdge(new Edge(2, 3, 1));
            g.AddEdge(new Edge(2, 4, 1));
            g.AddEdge(new Edge(4, 3, 3));

            int start = 0;
            var results = DynamicProgramming.Dijkstra(g, start);

            Console.WriteLine($"Razdalje od vozlišča {start} so:");
            foreach (int v in results.Keys.OrderBy(x => x))
            {
                Console.WriteLine(results[v]);
            }

            Console.Read();
        }
    }
}
