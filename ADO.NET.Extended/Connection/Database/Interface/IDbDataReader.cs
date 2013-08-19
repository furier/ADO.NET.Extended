#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="IDbDataReader.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System.Collections.Generic;
using System.Data;
using ADO.NET.Extended.Connection.Database.Implementation;

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface IDbDataReader
    /// </summary>
    public interface IDbDataReader : IDataReader
    {
        /// <summary>
        ///     Gets a value indicating whether this instance has rows.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has rows; otherwise, <c>false</c>.
        /// </value>
        bool HasRows { get; }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <returns>
        ///     The all&lt; t&gt;
        /// </returns>
        ICollection<T> GetAll<T>() where T : DbObjectBase;
    }
}