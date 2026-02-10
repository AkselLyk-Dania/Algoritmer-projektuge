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

            //Få file path
            //string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "sorted.json");
            //string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "reverseSorted.json");
            string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "notSorted.json");

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

            //Nulstil antal sammenligninger
            StaticCounter.runs = 0;

            //Ny instance af "GenericList"
            GenericList<int> list = new GenericList<int>();

            //Tilføj alle numre fra json listen
            for (int i = 0; i < numbers.Count; i++)
            {
                list.Add(numbers[i]);
            }

            list.BubbleSort(); //Bubble sort
            //list.InsertionSort(); //Insertion sort

            //Skriv all numre ned + antal sammenligninger
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Antal sammenligninger: " + StaticCounter.runs);
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