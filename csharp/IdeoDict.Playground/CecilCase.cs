public class MainCase
    {
        public void PublicMethod()
        {
            Console.WriteLine("Hello");
            PrivateMethod();

            new SecondCase().Help("Help me");
        }

        public void AddMethod()
        {
        }

        private void PrivateMethod()
        {
        }

        public void MethodWithArgument(string name)
        {
            Console.WriteLine(name);
        }
    }

// SecondCase.cs
class SecondCase
    {
        public void Help(string message)
        {
            Console.WriteLine(message);
        }
    }
