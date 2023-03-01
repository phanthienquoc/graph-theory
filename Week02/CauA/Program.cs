using System;
using System.IO;

class Program
{
    static int[,] graph;
    static int n;
    static int start, goal;
    static bool[] visited;
    static int[] path;

    static void Main()
    {
        ReadDataFromFile("D:\\HCMUS\\LTDT\\Week02\\CauA\\input.txt");

        visited = new bool[n];
        path = new int[n];
        for (int i = 0; i < n; i++)
        {
            visited[i] = false;
            path[i] = -1;
        }

        DFS(start);

        if (path[goal] == -1)
        {
            Console.WriteLine("Khong co duong di");
        }
        else
        {
            int[] result = new int[n];
            int v = goal;
            int index = 0;
            while (v != start)
            {
               
                result[index] = v;
                index++;
                v = path[v];
            }
            Console.Write("Danh sach dinh duyet qua: ");
            for (int i = result.Length-1; i >= 0; i--)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Duong di tu " + start + " den " + goal + ": ");

            for (int i = 0; i < n; i++)
            {
                if (i==n-1)
                {
                    Console.Write(result[i] );
                } else
                {
                    Console.Write(result[i] + " <- ");
                }

            }
        }
    }

    static void ReadDataFromFile(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);

        // Doc so dinh
        n = int.Parse(reader.ReadLine());

        // Doc dinh bat dau va dinh ket thuc
        string[] tokens = reader.ReadLine().Split();
        start = int.Parse(tokens[0]);
        goal = int.Parse(tokens[1]);

        // Doc ma tran ke
        graph = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            tokens = reader.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = int.Parse(tokens[j]);
            }
        }


        reader.Close();
    }

    static void DFS(int u)
    {
        visited[u] = true;
        for (int v = 0; v < n; v++)
        {
            if (graph[u, v] == 1 && !visited[v])
            {
                path[v] = u;
                DFS(v);
            }
        }
    }
}


public class Graph
{
    private int n;
    private int[,] graph;

    public Graph(int[,] graph, int n)
    {
        this.n = n;
        this.graph = graph;
    }

    public List<int> BFS(int start, int goal)
    {
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        List<int> path = new List<int>();

        // Enqueue the start vertex and mark it as visited
        queue.Enqueue(start);
        visited[start] = true;

        // Repeat until the queue is empty
        while (queue.Count > 0)
        {
            // Dequeue a vertex from the queue
            int current = queue.Dequeue();

            // Add the vertex to the path
            path.Add(current);

            // If the current vertex is the goal, return the path
            if (current == goal)
            {
                return path;
            }

            // Enqueue unvisited neighbors
            for (int i = 0; i < n; i++)
            {
                if (adjacencyMatrix[current, i] == 1 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }

        // No path was found
        return null;
    }
}
