using System.Text.Json;

namespace Algoritmer_projektuge_NET10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------
            // INPUT: Load .json
            // ----------------------------

            //Menu til at vælge file path
            string filePath = "[NO PATH]";

            Console.WriteLine("Tryk enten 1, 2 eller 3 for at sortere en liste:");
            Console.WriteLine("1. sorteret tal");
            Console.WriteLine("2. omvendt sorteret tal");
            Console.WriteLine("3. tilfældige tal\n");

            char key = Console.ReadKey().KeyChar;

            Console.WriteLine("");

            //Få file path
            if (key == '1') 
            { 
                Console.Write("Sorteret tal: ");
                filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "sorted.json"); 
            }
            else if (key == '2')
            {
                Console.Write("Omvendt sorteret tal: ");
                filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "reverseSorted.json");
            }
            else if (key == '3')
            {
                Console.Write("Tilfældige tal: ");
                filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "notSorted.json");
            }
            else 
            { 
                Console.WriteLine("Character " + key + " is unassigned"); 
                return; 
            }

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
            // END OF "INPUT: Load .json"
            // ----------------------------

            //Ny instance af "GenericList"
            GenericList<int> list = new GenericList<int>();

            //Tilføj alle numre fra json listen
            for (int i = 0; i < numbers.Count; i++)
            {
                list.Add(numbers[i]);
            }

            //Menu til at vælge sorterings-algoritme
            Console.WriteLine("Vælg sorterings-algoritme:");
            Console.WriteLine("1. Bubble sort");
            Console.WriteLine("2. Insertion Sort\n");

            key = Console.ReadKey().KeyChar;

            Console.WriteLine("");

            if (key == '1') //Bubble sort
            { 
                Console.WriteLine("Run bubble sort..."); 
                list.BubbleSort(); 
            }
            else if (key == '2') //Insertion sort
            { 
                Console.WriteLine("Run insertion sort..."); 
                list.InsertionSort(); 
            }
            else 
            { 
                Console.WriteLine("Character " + key + " is unassigned"); 
                return; 
            }

            //Skriv all numre ned + antal sammenligninger
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Antal sammenligninger: " + list.runs);
            Console.WriteLine("");

            // ----------------------------
            // OUTPUT: Save to project-root-relative output folder
            // ----------------------------

            // Compute project root (3 levels up from bin/Debug/net10.0)
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            // Output folder inside project root
            string outputDir = Path.Combine(projectRoot, "output");

            // Create folder if it doesn't exist
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputFile = Path.Combine(outputDir, "sorted_numbers.json");

            // Wrap list in JSON structure
            var outputData = new { values = list };

            // Serialize JSON with indentation
            string newJson = JsonSerializer.Serialize(outputData, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON to file
            File.WriteAllText(outputFile, newJson);
            Console.WriteLine($"Saved JSON to: {outputFile}");

        }
    }
}