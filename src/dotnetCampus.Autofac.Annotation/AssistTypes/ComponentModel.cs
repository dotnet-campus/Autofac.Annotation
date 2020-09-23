using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetCampus.Autofac.Annotation
{
    public class ComponentModel
    {
        /// <summary>
        /// 当前类所在类型
        /// </summary>
        public Type CurrentType { get; }

        /// <summary>
        /// 注册单个的类型
        /// </summary>
        public Type? Service { get; set; }

        /// <summary>
        /// 作用域
        /// </summary>
        public AutofacScope AutofacScope { get; set; } = AutofacScope.Default;

        /// <summary>
        /// 是否仅进行属性注入。(默认 true)
        /// 如果是，则不进行类型注册。
        /// </summary>
        public bool IsOnlyRegisterProperties { get; set; } = true;

        public ComponentModel(Type currentType)
        {
            CurrentType = currentType;
        }

    }
}
