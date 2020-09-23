using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using dotnetCampus.Autofac.Annotation.AnnotationCore;
using Module = Autofac.Module;

namespace dotnetCampus.Autofac.Annotation
{
    public class AutofacAnnotationModule : Module
    {
        private readonly Assembly[] _assemblies;
        private IComponentDetector? ComponentDetector { get; set; }

        public AutofacAnnotationModule(params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                throw new InvalidOperationException("AutofacAnnotationModule Must Has Loading Assembly.");
            }
            _assemblies = assemblies;
        }

        public AutofacAnnotationModule SetComponentDetector(IComponentDetector componentDetector)
        {
            ComponentDetector = componentDetector;
            return this;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // 导出全部的 component 
            var componentModels = new ComponentTypeDetector(_assemblies, ComponentDetector).DetectComponentModels();

            // 进行类型注册
            new ComponentTypeRegister().RegisterTypes(builder, componentModels);
        }

    }


}
