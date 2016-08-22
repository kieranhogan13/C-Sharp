// Simple weighted graph representation 
// Uses an Adjacency Matrix, suitable for dense graphs

using System;
using System.IO;

class Graph 
{
    // V = number of vertices
    // E = number of edges
    private int V, E;
    // adj[ , ] is the adjacency matrix
    private int[,] adj = new int[7,7];
    
    // used for traversing graph
    private int[] visited;
    private int id;
    
    
    // default constructor
    public Graph(string graphFile)  
    {
        int u, v;
        int e, wgt;

        StreamReader reader = new StreamReader(graphFile);
	   
	    char[] splits = new char[] { ' ', ',', '\t'};     
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
        
        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);

        // create adjacency matrix
        adj = new int[V+1, V+1];
        
        
       // read the edges
        Console.WriteLine("");
		Console.WriteLine("Reading edges from text file");
        Console.WriteLine("");
        Console.WriteLine("Edges connecting vertices (including weights):");
        Console.WriteLine("");
	    for(e = 1; e <= E; ++e)
	    {
            line = reader.ReadLine();
            parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            u = int.Parse(parts[0]);
            v = int.Parse(parts[1]); 
            wgt = int.Parse(parts[2]);

            Console.WriteLine("Edge: {0}--({1})--{2}", toChar(u), wgt, toChar(v));    
            if (u>=0 || v>=0) // not neccessary
            {
                adj[v, u] = wgt; // does one half of matrix
                adj[u, v] = wgt; // does other half of matrix
            }
	    }	       
    }

    //Depth First
    public void DF(int s) 
    {
        int len = V + 1;
        visited = new int[len];
        id = 0;
        for (int v=1; v<=V; v++) // loop through each vertex
        {
            visited[v] = 0; // let all equal unvisited
        }
        Console.WriteLine("");
        Console.WriteLine("Visits via Depth First Traversal:");
        Console.WriteLine("");
        dfVisit(1, s); // needed to pass value for prev, 1 removes @
    }

    // Depth First for adjacency matrix
    private void dfVisit(int prev, int v)
    {
        visited[v] = ++id;
        Console.WriteLine("Visited vertex: {0}  along edge: {1}---{2}", toChar(v), toChar(prev), toChar(v));
        for (int u=2; u<=V ; u++) // loops through each vertex
        {
            if (adj[v, u] != 0) // if the vertex does not equal 0
            {
                if (visited[u] == 0) // if its not visited
                {
                    dfVisit(v, u); // visit the vertex
                }
            }
        }
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
    {
        return (char)(u + 64);
    }

    // method to display the graph representation
    public void display()
    {
        int u, v;
        Console.WriteLine("");
        Console.WriteLine("Resulting Adjacency Matrix:");
        for (v = 1; v <= V; ++v)
        {
            Console.Write("\nadj[{0}, ] = ", v);
            for (u = 1; u <= V; ++u)
                Console.Write("  {0}", adj[v, u]);
        }
        Console.WriteLine("");
    }

    public static void Main()
    {
        int s = 2; //needed to increase by one in order to skip having @ for 0
        string fname = "wGraph2.txt";               

        Graph g = new Graph(fname);
       
        g.display();
        
        g.DF(s);
    }

}

