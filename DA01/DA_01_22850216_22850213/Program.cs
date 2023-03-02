using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] testfiles = {
            "D:\\PhanThienQuoc\\graph-theory\\DA01\\DA_01_22850216_22850213\\ibutterfly.txt",
            "D:\\PhanThienQuoc\\graph-theory\\DA01\\DA_01_22850216_22850213\\ibull.txt",
            //"D:\\HCMUS\\LTDT\\DA01\\DA_01_22850216_22850213\\iwagner.txt",
            "D:\\PhanThienQuoc\\graph-theory\\DA01\\DA_01_22850216_22850213\\iwheel.txt",
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
    public int[,] graph;
    public List<List<int>> adj = new List<List<int>>();
    public int n;
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
        isBull();
        //isWagner();
        //isStar();
        isWheel();
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

            //Console.WriteLine(string.Join(" ", adj[i]));

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
        if (isEmptyGraph() || n != 5)
        {
            Console.WriteLine("Do thi bo tot: Khong");
        }
        else
        {
            bool hasC3Loop = false;
            int vertices1 = 0;
            int vertices3 = 0;
            int vertex2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (adj[i].Count == 1)
                {
                    vertices1++;
                }
                if (adj[i].Count == 2)
                {
                    vertex2++;
                }
                if (adj[i].Count == 3)
                {
                    vertices3++;
                }
            }



            // Loop through every pair of vertices
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < adj[i].Count; j++)
                {
                    // If vertices i and j are adjacent, check if there is a third vertex adjacent to both i and j
                    if (adj[i].Contains(j + 1))
                    {
                        foreach (int k in adj[i])
                        {
                            if (k != j + 1 && adj[j].Contains(k) && k != i + 1)
                            {
                                hasC3Loop = true;
                            }
                        }
                    }
                }
            }


            if (vertices1 == 2 & vertices3 == 2 & vertex2 == 1 )
            {
                Console.WriteLine("Do thi bo tot: Co");
            }
            else
            {
                Console.WriteLine("Do thi bo tot: Khong");
            }
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
            bool isWheelGraph = false;
            int degreeOfHub = 0;

            // Kiểm tra xem có chính xác một đỉnh có bậc là n-1 hay không
            for (int i = 0; i < n; i++)
            {
                if (adj[i].Count ==n - 1)
                {
                    degreeOfHub = i;
                }
                else if (adj[i].Count != 3)
                {
                    isWheelGraph = false;
                }
            }

            // Kiểm tra xem tất cả các đỉnh trong chu trình có kết nối với hub hay không
            for (int i = 0; i < n; i++)
            {
                if (i != degreeOfHub && adj[i].Count != 2)
                {
                    if (!adj[i].Contains(degreeOfHub))
                    {
                        isWheelGraph = false;
                    }

                }
            }

            if(isWheelGraph) 
            { 
                Console.WriteLine("Do thi banh xe: Co");
            } else
            {
                Console.WriteLine("Do thi banh xe: Khong");
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