namespace AbstractFacroryMethod
{
    interface IButton
    {
        void Display();
    }
    interface ITextBox
    {
        void Display();
    }
    class WindowsButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("Show button Windows");
        }
    }
    class WindowsTextBox : ITextBox
    {
        public void Display()
        {
            Console.WriteLine("Show Windows textbox window");
        }
    }
    class MacOSButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("Show MacOS button");
        }
    }
    class MacOSTextBox : ITextBox
    {
        public void Display()
        {
            Console.WriteLine("Show MacOS textbox window");
        }
    }
    interface IControlsFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
    class WindowsControlsFactory : IControlsFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ITextBox CreateTextBox() => new WindowsTextBox();
    }
    class MacOSControlsFactory : IControlsFactory
    {
        public IButton CreateButton() => new MacOSButton();
        public ITextBox CreateTextBox() => new MacOSTextBox();
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool osWindows = false;
            IControlsFactory? factory = null;
            if(osWindows)
            {
                factory = new WindowsControlsFactory();
            }
            else
            {
                factory = new MacOSControlsFactory();
            }
            IButton button = factory.CreateButton();
            ITextBox textBox = factory.CreateTextBox();

            button.Display();
            textBox.Display();
        }
    }
}
