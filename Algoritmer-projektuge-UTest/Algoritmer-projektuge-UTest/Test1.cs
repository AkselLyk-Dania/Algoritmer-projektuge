using Algoritmer_projektuge_NET10;
using System.Text.Json;

namespace Algoritmer_projektuge_UTest
{
    [TestClass]
    public class Test1 //Bubble sort
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Få actual, som køres igennem bubble sort
            string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "reverseSorted.json");
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);
            List<int> numbers = data!["values"];
            GenericList<int> actual = new GenericList<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                actual.Add(numbers[i]);
            }

            //Få expected, som bruger listed med sorted
            filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "sorted.json");
            json = File.ReadAllText(filePath);
            data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);
            numbers = data!["values"];
            GenericList<int> expected = new GenericList<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                expected.Add(numbers[i]);
            }

            actual.BubbleSort();

            //test om begge collections er ens
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());


        }
    }
}
