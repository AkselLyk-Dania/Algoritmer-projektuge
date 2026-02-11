using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafer_projektuge
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> edges { get; set; }

        public Node(string name)
        {
            Name = name;
            edges = new List<Edge>();
        }

        public override string ToString() { return Name; }

    }
}
