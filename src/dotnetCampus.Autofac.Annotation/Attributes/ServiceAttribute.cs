using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetCampus.Autofac.Annotation
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceAttribute : ComponentAttribute
    {
        public ServiceAttribute()
        {
            AutofacScope = AutofacScope.SingleInstance;
        }

        public ServiceAttribute(Type service) : base(service)
        {
            AutofacScope = AutofacScope.SingleInstance;
        }
    }
}
