using CustomAutowireApp.Autowired;
using CustomAutowireApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutowireApp.Controller
{
    public class ApiController : IApiController
    {

        [Autowired]
        private readonly IService service;

        public void PrintService()
        {
            service.Print();
        }
    }
}
