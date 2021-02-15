using CustomAutowireApp.IoCContainer;
using System;

namespace CustomAutowireApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Init();            
            var controller = Startup.Get<Controller>();
            Console.ReadLine();
        }

        public interface IService
        {

        }

        public class Service : IService
        {
            public string field = "Polje";
            public string field2 = "polje20;";
        }

        public class Controller
        {
            private readonly IService service;

        }
    }
}
