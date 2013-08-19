#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleConnectionFactory.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class OracleConnectionFactory
    /// </summary>
    public class OracleConnectionFactory : IOracleConnectionFactory
    {
        /// <summary>
        ///     Creates the connection.
        /// </summary>
        /// <param name="connectionStringBuilder">The connection string builder.</param>
        /// <returns>IOracleConnectionDecorater.</returns>
        public IOracleConnectionDecorater CreateConnection(IOracleConnectionStringBuilderDecorater connectionStringBuilder)
        {
            return new OracleConnectionDecorater(connectionStringBuilder);
        }

        /// <summary>
        ///     Create a connection by supplying a connection string builder
        /// </summary>
        /// <param name="connectionStringBuilder">The connection string builder.</param>
        /// <returns>IConnection.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            throw new NotImplementedException();
        }
    }
}