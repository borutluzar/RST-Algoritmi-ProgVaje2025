using System.Diagnostics.CodeAnalysis;

namespace RST_Algoritmi_ProgVaje2025
{
    public struct Edge
    {
        public int Start { get; }
        public int End { get; }
        public int Weight { get; set; }

        public Edge(int start, int end, int weight = 1)
        {
            Start = Math.Min(start, end);
            End = Math.Max(start, end);
            Weight = weight;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            Edge edge = (Edge)obj!;
            if (Start == edge.Start && End == edge.End)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return $"{Start}, {End} : {Weight}";
        }
    }
}
