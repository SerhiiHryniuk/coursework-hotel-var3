using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_BLL_
{
    class ExceptionWhenInitializeClass : SystemException
    {
        public ExceptionWhenInitializeClass(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
    class ExceptionWhenIndexOutOfRange : SystemException
    {
        public ExceptionWhenIndexOutOfRange(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
}
