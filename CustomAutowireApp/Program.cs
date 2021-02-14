using CustomAutowireApp.IoCContainer;
using System;

namespace CustomAutowireApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            startup.Register<IService, Service>();

            var controller = new Controller(startup.Get<IService>());

            Console.ReadLine();
        }

        interface IService
        {

        }

        class Service : IService
        {
            public string Field { get; set; } = "Polje";
        }

        class Controller
        {
            private readonly IService service;

            public Controller(IService service)
            {
                this.service = service;
            }
        }
    }
}
