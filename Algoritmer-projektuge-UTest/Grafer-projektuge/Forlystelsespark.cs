using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grafer_projektuge
{
    public class Forlystelsespark
    {
        private List<Node> rides = new List<Node>();

        public void AddRide(Node ride)
        {
            rides.Add(ride);
        }

        public void ConnectRides(Node a, Node b)
        {
            Edge roadAB = new Edge(a, b);
            Edge roadBA = new Edge(b, a); // Undirected

            a.edges.Add(roadAB);
            b.edges.Add(roadBA);
        }


        public bool DFS(Node current, Node target, HashSet<Node> visited, List<Node> path)
        {
            Console.WriteLine("Visiting: " + current.Name);

            visited.Add(current);
            path.Add(current);

            //Hvis den er nået i mål returner metoden med true
            if (current == target) return true;


            foreach (Edge road in current.edges)
            {
                Node neighbor = road.To;

                if (!visited.Contains(neighbor) && DFS(neighbor, target, visited, path))
                {
                   return true;
                }
            }

            //Hvis det er en dead end, Backtrack
            path.RemoveAt(path.Count - 1);
            return false;
        }


    }
}
