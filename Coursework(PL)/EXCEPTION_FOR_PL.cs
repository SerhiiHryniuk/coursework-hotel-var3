using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_PL_
{
    class EXCEPTION_FOR_PL
    {
        public EXCEPTION_FOR_PL() { }

        public EXCEPTION_FOR_PL(Exception e)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("ERROR: " + e.Message);
            Console.WriteLine("------------------");
        }

        public void InputNumberAreWrong(Exception e)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("ERROR: " + e.Message);
            Console.WriteLine("TIP: Input a number not a word");
            Console.WriteLine("------------------");
        }
    }
}
