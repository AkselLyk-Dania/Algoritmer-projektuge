using Algoritmer_projektuge_NET10;
using System.Text.Json;

namespace Algoritmer_projektuge_UTest;

[TestClass]
public class Test2 //Insertion sort
{
    [TestMethod]
    public void TestMethod1()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "reverseSorted.json");
        string json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);
        List<int> numbers = data!["values"];
        GenericList<int> actual = new GenericList<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            actual.Add(numbers[i]);
        }


        filePath = Path.Combine(AppContext.BaseDirectory, "JSON_Data", "sorted.json");
        json = File.ReadAllText(filePath);
        data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);
        numbers = data!["values"];
        GenericList<int> expected = new GenericList<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            expected.Add(numbers[i]);
        }

        actual.InsertionSort();

        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
