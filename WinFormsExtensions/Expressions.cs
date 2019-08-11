using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsExtensions
{
    internal static class Expressions
    {
        internal static bool HasProperty(this Type type, string properyName)
        { return type.GetProperty(properyName) != null; }

        internal static string GetPropertyName<T, U>(this Expression<Func<T, U>> expression)
        {
            if (!(expression.Body is MemberExpression bodyMemberExpression))
            {
                UnaryExpression ubody = (UnaryExpression)expression.Body;
                bodyMemberExpression = ubody.Operand as MemberExpression;
            }

            return string.Join(".", bodyMemberExpression?.ToString()?.Split('.')?.Skip(1));
        }
    }
}
