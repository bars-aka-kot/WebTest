namespace FactoryMethod
{
    abstract class Product
    {
        public abstract string GetName();
    }
    class ConcreteProductA : Product
    {
        public override string GetName() => "Concrete Product A";
    }
    class ConcreteProductB : Product
    {
        public override string GetName() => "Concrete Product B";
    }
    abstract class Creator
    {
        public abstract Product FactoryMode();
    }
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMode() => new ConcreteProductA();
    }
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMode() => new ConcreteProductB();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Creator creatorA = new ConcreteCreatorA();
            Product productA = creatorA.FactoryMode();

            Creator creatorB = new ConcreteCreatorB();
            Product productB = creatorB.FactoryMode();

            Console.WriteLine(productA.GetName());
            Console.WriteLine(productB.GetName());
        }
    }
}
