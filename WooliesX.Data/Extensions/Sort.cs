using System;
using System.Linq;
using System.Linq.Expressions;
using WooliesX.Core.Infrastructure;
using WooliesX.Core.Models;

namespace WooliesX.Data.Extensions
{
    public static class SortExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, SortTerm sortTerm)
        {
            var searchProperty = typeof(T).GetProperty(sortTerm.Name);
            var parameter = Expression.Parameter(typeof(T), "o");

            var selectorExpr = Expression.Lambda(Expression.Property(parameter, sortTerm.Name), parameter);

            Expression queryExpr = source.Expression;

            MethodCallExpression methodCallExpression = Expression.Call(typeof(Queryable),
                sortTerm.Descending ? "OrderByDescending" : "OrderBy",
                new Type[] { source.ElementType, searchProperty.PropertyType },
                queryExpr,
                selectorExpr);

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
