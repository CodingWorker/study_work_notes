 using System;
using System.Threading;

namespace _008
{

class chengfabiao
    {

   
 public static void Main()
{
        Console.WriteLine("输出9*9乘法表：");
         string str = "";
        for(int i = 1; i <= 9; i++)
        {
                str += "\r\n";
            for(int j = 1; j <= i; j++)
            {
                    int result = i * j;
                    str += i.ToString();
                    str+="*";
                    str += j.ToString();
                    str += "=";
                    str += i * j;
                    str += " ";

            }
        }
            Console.WriteLine(str);
            Thread.Sleep(10000);
}
    }
}
