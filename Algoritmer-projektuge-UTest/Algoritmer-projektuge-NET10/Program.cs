using System.Text.Json;

namespace Algoritmer_projektuge_NET10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ----------------------------
            // INPUT: Load sorted.json
            // ----------------------------

            //Få file path
            string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "sorted.json");

            //Check om den eksisterer, hvis ikke stopper koden
            if (!File.Exists(filePath))
            {
                Console.WriteLine("path " + filePath + " not found!");
                return;
            }
            else Console.WriteLine("path " + filePath + " exists!");
            Console.WriteLine("");

            //Lav numre om til en liste
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);
            List<int> numbers = data!["values"];

            // ----------------------------
            // END OF "INPUT: Load sorted.json"
            // ----------------------------

            //Ny instance af "GenericList"
            GenericList<int> list = new GenericList<int>();

            //Tilføj alle numre fra json listen
            for(int i = 0; i < numbers.Count; i++)
            {
                list.Add(numbers[i]);
            }

            //list.BubbleSort(); //Bubble sort
            //list.InsertionSort(); //Insertion sort

            //Skriv all numre ned
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

        }
    }
}