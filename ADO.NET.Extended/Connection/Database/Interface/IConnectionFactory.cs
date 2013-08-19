#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="IConnectionFactory.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface IConnectionFactory
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        ///     Create a connection by supplying a connection string builder
        /// </summary>
        /// <param name="connectionStringBuilder">The connection string builder.</param>
        /// <returns>IConnection.</returns>
        IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder);
    }
}