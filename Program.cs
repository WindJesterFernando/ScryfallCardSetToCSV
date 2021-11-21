
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        ProcessJsonCardSetsData();
        Console.WriteLine("done");
    }

    static public void ProcessJsonCardSetsData()
    {
        LinkedList<string> lines = new LinkedList<string>();

        using (StreamReader r = new StreamReader("sets.json"))
        {
            var json = r.ReadToEnd();
            var item = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var s in item.data)
            {
                string line = "";
                line = s.name + "," + s.search_uri + "," + ((string)s.block) + "," + ((string)s.code) + "," + s.set_type;
                Console.WriteLine(line);
                lines.AddLast(line);
            }
        }

        using (StreamWriter file = new StreamWriter("CardSetData.txt"))
        {
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }
    }
}

