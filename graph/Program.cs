using graph;

public class Program
{
    public static void Main()
    {
        Graph graph = new Graph();

        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddVertex(5);

        graph.AddEdge(1, 2, 5);
        graph.AddEdge(1, 3, 3);
        graph.AddEdge(2, 4, 9);
        graph.AddEdge(3, 4, 11);
        graph.AddEdge(4, 5, 13);

        graph.PrintGraph();
    }
}