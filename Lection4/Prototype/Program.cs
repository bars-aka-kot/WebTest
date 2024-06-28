using System.Net.Http.Headers;

namespace Prototype
{
    class Prototype
    {
        public string Name { get; set; }
        public List<string> MoreNames { get; set; } = new List<string>();
        public Prototype(string name)
        {
            Name = name;
        }
        public Prototype Clone()
        {
            var p = new Prototype(Name);
            p.MoreNames = new List<string>(MoreNames);
            return p;
        }
        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Names: ");
            MoreNames.ForEach(Console.WriteLine);
        }
        class Program
        {
            static void Main(string[] args)
            {
                Prototype original = new Prototype("Original object") { MoreNames = { "One name more" } };
                Prototype clone = original.Clone();
                clone.Print();
            }
        }
    }
}
