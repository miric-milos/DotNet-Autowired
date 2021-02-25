using CustomAutowireApp.Controller;
using CustomAutowireApp.IoCContainer;
using CustomAutowireApp.Services;
using System;

namespace CustomAutowireApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Init();

            var bean = Startup.Get<ApiController>();
            bean.PrintService();

            Console.ReadLine();
        }

    }
}
