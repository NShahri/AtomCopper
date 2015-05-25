// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtomData.cs" company="">
//   
// </copyright>
// <summary>
//   The atom data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AtomCopper.AtomProvider
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The atom data.
    /// </summary>
    /// <typeparam name="DataType">
    /// </typeparam>
    internal class AtomData<DataType> : IOrderedQueryable<DataType>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomData{DataType}"/> class. 
        ///     Initializes a new instance of the <see cref="AtomData"/> class.
        /// </summary>
        public AtomData()
        {
            this.Provider = new AtomQueryProvider();
            this.Expression = Expression.Constant(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomData{DataType}"/> class. 
        /// Initializes a new instance of the <see cref="AtomData"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        public AtomData(AtomQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<DataType>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            this.Provider = provider;
            this.Expression = expression;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the element type.
        /// </summary>
        public Type ElementType
        {
            get
            {
                return typeof(DataType);
            }
        }

        /// <summary>
        ///     Gets the expression.
        /// </summary>
        public Expression Expression { get; private set; }

        /// <summary>
        ///     Gets the provider.
        /// </summary>
        public IQueryProvider Provider { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The get enumerator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerator" />.
        /// </returns>
        public IEnumerator<DataType> GetEnumerator()
        {
            return this.Provider.Execute<IEnumerable<DataType>>(this.Expression).GetEnumerator();
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        ///     The get enumerator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerator" />.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

    /// <summary>
    ///     The atom data.
    /// </summary>
    public class AtomDataFactory
    {
        private readonly IEnumerable data;

        public AtomDataFactory(IEnumerable data)
        {
            this.data = data;
        }

        public IQueryable<IAtomModel> Atoms 
    }
}