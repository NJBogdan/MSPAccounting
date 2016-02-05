using System;
using System.Linq.Expressions;

namespace MSPAccounting.Helpers
{
    class Utilities
    {
        public string GetPropertyName<T>(Expression<Func<T>> expr)
        {
            MemberExpression body = (MemberExpression)expr.Body;
            return body.Member.Name;
        }
    }
}
