using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac.Util;
using dotnetCampus.Autofac.Annotation.AnnotationExtensions;

namespace dotnetCampus.Autofac.Annotation.AnnotationCore
{
    /// <summary>
    /// ComponentModel 探测
    /// 从程序集中，通过反射找出所有的 ComponentModel
    /// </summary>
    internal class ComponentTypeDetector
    {
        private readonly IList<Assembly> _assemblies;

        private readonly IComponentDetector? _componentDetector;

        public ComponentTypeDetector(Assembly[] assemblies) : this(assemblies, null)
        {
        }

        public ComponentTypeDetector(Assembly[] assemblies, IComponentDetector? componentDetector)
        {
            _assemblies = assemblies.Distinct().ToList();
            _componentDetector = componentDetector;
        }

        public List<ComponentModel> DetectComponentModels()
        {
            List<ComponentModel> result = new List<ComponentModel>();
            foreach (var assembly in _assemblies)
            {
                var models = DetectComponentModels(assembly);
                result.AddRange(models);
            }

            return result;
        }

        private List<ComponentModel> DetectComponentModels(Assembly assembly)
        {
            var types = assembly.GetLoadableTypes();
            return types
                .Where(type => type.IsClass && !type.IsAbstract)
                .Select(type => type.GetComponent(_componentDetector))
                .Where(c => c != null)
                .Select(c => c!).ToList();
        }

    }
}
