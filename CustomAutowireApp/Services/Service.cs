using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutowireApp.Services
{
    public class Service : IService
    {
        public void Print()
        {
            Console.WriteLine("Print Service");
        }
    }

}
