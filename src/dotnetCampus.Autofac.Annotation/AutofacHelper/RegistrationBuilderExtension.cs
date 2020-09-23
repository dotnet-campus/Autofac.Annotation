using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Builder;

namespace dotnetCampus.Autofac.Annotation.AutofacHelper
{
    internal static class RegistrationBuilderExtension
    {
        /// <summary>
        /// 根据 <see cref="ComponentModel"/> 中的设置，自动注册。
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterAuto(
                this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
                    registration, ComponentModel component)
        {
            if (component.IsOnlyRegisterProperties)
            {
                return registration;
            }

            if (component.Service == null)
            {
                return registration.AsSelf().AsImplementedInterfaces();
            }
            else
            {
                return registration.As(component.Service);
            }
        }

        /// <summary>
        /// 根据 <see cref="ComponentModel"/> 中的设置，自动设置 Scope。
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            SetScopeAuto(
                this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
                    registration, ComponentModel component)
        {
            if (component.IsOnlyRegisterProperties)
            {
                return registration;
            }

            switch (component.AutofacScope)
            {
                case AutofacScope.Default:
                case AutofacScope.InstancePerDependency:
                    return registration.InstancePerDependency();
                case AutofacScope.InstancePerLifetimeScope:
                    return registration.InstancePerLifetimeScope();
                case AutofacScope.InstancePerRequest:
                    return registration.InstancePerRequest();
                case AutofacScope.SingleInstance:
                    return registration.SingleInstance();
            }
            return registration;
        }

    }
}
