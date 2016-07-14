using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world!");
            Thread.Sleep(10000);
        }
    }
    */
    /*
    class Program
    {
        static void Main()
        {
            int intvalue = 123;
            long longvalue = intvalue;
            bool boo= (long)intvalue==longvalue;
            Console.WriteLine(boo);
            Thread.Sleep(10000);
        }
    }*/
    /*
    class Program
    {
        static void Main()
        {
            int[] arr = new int[5];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = i * i * i;
            }
            for(int j = 0; j < arr.Length; j++)
            {
                Console.WriteLine("arr[{0}]={1}", j, arr[j]);
            }
            Thread.Sleep(10000);
        }
    }
    */
    /*
    class Test
    {
        static void F(int p)
        {
            Console.WriteLine("p={0}", p);
            p++;
        }
        static void Main()
        {
            int a = 1;
            Console.WriteLine("before:a={0}",a);
            F(a);
            Console.WriteLine("after:a={0}", a);
            Thread.Sleep(10000);
        }
    }
    */
    /*
    class Test
    {
        static void F(ref int p)
        {
            Console.WriteLine("p={0}", p);
            p++;
        }
        static void Main()
        {
            int a = 1;
            Console.WriteLine("before:a={0}", a);
            F(ref a);
            Console.WriteLine("after:a={0}", a);
            Thread.Sleep(10000);
        }
    }
    */
    /*
    class Test
    {
        static void Divide(int a, int b, out int result, out int remainder)
        {
            result = a / b;
            remainder = a % b;
        }
        static void Main()
        {
            for(int i = 1; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    int ans, r;
                    Divide(i, j, out ans, out r);
                    Console.WriteLine("{0}/{1}={2}r{3}", i, j, ans, r);
                    
                }
            }
            Thread.Sleep(10000);
        }
    }
    */
    /*
    class Test
    {
        static void F(params int[] args)
        {
            Console.WriteLine("# of arguments:{0}", args.Length);
            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("\targs[{0}]={1}", i, args[i]);
             }
        }
        static void Main()
        {
            F();
            F(1);
            F(1, 2);
            F(1, 2, 3);
            F(new int[] { 1, 2, 3, 4 });
            Thread.Sleep(10000);
        }
    }
    */
    /*
    public class Stack
    {
        private Node first = null;
        public bool Empty
        {
            get
            {
                return (first == null);
            }
        }
        public object Pop()
        {
            if (first == null)
            {
                throw new Exception("不能从一个空栈中弹出");
            }
            else
            {
                object temp = first.Value;
                first = first.Next;
                return temp;
            }
        }
        public void Push(object o)
        {
            first = new Node(o, first);
        }
        class Node
        {
            public Node Next;
            public object Value;
            public Node(object value):this(value, null) { }
            public Node(object value, Node next)
            {
                Next = next;
                Value = value;
            }
        }
    }
    class Test
    {
        static void Main()
        {
            Stack s = new Stack();
            for(int i = 0; i < 10; i++)
            {
                s.Push(i);
                s = null;
            }
        }
    }
   */
   /*
    class Constants
    {
        public const int A = 1;
        public const int B = A + 1;
    }
    class Test
    {
        static void Main()
        {
            Constants con = new Constants();
            Console.WriteLine("常数A的值为{0}",Constants.A);
            Console.WriteLine("常数B的值为{0}", Constants.B);
            Thread.Sleep(10000);

        }
    }
    */



   




}
