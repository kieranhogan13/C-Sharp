// Simple weighted graph representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs

using System;
using System.IO;

class Graph 
{
    // V = number of vertices
    // E = number of edges
    private int V, E;

    // used for traversing graph
    private int[] visited;
    private int id;

    // class for linked list nodes needed, do yourself
    public class Node
    {
        public Node next;// constructor for Node
        public int vert, wgt;
        public Node(int vert, int wgt, Node next)
        {
            this.vert = vert; // vert of node
            this.wgt = wgt; // weight of node
            this.next = next; // pointer of node
        }
    }
    private Node[] adj; // adj[] is the adjacency lists Node array
    private Node z; // sentinel, will always be the end node
    private Node n; //needed for DF
 
    // default constructor, some code missing
    public Graph(string graphFile)  
    {
        int u, v;
        int e, wgt;
        Node t, w;
        StreamReader reader = new StreamReader(graphFile);
	    char[] splits = new char[] { ' ', ',', '\t'};     
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
        
        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);

        // create sentinel node
        z = new Node(0, 0, z);
        z.next = z; // always makes z the end node
        
        // Create adjacency lists, initialised to sentinel node z
        // Dynamically allocate array 
        adj = new Node[V+1];
        for(v=1; v<=V; ++v)
        {
            adj[v] = new Node(0, 0, z); // makes each node empty
        }
        Console.WriteLine("");
        
        // read the edges
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

            // write code to put edge into adjacency lists     
            // do yourself
            t = adj[u];
            w = adj[v];
            // similar to code for sorted linked lists
            if (t.vert == 0) // writes vert, wgt and next node to the first node element for u
            {
                t.vert = v; // handles v verts
                t.wgt = wgt; // inserts wgt
                t.next = new Node(0, 0, z);
            }
            else // otherwise searches for next slot and writes in there
            {
                while (t.vert != 0) // and increaments by allowing node to equal next component
                {
                    t = t.next;
                }
                t.vert = v; // handles v verts
                t.wgt = wgt; // inserts wgt
                t.next = new Node(0, 0, z);
            }
            if (w.vert == 0) // writes vert, wgt and next node to the first node element for v
            {
                w.vert = u; // handles u verts
                w.wgt = wgt; // inserts wgt
                w.next = new Node(0, 0, z);
            }
            else // otherwise searches for next slot and writes in there
            {
                t = w;
                while (t.vert != 0) // and increaments by allowing node to equal next component
                {
                    t = t.next;
                }
                t.vert = u; // handles u verts
                t.wgt = wgt; // inserts wgt
                t.next = new Node(0, 0, z);
            }
	    }
        Console.WriteLine("");   
    }

    //Depth First
    public void DF(int s)
    {
        int len = V+1;
        visited = new int[len];
        id = 0;
        for (int v=1; v<=V; v++) // loop through each vertex
        {
            visited[v] = 0; // let all equal unvisited
        }
        Console.WriteLine("");
        Console.WriteLine("Visits via Depth First Traversal:");
        Console.WriteLine("");
        dfVisit(0, s); // trick for removing @ does not work in this case
    }

    // Depth First for adjacency matrix
    private void dfVisit(int prev, int v)
    {
        visited[v] = ++id;
        Console.WriteLine("Visited vertex: {0}  along edge: {1}---{2}", toChar(v), toChar(prev), toChar(v));
        for (Node n=adj[v]; n.vert!=0; n=n.next) // loops through each vertex
        {
            if (visited[n.vert] == 0) // if the 
            {
                dfVisit(v, n.vert);
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
        Console.WriteLine("Resulting Adjacency Linked Lists:");
        Console.WriteLine("");
        for (int v = 1; v <= V; v++)
        {
            Console.Write("adj[{0}] :", toChar(v));
            for (n = adj[v]; n.vert != 0; n = n.next)
            {
                Console.Write(" |{0}|{1}| --->", toChar(n.vert), n.wgt);
            }
            Console.WriteLine(" z");
        }
    }

    public static void Main()
    {
        int s = 1;
        string fname = "wGraph2.txt";               

        Graph g = new Graph(fname);
       
        g.display();
        
        g.DF(s);
    }

}

