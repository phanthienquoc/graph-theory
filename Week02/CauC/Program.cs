using System;
using System.IO;

class Program
{
    static int N, M;
    static int[,] a;
    static bool[,] visited;

    static void Main()
    {
        // Đọc dữ liệu từ file BITMAP.INP
        using (var reader = new StreamReader("D:\\HCMUS\\LTDT\\Week02\\CauC\\BITMAP.INP"))
        {
            var nm = reader.ReadLine().Split();
            N = int.Parse(nm[0]);
            M = int.Parse(nm[1]);

            a = new int[N, M];
            visited = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                var row = reader.ReadLine().Split();
                for (int j = 0; j < M; j++)
                {
                    a[i, j] = int.Parse(row[j]);
                }
            }
        }

        int count = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (a[i, j] == 1 && !visited[i, j])
                {
                    count++;
                    DFS(i, j);
                }
            }
        }

        // Ghi kết quả ra file BITMAP.OUT
        using (var writer = new StreamWriter("D:\\HCMUS\\LTDT\\Week02\\CauC\\BITMAP.OUT"))
        {
            writer.Write(count);
        }
    }

    static void DFS(int x, int y)
    {
        visited[x, y] = true;

        // Kiểm tra các ô kề cạnh
        if (x > 0 && a[x - 1, y] == 1 && !visited[x - 1, y])
        {
            DFS(x - 1, y);
        }
        if (x < N - 1 && a[x + 1, y] == 1 && !visited[x + 1, y])
        {
            DFS(x + 1, y);
        }
        if (y > 0 && a[x, y - 1] == 1 && !visited[x, y - 1])
        {
            DFS(x, y - 1);
        }
        if (y < M - 1 && a[x, y + 1] == 1 && !visited[x, y + 1])
        {
            DFS(x, y + 1);
        }
    }
}