using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6);
            graph.adj[0].Add(1);
            graph.adj[0].Add(2);
            graph.adj[0].Add(3);

            graph.adj[1].Add(0);
            graph.adj[1].Add(3);
            graph.adj[1].Add(4);

            graph.adj[2].Add(0);

            graph.adj[3].Add(0);
            graph.adj[3].Add(1);
            graph.adj[3].Add(4);
            graph.adj[3].Add(5);

            graph.adj[4].Add(1);
            graph.adj[4].Add(3);
            graph.adj[4].Add(5);

            graph.adj[5].Add(3);
            graph.adj[5].Add(4);

            Console.WriteLine("DFS:");
            dfs(graph, 0, new bool[graph.size]);
            Console.WriteLine("BFS");
            bfs(graph, 0);
        }

        //vertex of graph
        public class Vertex
        {
            public int val;
            public Vertex(int val)
            {
                this.val = val;
            }
        }

        //Graph class, with adjacency list
        public class Graph
        {
            public readonly int size;
            public readonly Vertex[] vertexes;
            public List<int>[] adj;

            public Graph(int size)
            {
                this.size = size;
                //initialize vertex and adjacency list
                vertexes = new Vertex[size];
                adj = new List<int>[size];
                for (int i = 0; i < size; i++)
                {
                    vertexes[i] = new Vertex(i);
                    adj[i] = new List<int>();
                }
            }
        }

        //BFS
        public static void bfs(Graph graph, int start)
        {
            bool[] visited = new bool[graph.size];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            while(queue.Count>0)
            {
                int front = queue.Dequeue();
                if (visited[front]) continue;
                //Do task at the current vertex
                Console.WriteLine(graph.vertexes[front].val);

                visited[front] = true;
                foreach (int adjacentToFront in graph.adj[front])
                {
                    queue.Enqueue(adjacentToFront);
                }
            }
        }

        //DFS
        public static void dfs(Graph graph, int start, bool[] visited)
        {            
            //Do task at the current vertex
            Console.WriteLine(graph.vertexes[start].val);
            visited[start] = true;
            foreach (int index in graph.adj[start])
            {
                if (!visited[index])
                    dfs(graph, index, visited);
            }
        }
    }
}
