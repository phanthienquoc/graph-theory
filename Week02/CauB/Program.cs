using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static int n; // số đỉnh của đồ thị
    static int start, goal; // đỉnh nguồn và đỉnh đích
    static int[,] graph; // ma trận kề biểu diễn đồ thị
    static bool[] visited; // mảng chứa thông tin các đỉnh đã được viếng thăm

    static void Main()
    {
        ReadInputFromFile("D:\\HCMUS\\LTDT\\Week02\\CauB\\vd03.txt");
        Graph caub = new Graph(n, graph);
        List<int> path = caub.DFS(start, goal);
        if (path != null)
        {
            PrintResult(path);
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }

    static void PrintResult(List<int> result) {
        List<int> data = new List<int>();
        for(int i = result.Count-1; i >=0 ; i--)
        {
            data.Add(result[i]);
        }

        Console.WriteLine("Danh sach dinh da duyet theo thu tu: " + string.Join(" ", result));
        Console.WriteLine("Duong di in kieu nguoc: " + string.Join(" <- ", data));

    }

    static void ReadInputFromFile(string fileName)
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            n = int.Parse(sr.ReadLine());
            string[] line = sr.ReadLine().Split();
            start = int.Parse(line[0]);
            goal = int.Parse(line[1]);

            graph = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                line = sr.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    graph[i, j] = int.Parse(line[j]);
                }
            }
        }
    }
}


public class Graph
{
    private int n;
    private int[,] graph;

    public Graph( int n, int[,] graph)
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
                if (graph[current, i] == 1 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }

        // No path was found
        return null;
    }

    public List<int> DFS(int start, int goal)
    {
        bool[] visited = new bool[n];
        Stack<int> stack = new Stack<int>();
        List<int> path = new List<int>();

        // Push the start vertex onto the stack and mark it as visited
        stack.Push(start);
        visited[start] = true;

        // Repeat until the stack is empty
        while (stack.Count > 0)
        {
            // Pop a vertex from the stack
            int current = stack.Pop();

            // Add the vertex to the path
            path.Add(current);

            // If the current vertex is the goal, return the path
            if (current == goal)
            {
                return path;
            }

            // Push unvisited neighbors onto the stack
            for (int i = n - 1; i >= 0; i--)
            {
                if (graph[current, i] == 1 && !visited[i])
                {
                    stack.Push(i);
                    visited[i] = true;
                }
            }
        }

        // No path was found
        return null;
    }
}
