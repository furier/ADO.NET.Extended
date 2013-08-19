#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="ICommand.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface ICommand
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        string Value { get; }
    }
}