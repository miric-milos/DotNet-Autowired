using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutowireApp.Autowired
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutowiredAttribute : Attribute
    {
    }
}
