// реалізація графу
namespace graph
{
    internal class Graph<T>
    {
        private Dictionary<T, Dictionary<T, int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<T, Dictionary<T, int>>();
        }

        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new Dictionary<T, int>();
            }
        }

        public void AddEdge(T source, T destination, int weight = 0)
        {
            // перевірки, якщо вершина не була створена завчасно методом AddVertex, то вона створиься зараз.
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new Dictionary<T, int>();
            }

            if (!adjacencyList.ContainsKey(destination))
            {
                adjacencyList[destination] = new Dictionary<T, int>();
            }

            adjacencyList[source][destination] = weight;
            /* adjacencyList[destination][source] = weight; */ // якщо граф НЕ направлений цей рядок можна видалити або закоментувати
        }

        public void RemoveVertex(T vertex)
        {

            if (adjacencyList.ContainsKey(vertex))
            {
                foreach (var neighbor in adjacencyList)
                {
                    adjacencyList[neighbor.Key].Remove(vertex);
                }
                adjacencyList.Remove(vertex);
            }
            else
            {
                throw new KeyNotFoundException("Вершина відсутня!");
            }
        }

        public void RemoveEdge(T source, T destination)
        {
            if (adjacencyList.ContainsKey(source) && adjacencyList.ContainsKey(destination))
            {
                if (adjacencyList[source].ContainsKey(destination))
                {
                    adjacencyList[source].Remove(destination);
                }

                if (adjacencyList[destination].ContainsKey(source))
                {
                    adjacencyList[destination].Remove(source);
                }
            }
        }

        public bool ChekedPresenceVertex(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                return true;
            }
            return false;
        }

        public bool ChekedPresenceEdge(T source, T destination)
        {
            if (adjacencyList[source].ContainsKey(destination))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckingAdjacentVertices(T vertex)
        {
            Console.Write(vertex + ": ");

            foreach (var neighbor in adjacencyList[vertex])
            {
                    Console.Write(neighbor.Key + "(" + neighbor.Value + ") ");
            }

        }
        public void PrintGraph()
        {
            foreach (var vertex in adjacencyList.Keys)
            {
                Console.Write(vertex + ": ");

                foreach (var neighbor in adjacencyList[vertex])
                {
                    Console.Write(neighbor.Key + "(" + neighbor.Value + ") ");
                }

                Console.WriteLine();
            }
        }
    }
}
