using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grafer_projektuge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ny instance af Forlystelsespark
            Forlystelsespark park = new Forlystelsespark();

            //Nye instancer af forlystelser med deres strings
            Node entrance = new Node("Entrance");
            Node rollerCoaster = new Node("RollerCoaster");
            Node ferrisWheel = new Node("FerrisWheel");
            Node hauntedHouse = new Node("HauntedHouse");
            Node waterRide = new Node("WaterRide");

            //Tilføj til parken
            park.AddRide(entrance);
            park.AddRide(rollerCoaster);
            park.AddRide(ferrisWheel);
            park.AddRide(hauntedHouse);
            park.AddRide(waterRide);

            //Tilføj edges (forbindelser)
            park.ConnectRides(entrance, rollerCoaster);
            park.ConnectRides(entrance, ferrisWheel);
            park.ConnectRides(rollerCoaster, hauntedHouse);
            park.ConnectRides(ferrisWheel, waterRide);
            park.ConnectRides(waterRide, hauntedHouse);

            //Set of bools, if visited or not
            HashSet<Node> visited = new HashSet<Node>();

            //Visited nodes
            List<Node> path = new List<Node>();

            //\n laver mellemrum i writeline
            Console.WriteLine("Starting DFS...\n");

            //Metode, hvis vejen er fundet fra entrance til goal (hauntedhouse)
            bool found = park.DFS(entrance, hauntedHouse, visited, path);

            if (found)
            {
                Console.WriteLine("\nPath found:");
                for (int i = 0; i < path.Count; i++)
                {
                    Console.Write(path[i].Name);
                    if (i < path.Count - 1) Console.Write(" -> ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("No path found.");
        }
    }
}
