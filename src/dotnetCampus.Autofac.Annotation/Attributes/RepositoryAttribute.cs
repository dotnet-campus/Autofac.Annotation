using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetCampus.Autofac.Annotation
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RepositoryAttribute : ComponentAttribute
    {
        public RepositoryAttribute()
        {
            AutofacScope = AutofacScope.SingleInstance;
        }

        public RepositoryAttribute(Type service) : base(service)
        {
            AutofacScope = AutofacScope.SingleInstance;
        }
    }
}
