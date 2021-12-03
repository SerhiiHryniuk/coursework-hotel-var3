using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_DAL_
{
    public class ExceptionsWhenInitializeClass : SystemException
    {
        public ExceptionsWhenInitializeClass(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
    public class ExceptionFileDoesntExist : SystemException
    {
        public ExceptionFileDoesntExist(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
    public class ExceptionWhileSerialize : SystemException
    {
        public ExceptionWhileSerialize(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
    public class ExceptionWhileDeseralize : SystemException
    {
        public ExceptionWhileDeseralize(string exception)
        {
            Console.WriteLine("------------------");
            Console.WriteLine(exception);
            Console.WriteLine("------------------");
        }
    }
}
