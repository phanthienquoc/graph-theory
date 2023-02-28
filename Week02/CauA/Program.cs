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
            //Console.Write("Danh sach dinh duyet qua: ");
            //for (int i = 0; i <n; i++)
            //{
            //    if (visited[i])
            //    {
            //        Console.Write(path[i] + " ");
            //    }
            //}
            //Console.WriteLine();

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