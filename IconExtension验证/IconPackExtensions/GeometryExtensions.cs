using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace IconExtension验证.IconPackExtensions
{
    /// <summary>
    /// 根据指定的枚举值返回对应的Geometry
    /// </summary>
    /// <typeparam name="TKind"></typeparam>
    public abstract class PackIconGeometryExtensions<TKind> : MarkupExtension where TKind : Enum
    {
        public TKind Kind { get; set; }

        protected abstract IDictionary<TKind, string> DataIndex { get; }

        protected PackIconGeometryExtensions(){}

        protected PackIconGeometryExtensions(TKind kind)
        {
            Kind = kind;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Geometry.Parse(DataIndex[Kind]);
        }
    }

}
