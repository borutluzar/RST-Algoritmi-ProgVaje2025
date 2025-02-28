namespace RST_Algoritmi_ProgVaje2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
