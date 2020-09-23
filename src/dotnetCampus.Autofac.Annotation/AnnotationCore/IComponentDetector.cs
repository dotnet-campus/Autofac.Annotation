using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetCampus.Autofac.Annotation.AnnotationCore
{
    /// <summary>
    /// Component 探测器。
    /// 在不标记 <see cref="ComponentModel"/> 的情况下，批量导出符合条件的类型。
    /// </summary>
    public interface IComponentDetector
    {
        /// <summary>
        /// 如果期望将 <see cref="Type"/> 作为 <see cref="ComponentModel"/> 导出，则返回一个 <see cref="ComponentModel"/> 实例。
        /// 否则返回空。
        /// </summary>
        /// <param name="type">被检测的 <see cref="Type"/></param>
        /// <returns></returns>
        ComponentModel? Detect(Type type);
    }
}
