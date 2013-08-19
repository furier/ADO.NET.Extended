#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="DbObjectBase.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace ADO.NET.Extended.Connection.Database.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class DbObject
    /// </summary>
    public abstract class DbObjectBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DbObjectBase" /> class.
        /// </summary>
        protected DbObjectBase()
        {
            Columns = new Collection<string>();
        }

        /// <summary>
        ///     Gets or sets the columns.
        /// </summary>
        /// <value>The columns.</value>
        public ICollection<string> Columns { get; protected set; }

        /// <summary>
        ///     Sets the column.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public abstract void SetColumn(string name, object value);
    }
}