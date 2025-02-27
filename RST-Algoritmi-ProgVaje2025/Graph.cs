namespace RST_Algoritmi_ProgVaje2025
{
    public class Graph
    {
        public HashSet<int> Vertices { get; set; } = [];
        public List<Edge> Edges { get; set; } = [];

        public Graph(int n)
        {
            Vertices = Enumerable.Range(0, n).ToHashSet();
        }

        public Graph() { }

        /// <summary>
        /// Adds an edge in the graph if it does not exists. 
        /// Otherwise it increases the weight. 
        /// </summary>
        /// <param name="e"></param>
        public void AddEdge(Edge e)
        {
            Vertices.Add(e.Start);
            Vertices.Add(e.End);

            if (!Edges.Contains(e))
                Edges.Add(e);
            else
            {
                var edgeCurrent = Edges.Where(x => x.Equals(e)).FirstOrDefault();
                edgeCurrent.Weight += e.Weight;
            }
        }

        public int FindMinimalSpanningTreeWithPrim()
        {
            int currentVertex = Vertices.First();
            Graph spanningTree = new();
            spanningTree.Vertices.Add(currentVertex);
            for (int i = 1; i < this.Vertices.Count(); i++)
            {
                List<Edge> sosede = this.Edges.Where(e =>
                spanningTree.Vertices.Contains(e.Start) && !spanningTree.Vertices.Contains(e.End)
                || !spanningTree.Vertices.Contains(e.Start) && spanningTree.Vertices.Contains(e.End)).ToList();

                var edgeMin = sosede.MinBy(x => x.Weight);

                spanningTree.AddEdge(edgeMin);
            }

            var weightTotal = spanningTree.Edges.Sum(x => x.Weight);

            return weightTotal;
        }
    }
}
