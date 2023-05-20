using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Srialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person() {Name = "goole", Age = 12, Type = BoobsType.Male},
                new Person() {Name = "qwe", Age = 3, Type = BoobsType.Female},
                new Person() {Name = "asd", Age = 345,Type = BoobsType.Male},
                new Person() {Name = "asd", Age = 12,Type = BoobsType.Female},
            };

            var people2 = new List<Person>
            {
                new Person() {Name = "goole", Age = 12, Type = BoobsType.Male},
                new Person() {Name = "qwe", Age = 3, Type = BoobsType.Female},
            };

            var groupBy = people.SingleOrDefault(x => x.Age == 3);

            //foreach (var person in groupBy)
            //{
            //    Console.WriteLine(person.Type + " " + person.Name);

            //}

            //var xmlSerialiser = new XmlSerializer(typeof(List<Person>));
            //using (FileStream fs = new FileStream("../../people.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerialiser.Serialize(fs, people);
            //}

            //var jsonSerialiser = new DataContractJsonSerializer(typeof(List<Person>));
            //using (FileStream fs = new FileStream("../../people.json", FileMode.OpenOrCreate))
            //{
            //    jsonSerialiser.WriteObject(fs, people);
            //}

            //var xmlPeople = new List<Person>();
            //using (FileStream fa = new FileStream("../../people.xml", FileMode.Open))
            //{
            //    xmlPeople = (List<Person>)xmlSerialiser.Deserialize(fa);
            //}

            //var jsonPeople = new List<Person>();
            //using (FileStream fs = new FileStream("../../people.json", FileMode.Open))
            //{
            //    jsonPeople = jsonSerialiser.ReadObject(fs) as List<Person>;
            //}

            //Console.WriteLine("XML");
            //foreach (var person in xmlPeople)
            //{
            //    Console.WriteLine(person.Name + " " + person.Age + " " +  person.Type);
            //}

            //Console.WriteLine("\nJSON");
            

            Console.ReadKey();
        }
    }

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public BoobsType Type {get; set;}
    }

    [Serializable]
    public enum BoobsType
    {
        Male,
        Female
    }
}
