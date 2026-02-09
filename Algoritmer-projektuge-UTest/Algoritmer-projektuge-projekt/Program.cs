using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer_projektuge_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();

            //Tilføj numre til listen
            list.Add(5);
            list.Add(2);
            list.Add(9);
            list.Add(1);
            list.Add(4);

            list.BubbleSort();

            //Skriv all numre ned
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

            //Få mængde af listens elementer
            Console.WriteLine(list.count); //list.CountAll()

            //Skriv indeks nummer 1 i listen (starter med 0)
            Console.WriteLine(list[0]);
        }
    }
}
