using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] testfiles = {
            "D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\ibutterfly.txt",
            //"D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\ibull.txt",
            //"D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\iwagner.txt",
            //"D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\iwheel.txt",
            //"D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\istar.txt",
        };


        for (int i = 0; i < testfiles.Length; i++)
        {
            Console.WriteLine(testfiles[i]);
            Graph g = new Graph(testfiles[i]);
            Console.WriteLine();
        }
    }
}


class Graph
{
    private string fileName = "";
    static int[,] graph;
    static List<List<int>> adj = new List<List<int>>();
    static int n;
    public Graph(string inputFile)
    {
        fileName = inputFile;
        ReadDataFromFile(fileName);
        graphInfo();
    }

    public void graphInfo()
    {
        isNullGrah();
        isButterfly();
        //isBull();
        //isWagner();
        //isStar();
        //isWheel();
        //isFriendShip();
        //isBipartite();
        //isKPartite();
    }

    public void ReadDataFromFile(string fileName)
    {

        StreamReader reader = new StreamReader(fileName);
        n = int.Parse(reader.ReadLine());

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

    public void isNullGrah()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi rong: Co");
        }
        else
        {
            Console.WriteLine("Do thi rong: Khong");
        }
    }

    public void isButterfly()
    {
        int vertex4 = 0;
        int vertex2 = 0;
        for (int i = 0; i < adj.Count; i++)
        {
            if (adj[i].Count == 4)
            {
                vertex4++;
            }
            if (adj[i].Count == 2)
            {
                vertex2++;
            }
        }

        if (vertex2 == 4 & vertex4 == 1)
        {
            Console.WriteLine("Do thi hinh buom: Co");
        }
        else
        {
            Console.WriteLine("Do thi hinh buom: Khong");
        }
    }

    public void isBull()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi bo tot: Khong");
        }
        else
        {
            Console.WriteLine("Do thi bo tot: isBull");
        }
    }
    public void isWagner()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi Wagner: Khong");
        }
        else
        {
            Console.WriteLine("Do thi Wagner: isWagner");
        }

    }
    public void isStar()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi hinh sao: Khong");
        }
        else
        {
            bool isStarGraph = false;
            // Count the number of edges for each node
            int[] edgeCounts = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    edgeCounts[i] += graph[i, j];
                }
            }

            // Find the node with the maximum number of edges
            int maxEdges = edgeCounts.Max();
            int maxEdgesNode = Array.IndexOf(edgeCounts, maxEdges);

            // Check if the maxEdgesNode has edges to all other nodes
            for (int i = 0; i < n; i++)
            {
                if (i == maxEdgesNode)
                {
                    continue;
                }

                if (graph[maxEdgesNode, i] == 0)
                {
                    isStarGraph = false;
                }
            }
            if (!isStarGraph)
            {
                Console.WriteLine("Do thi hinh sao: Khong");
            }
            else
            {
                Console.WriteLine("Do thi hinh sao: Co");

            }


        }
    }
    public void isWheel()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi banh xe: Khong");
        }
        else
        {
            bool isWheel = false;
            int degreeSum = 0;
            int hubDegree = 0;
            for (int i = 0; i < n; i++)
            {
                int degree = 0;
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] == 1)
                    {
                        degree++;
                        degreeSum++;
                    }
                }
                if (degree == n - 1)
                {
                    hubDegree = degree;
                }
                else if (degree != 2)
                {
                    isWheel = false;
                }
            }
            if (!isWheel)
            {
                Console.WriteLine("Do thi banh xe: Khong");

            }
            else
            {
                isWheel = degreeSum == 2 * (n - 1) && hubDegree == n - 1;
                if (isWheel)
                {
                    Console.WriteLine("Do thi banh xe: isWheel");
                }
                else
                {
                    Console.WriteLine("Do thi banh xe: Khong");
                }
            }

            //

        }
    }
    public void isFriendShip()
    {
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi tinh ban: Khong");
        }
        else
        {
            Console.WriteLine("Do thi tinh ban: isFriendShip");
        }
    }
    public void isBipartite()
    {
        bool bipartite = false;
        if (isEmptyGraph())
        {
            Console.WriteLine("Do thi isBipartite: Khong");
        }
        else
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
                        bipartite= false;
                }

                if (i + 1 < n && color[i + 1] == -1)
                    color[i + 1] = 1 - color[i];
            }
            if (!bipartite)
            {
                Console.WriteLine("Do thi isBipartite: Khong");
            } else
            {
                Console.WriteLine("Do thi isBipartite: Co");

            }
        }
    }
    public void isKPartite()
    {
        if (isEmptyGraph())
        {

            Console.WriteLine("Do thi k-phan: Khong");
        }
        else
        {
            Console.WriteLine("Do thi k-phan: isKPartite");
        }
    }

    public bool isEmptyGraph()
    {
        return n == 0;
    }
}