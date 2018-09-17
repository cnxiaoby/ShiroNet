using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "1","2","3"
            };
            var partIt = list.GetEnumerator();

            StringBuilder buffer = new StringBuilder();
            while (partIt.MoveNext())
            {
                buffer.Append(partIt.Current);
                buffer.Append(",");                
            }

            Console.WriteLine(buffer.ToString());
            Console.WriteLine("end");
            Console.Read();
        }
    }
}
