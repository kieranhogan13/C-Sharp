// Prim's MST Algorithm on Adjacency Lists representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs
// PrimSparse.cs

using System;
using System.IO;

// Heap code to be adapted for Prim's algorithm
// on adjacency lists graph
class Heap
{
    private int[] h;	   // heap array
    private int[] hPos;	   // hPos[h[k]] == k
    private int[] dist;    // dist[v] = priority of v

    private int N;         // heap size
   
    // The heap constructor gets passed from the Graph:
    //    1. maximum heap size
    //    2. reference to the dist[] array
    //    3. reference to the hPos[] array
    public Heap(int maxSize, int[] _dist, int[] _hPos) 
    {
        N = 0;
        h = new int[maxSize + 1];
        dist = _dist;
        hPos = _hPos;
    }


    public bool isEmpty() 
    {
        return N == 0;
    }

    
    public void siftUp( int k) 
    {
        int v = h[k];

        h[0] = 0;  // put dummy vertes before top of heap
        dist[0] = int.MinValue;

        while( ) 
        {
            // missing code
            a[k] = a[k/2];
            k = k / 2;
        }
        // missing code  
        a[k] = v;   
    }


    public void siftDown( int k) 
    {
        int v, j;
        // missing code
        v = a[k];
        j = (2*k) + 1;
        while (j <= N-1)
        {
            if (j < N-1 && a[j] < a[j+1])
            {
                j++;
            }
            if (v >= a[j])
            {
                break;
            }
            a[k] = a[j];
            k = j;
            j = (2*k)+1;
        }
        a[k] = v;

    }

    public void insert( int x) 
    {
        h[++N] = x;
        siftUp( N);
    }


    public int remove() 
    {   
        int v = h[1];
        hPos[v] = 0; // v is no longer in heap
        h[N+1] = 0;  // put null node into empty spot
        
        h[1] = h[N--];
        siftDown(1);
        
        return v;
    }
}  // end of Heap class


// Graph code to support Prim's MSt Alg
class Graph 
{
    
    // Same as in GraphLists.cs which had DF traversal
    // If you did that, just copy and paste attributes code      
    
    
    // default constructor
    public Graph(string graphFile)  
    {
        // same as in GraphLists.cs which had DF traversal
        // If you did that, just copy and paste constructor code
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
            while (t.vert != 0) // and increaments by allowing node to equal next component
            {
                t = t.next;
            }
            t.vert = v; // handles v verts
            t.wgt = wgt; // inserts wgt
            t.next = new Node(0, 0, z);

            t = w;
            while (t.vert != 0) // and increaments by allowing node to equal next component
            {
                t = t.next;
            }
            t.vert = u; // handles u verts
            t.wgt = wgt; // inserts wgt
            t.next = new Node(0, 0, z);
	    }
        Console.WriteLine("");  
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
	{  
        return (char)(u + 64);
    }
    
    // method to display the graph representation
    // same as before
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
 
    // Prim's algorithm to compute MST
    // Code most of this yourself
    int[] MST_Prim( int s) 
    {
        int v, u;
        int wgt, wgt_sum = 0;
        int[]  dist, parent, hPos;
        Node t;
        
        // code here
        dist[s] = 0;
        
        // code here
        
        while ( ! pq.isEmpty())  
        {
            // code here
            Console.Write("\nAdding to MST edge {0}--({1})--{2}", toChar(parent[v]), dist[v], toChar(v));
            // more code here
            
        }
        Console.Write("\n\nWeight of MST = {0}\n",wgt_sum);
               
        return parent;
    }

    public void showMST(int[] mst)
    {
            Console.Write("\n\nMinimum Spanning tree parent array is:\n");
            for(int v = 1; v <= V; ++v)
                Console.Write("{0} -> {1}\n", toChar(v), toChar(mst[v]));
            Console.WriteLine("");
    }
 
    public static void Main()
    {
        int s = 4;
        int[] mst;
        string fname = "myGraph.txt";               

        Graph g = new Graph(fname);
       
        g.display();
        
        mst = g.MST_Prim(s);
        
        g.showMST(mst);
    }

} // end of Graph class


