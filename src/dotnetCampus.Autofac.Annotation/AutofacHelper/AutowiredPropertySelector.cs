using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac.Annotation;
using Autofac.Core;

namespace dotnetCampus.Autofac.Annotation.AutofacHelper
{
    /// <summary>
    /// 只有标记了 <see cref="AutowiredAttribute"/> 的属性，才进行属性注入。
    /// </summary>
    internal class AutowiredPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.CustomAttributes.Any(it => it.AttributeType == typeof(AutowiredAttribute));
        }

    }
}
