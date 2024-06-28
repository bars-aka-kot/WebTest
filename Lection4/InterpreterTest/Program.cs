namespace InterpreterTest
{
    abstract class Expression
    {
        public abstract bool Interpret(string cotext);
    }
    class TerminalExpression : Expression
    {
        private string data;
        public TerminalExpression(string data)
        {
            this.data = data;
        }
        public override bool Interpret(string cotext)
        {
            return cotext.Contains(data);
        }
    }
    class AndExpression:Expression
    {
        private Expression expr1;
        private Expression expr2;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public override bool Interpret(string cotext)
        {
            return expr1.Interpret(cotext) && expr2.Interpret(cotext);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Expression person = new TerminalExpression("Миша");
            Expression married = new TerminalExpression("женат");
            Expression isMarried = new AndExpression(person, married);

            Console.WriteLine("Миша женат? : " + isMarried.Interpret("Миша женат"));
            Console.WriteLine("Миша женат? : " + isMarried.Interpret("Миша разведен"));
        }
    }
}
