using System;

class Graph
{
    private int V; // number of vertices
    private int[,] adj; // adjacency matrix

    public Graph(int v)
    {
        V = v;
        adj = new int[V, V];
    }

    // function to add an edge to the graph
    public void AddEdge(int u, int v)
    {
        adj[u, v] = 1;
        adj[v, u] = 1;
    }

    // function to check if the graph is bipartite
    public bool IsBipartite()
    {
        int[] color = new int[n];
        for (int i = 0; i < n; i++)
            color[i] = -1;

        color[0] = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (graph[i, j] == 1 && color[i] == color[j])
                    return false;
            }

            if (i + 1 < n && color[i + 1] == -1)
                color[i + 1] = 1 - color[i];
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] input = new int[,] {
            {0, 1, 1, 1, 1},
            {1, 0, 0, 0, 0},
            {1, 0, 0, 0, 0},
            {1, 0, 0, 0, 0},
            {1, 0, 0, 0, 0}
        };

        Graph g = new Graph(5);
        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                if (input[i, j] == 1)
                    g.AddEdge(i, j);
            }
        }

        if (g.IsBipartite())
            Console.WriteLine("The graph is bipartite.");
        else
            Console.WriteLine("The graph is not bipartite.");
    }
}
