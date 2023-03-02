using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

class Graph
{
    static List<List<int>> adj = new List<List<int>>();

    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("D:\\HCMUS\\LTDT\\DA01\\Testcode\\ibutterfly.txt");
        int n = int.Parse(reader.ReadLine());
        Console.WriteLine(n);

        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>());
            string[] s = reader.ReadLine().Split(" ");
            for (int k = 0; k < s.Length; k++)
            {
                adj[i].Add(int.Parse(s[k]));
            }
        }

        reader.Close();


    }

   
}
