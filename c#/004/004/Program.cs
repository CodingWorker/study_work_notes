using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004
{
    class BaseClass
    {

    }

    class DerivedClass:BaseClass
    {
        public void     TestMethod()
        {
            Console.WriteLine("DerivedClass::TestMethod");
        }
    }
    
    class TestApp
    {
        public static void Main()
        {
            DerivedClass test = new DerivedClass();
            test.TestMethod();
            Thread.Sleep(100000);
            
        }
    }
}
