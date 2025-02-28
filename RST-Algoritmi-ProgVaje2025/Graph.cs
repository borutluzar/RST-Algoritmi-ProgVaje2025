using System.ComponentModel;

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
                        ||
                    !spanningTree.Vertices.Contains(e.Start) && spanningTree.Vertices.Contains(e.End)).ToList();

                var edgeMin = sosede.MinBy(x => x.Weight);

                spanningTree.AddEdge(edgeMin);
            }

            var weightTotal = spanningTree.Edges.Sum(x => x.Weight);

            return weightTotal;
        }

        /// <summary>
        /// Returns all connected components of a graph.
        /// </summary>
        public List<List<int>> GetConnectedComponents(bool debug = false)
        {
            List<List<int>> lstComponents = new List<List<int>>();
            HashSet<int> lstVisited = new HashSet<int>();

            foreach (int vertex in Vertices)
            {
                if (!lstVisited.Contains(vertex))
                {
                    List<int> component = new List<int>();
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(vertex); // dodamo v vrsto
                    lstVisited.Add(vertex);

                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        component.Add(current);

                        foreach (var edge in Edges)
                        {
                            if (edge.Start == current && !lstVisited.Contains(edge.End))
                            {
                                queue.Enqueue(edge.End);
                                lstVisited.Add(edge.End);
                            }
                            else if (edge.End == current && !lstVisited.Contains(edge.Start))
                            {
                                queue.Enqueue(edge.Start);
                                lstVisited.Add(edge.Start);
                            }
                        }
                    }
                    lstComponents.Add(component);
                }
            }

            if (debug)
            {
                foreach (var component in lstComponents)
                {
                    Console.WriteLine("Connected Component: " + string.Join(", ", component));
                }
            }

            return lstComponents;
        }

        public bool ContainsCycle()
        {
            var components = this.GetConnectedComponents();
            foreach (var c in components)
            {
                int stPovezav = 0;
                foreach (Edge e in this.Edges)
                {
                    if (c.Contains(e.Start))
                    {
                        stPovezav++;
                    }
                }
                if (stPovezav >= c.Count())
                {
                    return true;
                }
            }
            return false;
        }

        public int FindMinimalSpanningTreeWithKruskal()
        {
            List<Edge> povezavePoUtezeh = this.Edges.OrderBy(e => e.Weight).ToList();
            Graph tree = new Graph();
            foreach (Edge e in povezavePoUtezeh)
            {
                tree.AddEdge(e);
                if (tree.ContainsCycle())
                {
                    tree.Edges.Remove(e);
                }
            }
            int weightTotal = tree.Edges.Sum(x => x.Weight);
            return weightTotal;
        }
    }
}
