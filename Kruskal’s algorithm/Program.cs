using System;
using System.Collections.Generic;

class KruskalAlgo
{
    public class Edge
    {
        public int Src;
        public int Dest;
        public int Weight;
        public Edge(int src, int dest, int weight)
        {
            Src = src;
            Dest = dest;
            Weight = weight;
        }
    }

    class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
                parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) return;

            if (rank[rootX] < rank[rootY])
                parent[rootX] = rootY;
            else if (rank[rootX] > rank[rootY])
                parent[rootY] = rootX;
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

    public static void Kruskal(int vertices, List<Edge> edges)
    {
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

        DisjointSet ds = new DisjointSet(vertices);
        List<Edge> mst = new List<Edge>();

        foreach (Edge edge in edges)
        {
            int rootSrc = ds.Find(edge.Src);
            int rootDest = ds.Find(edge.Dest);

            if (rootSrc != rootDest)
            {
                mst.Add(edge);
                ds.Union(rootSrc, rootDest);
            }
            if (mst.Count == vertices - 1)
                break;
        }

        Console.WriteLine("Minimum Spanning Tree:\n---------------------");
        foreach (Edge edge in mst)
            Console.WriteLine($"Edge: {edge.Src} - {edge.Dest}, Weight: {edge.Weight}");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Number of Vertices and Edges (v e):");
        string[] input = Console.ReadLine().Split();
        int v = int.Parse(input[0]);
        int e = int.Parse(input[1]);

        List<Edge> edges = new List<Edge>();
        Console.WriteLine("Enter The Edge : (src dest weight)");
        for (int i = 0; i < e; i++)
        {
            string[] Inputedge = Console.ReadLine().Split();
            int src = int.Parse(Inputedge[0]);
            int dest = int.Parse(Inputedge[1]);
            int weight = int.Parse(Inputedge[2]);
            edges.Add(new Edge(src, dest, weight));
        }

        Kruskal(v, edges);
    }
}
