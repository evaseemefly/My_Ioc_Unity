using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Ioc
{
    public class Person : IPerson
    {
        public string Name { get; set; }



        public void SayHello()
        {
            Console.WriteLine("我是测试程序，我叫{0}",Name);

        }
    }
}
