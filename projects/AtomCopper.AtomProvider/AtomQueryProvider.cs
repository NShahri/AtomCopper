// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtomQueryProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The atom query provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AtomCopper.AtomProvider
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The atom query provider.
    /// </summary>
    public class AtomQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(AtomData<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AtomData<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return AtomQueryContext.Execute(expression, false);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            bool IsEnumerable = (typeof(TResult).Name == "IEnumerable`1");

            return (TResult)AtomQueryContext.Execute(expression, IsEnumerable);
        }
    }
}