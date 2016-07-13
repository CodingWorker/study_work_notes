using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace _006
{
   class ResolveDNS
    {
        IPAddress[] m_arrIPs;
        
        public void Resolve(string strHost)
        {
            IPHostEntry iphe = Dns.GetHostEntry(strHost);
            m_arrIPs = iphe.AddressList;
        }

        public IPAddress this[int nIndex]
        {
            get
            {
                return m_arrIPs[nIndex];
            }
        }

        public int Count
        {
            get { return m_arrIPs.Length; }
        }
    }

    class DNSResolverApp
    {
        public static void Main()
        {
            ResolveDNS myDNSResolver = new ResolveDNS();
            myDNSResolver.Resolve("http://www.microsoft.com");
            int nCount = myDNSResolver.Count;
            Console.WriteLine("Found{0} IP's for hostname", nCount);
            for (int i = 0; i < nCount; i++)
            Console.WriteLine(myDNSResolver[i]);
        }
    }
}
