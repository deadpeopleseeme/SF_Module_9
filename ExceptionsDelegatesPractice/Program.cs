
namespace ExceptionsPractices
{
    //Практикум 9.6.1, задание 1
    class Program
    {
        static void Main(string[] args)
        {
            var myExc = new WrongChoiceException(message: "Только 1 или 2! ");
            var fileNotFoundExc = new FileNotFoundException();
            var zeroDivide = new DivideByZeroException();
            var invalidCast = new InvalidCastException();
            var argumentEx = new ArgumentException();

            Exception[] excArray = { myExc, fileNotFoundExc, zeroDivide, invalidCast, argumentEx };

            foreach(var exception in excArray)
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}");
                    if (ex is WrongChoiceException)
                    {
                        Console.WriteLine($"more info: {ex.HelpLink}");
                    }
                }
            }
        }
    }
}