// реалізація графу
namespace graph
{ 
    internal class Graph 
    {
        private Dictionary<int, Dictionary<int,int >> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, Dictionary<int,int >>();
        }

        public void AddVertex(int vertex)
        {
            if(!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new Dictionary<int, int>();
            }
        }

        public void AddEdge(int source, int destination, int weight = 0)
        {
            // перевірки, якщо вершина не була створена завчасно методом AddVertex, то вона створиься зараз.
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new Dictionary<int, int>();
            }

            if (!adjacencyList.ContainsKey(destination))
            {
                adjacencyList[destination] = new Dictionary<int, int>();
            }

            adjacencyList[source][destination] = weight;
            /* adjacencyList[destination][source] = weight; */ // якщо граф НЕ направлений цей рядок можна видалити або закоментувати
        }

        public void PrintGraph()
        {
            foreach (var vertex in adjacencyList.Keys)
            {
                Console.Write(vertex + ": ");

                foreach (var neighbor in adjacencyList[vertex])
                {
                    Console.Write(neighbor.Key + "(" + neighbor.Value + ")" );
                }

                Console.WriteLine();
            }
        }
    }
}
