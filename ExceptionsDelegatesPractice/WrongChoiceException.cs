using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractices
{

        //исключение, которое выбрасывается юзеру, когда ему предложили выбрать из двух стульев, а он число, отличное от 1 или 2 :D
        public class WrongChoiceException : Exception
        {
            public WrongChoiceException()
            {
                HelpLink = "https://www.google.com/search?client=firefox-b-d&q=%D0%B5%D1%81%D1%82%D1%8C+2+%D1%81%D1%82%D1%83%D0%BB%D0%B0";
            }
            public WrongChoiceException(string message) : base(message)
            {
                HelpLink = "https://store.steampowered.com/agecheck/app/873190/";
            }
        } 
}
