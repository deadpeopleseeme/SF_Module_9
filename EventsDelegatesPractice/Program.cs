
namespace EventsDelegatesPractice
{
    public class Logic
    {
        //делегат
        public delegate void SortingSurnamesDelegate(string[] array, int oneOrTwo);

        //событие
        public static event SortingSurnamesDelegate SorterEvent;

        //protected virtual method
        protected virtual void OnSortingStart(string[] array, int oneOrTwo)
        {
            SorterEvent?.Invoke(array, oneOrTwo);
        }

        public void SuperLogic(string[] array)
        {
            Console.WriteLine("\nВведите 1 для сортировки по алфавиту, 2 для обратной сортировки\n");

            int userChoice = default;
            bool isNumber = true;

            //проверяем, число ли вообще ввёл юзер
            try
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                isNumber = false;
            }

            //если число, но не 1 и не 2
            if(isNumber && userChoice != 1 && userChoice != 2) 
            {
                try
                {
                    throw new WrongChoiceException("ТОЛЬКО 1 ИЛИ 2");
                }
                catch (WrongChoiceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                OnSortingStart(array, userChoice);
            }
        }
    }
    internal class Program
    {

        public static void SortingArrays(string[] array, int oneOrTwo)
        {
            //клонируем массив чтоб не изменять основной, сортируем его в алфавитном (это делается в любом случае, т.к. для обратной сортировки нужна алфавитная)
            var newArray = (Array)array.Clone();
            Array.Sort(newArray);
            //вообще лучше сделать логику с булевыми, т.е. юзер ввёл 1 = true, 2 = false, но я уже опаздываю, сдаю так
            if (oneOrTwo == 2)
            {
                Array.Reverse(newArray);
            }
            Console.WriteLine();
            foreach (var surname in newArray) 
            { 
                Console.WriteLine(surname); 
            }
        }   

        static void Main(string[] args)
        {
            string[] surnames = {"Чехов", "Пушкин", "Толстой", "Простой", "Аццтой" };
            Console.WriteLine("Итак, есть список из 5 фамилий: \n");
            foreach(var surname in surnames)
            {
                Console.WriteLine(surname);
            }
            Logic mainLogic = new();
            Logic.SortingSurnamesDelegate myDelegate = SortingArrays;
            Logic.SorterEvent += myDelegate;
            mainLogic.SuperLogic(surnames);
        }
    }
}
