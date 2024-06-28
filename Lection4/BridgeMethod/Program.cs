namespace BridgeMethod
{
    class Program
    {
        interface IImplementor
        {
            void OperationImplementation();
        }
        class ConcreteImplementorA : IImplementor
        {
            public void OperationImplementation()
            {
                Console.WriteLine("Concrete realisation A");
            }
        }
        class ConcreteImplementorB : IImplementor
        {
            public void OperationImplementation()
            {
                Console.WriteLine("Concrete realisation B");
            }
        }
        abstract class Abstraction
        {
            protected IImplementor implementor;
            public Abstraction(IImplementor imp) => implementor = imp;
            public abstract void Operation();
        }

        class ConcreteAbstractionA : Abstraction
        {
            public ConcreteAbstractionA(IImplementor imp) : base(imp) { }
            public override void Operation()
            {
                Console.Write("Concrete abstraction A ");
                implementor.OperationImplementation();
            }
        }
        class ConcreteAbstractionB : Abstraction
        {
            public ConcreteAbstractionB(IImplementor imp) : base(imp) { }
            public override void Operation()
            {
                Console.Write("Concrete abstraction B ");
                implementor.OperationImplementation();
            }
        }
        static void Main(string[] args)
        {
            Abstraction a = new ConcreteAbstractionA(new ConcreteImplementorB());
            Abstraction b = new ConcreteAbstractionB(new ConcreteImplementorA());
            a.Operation();
            b.Operation();
        }
    }
}
//1:05:20