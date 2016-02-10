using MSPAccounting.Interfaces;
using MSPAccounting.Models;
using System;
using System.Collections.Generic;
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

        public IEnumerable<T> GetViewModelList<S,T>(List<S> records) where T : IViewModel where S : BaseModel<T>
        {
            foreach (var record in records)
            {     
                yield return (record as BaseModel<T>).ToViewModel();
            }
        }
    }
}
