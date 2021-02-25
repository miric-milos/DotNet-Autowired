using CustomAutowireApp.Controller;
using CustomAutowireApp.Services;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CustomAutowireApp.IoCContainer
{
    /// <summary>
    /// Ioc container
    /// </summary>
    class Startup
    {
        private static Dictionary<Type, Func<object>> registry =
            new Dictionary<Type, Func<object>>();

        private const string AutowiredName = "AutowiredAttribute";

        private static void Register<TType, TImpl>() where TImpl : TType, new()
        {
            registry.Add(typeof(TType), () => new TImpl());
        }

        public static void Init()
        {
            // add your dependencies here
            Register<IApiController, ApiController>();
        }

        public static T Get<T>() where T : new()
        {
            var obj = new T();
            var fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var atts = field.GetCustomAttributes();

                foreach(var att in atts)
                {
                    if (att.GetType().Name.Equals(AutowiredName))
                    {
                        field.SetValue(obj, new Service());
                    }
                }
            }

            return obj;
        }
    }
}