using System;

namespace DelegatesDemo
{
    class Program
    {
        delegate void DispStrDelegate(string param);

        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capatalized -->" + text.ToUpper());
        }
        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased -->" + text.ToLower());
        }
        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter some text: ");
            string text = Console.ReadLine();

            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);

            sayings(text);

            Console.WriteLine("Running by passing delegate to another method: ");
            RunMyDelegate(sayings, text);


            Console.WriteLine("Running by passing in a lambda expression: ");
            RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

            Console.WriteLine("Lambda without type: ");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            Console.WriteLine("Lambda without parenthesis:  ");
            RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);


            sayings += t => { Console.WriteLine("Lambd3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);

        }
    }
}
