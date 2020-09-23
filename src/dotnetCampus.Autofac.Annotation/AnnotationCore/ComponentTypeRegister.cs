using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using dotnetCampus.Autofac.Annotation.AutofacHelper;

namespace dotnetCampus.Autofac.Annotation.AnnotationCore
{
    /// <summary>
    /// 组件注册
    /// 将所有发现的组件，注册到 IOC 容器中，并自动进行属性注入。
    /// </summary>
    internal class ComponentTypeRegister
    {
        public void RegisterTypes(ContainerBuilder builder, List<ComponentModel> componentModels)
        {
            foreach (var componentModel in componentModels)
            {
                RegisterType(builder, componentModel);
            }
        }

        private void RegisterType(ContainerBuilder builder, ComponentModel component)
        {
            builder.RegisterType(component.CurrentType)
                .RegisterAuto(component)
                .SetScopeAuto(component)
                .PropertiesAutowired(new AutowiredPropertySelector());
        }
    }
}
