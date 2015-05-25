// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtomModel.cs" company="">
//   
// </copyright>
// <summary>
//   The atom model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AtomCopper.AtomProvider
{
    using System.Collections.Generic;

    /// <summary>
    ///     The atom model.
    /// </summary>
    internal class AtomModel : IAtomModel
    {
        #region Public Properties

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IEnumerable<string> Categories { get; private set; }

        #endregion
    }
}