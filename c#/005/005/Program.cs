using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _005
{
    public class House
    {
        private int m_nSqFeet;
        
        public int SquareFeet
        {
            get { return m_nSqFeet; }
            set { m_nSqFeet = value; }
        }

        class TestApp
        {
            public static void Main()
            {
                House myHouse = new House();
                myHouse.SquareFeet = 250;
                Console.WriteLine(myHouse.SquareFeet);
                Thread.Sleep(10000);
            }
        }
    }
}
