using System;
using System.IO;

class Program
{
    static int n; // số đỉnh của đồ thị
    static int start, goal; // đỉnh nguồn và đỉnh đích
    static int[,] graph; // ma trận kề biểu diễn đồ thị
    static bool[] visited; // mảng chứa thông tin các đỉnh đã được viếng thăm

    static void Main()
    {
        StreamReader reader = new StreamReader("D:\\HCMUS\\LTDT\\Week02\\CauB\\input.txt");
        int n = int.Parse(reader.ReadLine());
        int start, goal;

        // Đọc đỉnh nguồn và đỉnh đích
        string[] line = reader.ReadLine().Split();
        start = int.Parse(line[0]);
        goal = int.Parse(line[1]);

        // Đọc ma trận kề
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            line = reader.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }

        // Duyệt đồ thị theo chiều rộng để tìm đường đi từ start đến goal
        List<int> visited = new List<int>();
        Queue<int> queue = new Queue<int>();
        int[] parent = new int[n];
        bool[] visitedNodes = new bool[n];

        visited.Add(start);
        visitedNodes[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            for (int i = 0; i < n; i++)
            {
                if (matrix[current, i] == 1 && !visitedNodes[i])
                {
                    visited.Add(i);
                    visitedNodes[i] = true;
                    parent[i] = current;
                    queue.Enqueue(i);
                }
            }
        }

        // In ra danh sách đỉnh được viếng thăm
        Console.WriteLine("Danh sach dinh duoc vieng tham:");
        foreach (int vertex in visited)
        {
            Console.Write(vertex + " ");
        }
        Console.WriteLine();

        // In ra đường đi từ start đến goal
        if (visitedNodes[goal])
        {
            List<int> path = new List<int>();
            int current = goal;
            while (current != start)
            {
                path.Add(current);
                current = parent[current];
            }
            path.Add(start);

            Console.WriteLine("Duong di: ");
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.Write(path[i] + " ");
            }
        }
        else
        {
            Console.WriteLine("Khong co duong di");
        }

        reader.Close();
    }

    static void DFS(int v)
    {
        visited[v] = true;
        Console.Write(v + " ");

        if (v == goal)
        {
            Console.WriteLine("\nTìm thấy đường đi từ start đến goal.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (graph[v, i] == 1 && !visited[i])
            {
                DFS(i);
            }
        }
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
