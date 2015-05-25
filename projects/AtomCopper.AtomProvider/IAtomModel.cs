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
    public interface IAtomModel
    {
        #region Public Properties

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<string> Categories { get; }

        #endregion
    }
}