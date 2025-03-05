using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        List<Dictionary<string, int>> input = new List<Dictionary<string, int>>
        {
            new Dictionary<string, int> { { "item1", 400 } },
            new Dictionary<string, int> { { "item2", 300 } },
            new Dictionary<string, int> { { "item1", 750 } }
        };

        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var dict in input)
        {
            foreach (var pair in dict)
            {
                string key = pair.Key;
                int value = pair.Value;

                if (result.ContainsKey(key))
                {
                    result[key] += value;
                }
                else
                {
                    result[key] = value;
                }
            }
        }

        string jsonResult = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        
        System.IO.File.WriteAllText("result.json", jsonResult);

        Console.WriteLine(jsonResult);
    }
}
