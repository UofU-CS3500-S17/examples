using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace HttpExamples
{
    /// <summary>
    /// Provides a few examples useful for building a stripped-down HTTP server.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Recognize that a URL maps to a service method and extract parameters
            Regex r = new Regex(@"^/BoggleService.svc/games/(G\d+)$");

            string url1 = "/BoggleService.svc/games";
            Match m1 = r.Match(url1);
            if (m1.Success)
            {
                Console.WriteLine(url1 + " matches and contains parameter " + m1.Groups[1]);
            }
            else
            {
                Console.WriteLine(url1 + " doesn't match");
            }

            string url2 = "/BoggleService.svc/games/G187877787";
            Match m2 = r.Match(url2);
            if (m2.Success)
            {
                Console.WriteLine(url2 + " matches and contains parameter " + m2.Groups[1]);
            }
            else
            {
                Console.WriteLine(url2 + " doesn't match");
            }
            Console.ReadLine();

            // Deserialize JSON into something of a specific type
            string json = "{\"Name\" : \"John\", \"Age\": 42}";
            Person p1 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(p1.Name + " " + p1.Age);
            Console.ReadLine();

            // Omit default properties when serializing JSON
            Person p2 = new Person { Name = "Jane" };
            String s = JsonConvert.SerializeObject(p2, new JsonSerializerSettings
                                                        { DefaultValueHandling = DefaultValueHandling.Ignore});
            Console.WriteLine(s);
            Console.ReadLine();

            // Determine how many bytes it will take to encode a string
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            string s1 = "Hello World";
            int n1 = encoding.GetByteCount(s1);
            Console.WriteLine(s1 + " takes " + n1 + " bytes");
            string s2 = "αβδ";
            int n2 = encoding.GetByteCount(s2);
            Console.WriteLine(s2 + " takes " + n2 + " bytes");
            Console.ReadLine();
        }
    }
   

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
