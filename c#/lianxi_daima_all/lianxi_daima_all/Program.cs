using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Program
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
    /*
   class Button
   {
       public string caption="fafa";
   }
   class Test
   {
       static void Main()
       {
           Button btn = new Button();
           Console.WriteLine(btn.caption);
           Thread.Sleep(10000);
       }
   }
   */
    /*
    class Test {

        /// <summary>
        /// 输出99乘法表
        /// </summary>
        static void Main()
         {
             Console.WriteLine("输出99乘法表：");
             for(int i = 1; i < 10; i++)
             {
                for(int j = 1; j <= i; j++)
                 {
                     Console.Write("{0}*{1}={2}  ",j,i,i*j);

                 }
                 Console.Write("\r\n");
             }
             Console.ReadKey();

         }
     }
     */
    /*
   class Test
   {
       static void Main()
       {
           int[] arr = new int[] { 1,2,64,3,4,23,54,6,2,2,145,4,234,23,21,43,2,3,4,556,67,4,33};
           int len = arr.Length;
           for(int i = 0; i < len; i++)
           {

               for(int j=i;j>=0; j--)
               {
                   if (j==0)
                   {
                       continue;
                   }
                   if (arr[j-1] > arr[j])
                   {
                       int tmp = arr[j-1];
                       arr[j - 1] = arr[j];
                       arr[j] = tmp;
                   }
               }
           }
           for(int i=0;i< len; i++)
           {
               Console.WriteLine(arr[i]);
           }
           Console.ReadKey();

       }
   }
   */
    /*
    class Test
    {
        static void Main()
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");

        }
    }
    */
    /*
    class Test
    {   /// <summary>
        /// 输出斜三角形
        /// </summary>
        static void Main()
        {
            for(int i = 1; i <=10; i++)
            {
                Console.WriteLine("");
                for(int j = 1; j <= i; j++)
                {
                    Console.Write("*   ");
                }
            }
            Console.ReadKey();
        }
    }
    */
    /*
    class Test
    {
        /// <summary>
        /// 输出五星的规则图形
        /// </summary>
        static void Main()
        {
            for (int i = 1; i <=5; i++)
            {
                Console.WriteLine("");
                for(int j = 1; j <= 5-i; j++)
                {
                    Console.Write(" ");
                }
                for(int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("  * ");
                }
            }
            Console.ReadKey();
        }
    }
    */
    /*
     class Test
     {
         public const int A = 1;
         public const int B= A + 1;
         static void Main()
         {
             Console.WriteLine("A={0},B={1}", Test.A, Test.B);
             Console.ReadKey();
         }
     }
     */
    /*
    class Test
    {
        public static void Main()
        {
            string str = "12344";
            int channelId = 0;
            Console.WriteLine(int.TryParse(str, out channelId));//转换成功返回True
            Console.WriteLine(channelId);//这时将转换成功的数字格式赋值给了channelId
            Console.ReadKey();
        }
    }
    */
    /*
    class Test
    {
        public static void Main()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);//E:\notes\c#\lianxi_daima_all\lianxi_daima_all\bin\Debug
            Console.ReadKey();
        }
    }
    */
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    //using TeamDev.Redis;


    public class TvNavigationPublisher
        {
            /*
            电影       "1"
            电视剧     "2"
            动漫      "3"
            综艺      "4"
            纪录片     "5"
            欧美剧     "6"
            ...





            */
            //内容发布，写入redis
            public  void Pulish()
            {
                var tvNavigation = ReadJsonFiles();
                WriteToRedis(tvNavigation);
            }

            private Dictionary<string, string> ReadJsonFiles()
            {
                //string TvNavigationRootPath = System.Configuration.ConfigurationManager.AppSettings["TvNavigation"];
                string TvNavigationRootPath = "C:\\Users\\daiyan\\Documents\\Tencent Files\\3514526521\\FileRecv\\json";
                //读取json文件
                var filePaths = Directory.GetFiles(TvNavigationRootPath, "*.json");

                //定义一个字典
                var dic = new Dictionary<string, string>();
                foreach (var filePath in filePaths)
                {
                    if (!File.Exists(filePath))
                    {
                        continue;
                    }
                    var jsonContent = File.ReadAllText(filePath, Encoding.UTF8);
                    
                    if (jsonContent == null || string.IsNullOrEmpty(jsonContent))
                    {
                        continue;
                    }

                //组合字典的键，将内容存储到字典
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var key = fileName.Substring(fileName.IndexOf("-")+1);
               
                if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, jsonContent);
                    }

                }
            Console.WriteLine(dic);
            return dic;
            
        }

            //将文件内容写入redis
            private void WriteToRedis(Dictionary<string, string> tvNavigationJsonDic)
            {
                if (tvNavigationJsonDic == null || tvNavigationJsonDic.Count == 0)
                {
                    return;
                }
               // using (RedisDataAccessProvider redisClient = MoliServer20.Common.Utils.RedisClient.GetRedisClient(PublishController.Redis.RedisServer))
                {
                    //将内容存入redis的指定key中
                    //redisClient.Hash[PublishController.MakeKey("TvNavigation")].Set(tvNavigationJsonDic);
                }

            }

        }

    class Test
    {
        public static void Main()
        {
            var a = new TvNavigationPublisher();
            a.Pulish();

            Console.ReadKey();
        }
    }



}
