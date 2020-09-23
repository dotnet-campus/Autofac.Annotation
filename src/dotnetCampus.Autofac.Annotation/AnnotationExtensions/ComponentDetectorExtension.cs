using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using dotnetCampus.Autofac.Annotation.AnnotationCore;

namespace dotnetCampus.Autofac.Annotation.AnnotationExtensions
{
    internal static class ComponentDetectorExtension
    {
        /// <summary>
        /// 根据 <see cref="ComponentModel"/> 特性和 <see cref="IComponentDetector"/> 接口来判断类型是否为 Component。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="componentDetector"></param>
        /// <returns></returns>
        public static ComponentModel? GetComponent(this Type type, IComponentDetector? componentDetector)
        {
            // Component 特性的优先级高于 IComponentDetector 接口。
            var component = type.GetCustomAttribute<ComponentAttribute>();
            if (component != null)
            {
                return type.BuildComponentModel(component);
            }

            return componentDetector?.Detect(type);
        }

        private static ComponentModel? BuildComponentModel(this Type type, ComponentAttribute componentAttribute)
        {
            if (componentAttribute == null)
            {
                return null;
            }

            return new ComponentModel(type)
            {
                Service = componentAttribute.Service,
                AutofacScope = componentAttribute.AutofacScope,
                IsOnlyRegisterProperties = false,
            };
        }

    }
}
