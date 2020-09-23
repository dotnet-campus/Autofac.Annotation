using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetCampus.Autofac.Annotation
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// 注册单个的类型
        /// </summary>
        public Type? Service { get; }

        /// <summary>
        /// 作用域
        /// </summary>
        public AutofacScope AutofacScope { get; set; } = AutofacScope.Default;

        public ComponentAttribute()
        {

        }

        public ComponentAttribute(Type service)
        {
            Service = service;
        }

    }
}
