using System;
using System.Collections.Generic;
using System.Reflection;
using static CustomAutowireApp.Program;

namespace CustomAutowireApp.IoCContainer
{
    /// <summary>
    /// Ioc container
    /// </summary>
    class Startup
    {
        private static Dictionary<Type, Func<object>> registry =
            new Dictionary<Type, Func<object>>();


        private static void Register<TType, TImpl>() where TImpl : TType, new()
        {
            registry.Add(typeof(TType), () => new TImpl());
        }

        public static void Init()
        {
            Register<IService, Service>();
        }

        public static T Get<T>() where T : new()
        {
            var obj = new T();
            var fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if(registry.ContainsKey(field.FieldType))
                {
                    field.SetValue(obj, registry[field.FieldType].Invoke());
                }
            }

            return obj;
        }
    }
}