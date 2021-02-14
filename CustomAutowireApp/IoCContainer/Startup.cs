using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutowireApp.IoCContainer
{
    /// <summary>
    /// Ioc 
    /// </summary>
    class Startup
    {
        private Dictionary<Type, Func<object>> registry = 
            new Dictionary<Type, Func<object>>();


        public void Register<TType, TImpl>() where TImpl : TType, new()
        {
            registry.Add(typeof(TType), () => new TImpl());
        }

        public TType Get<TType>()
        {
            var obj = registry[typeof(TType)];
            return (TType)obj.Invoke();
        }
    }
}
