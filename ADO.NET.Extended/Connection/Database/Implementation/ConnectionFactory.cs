#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="ConnectionFactory.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using ADO.NET.Extended.Connection.Database.Exceptions;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.MSSQL.Interface;
using ADO.NET.Extended.Connection.Database.MySQL.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Implementation;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class ConnectionFactory
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        ///     Create a connection by supplying a connection string builder
        /// </summary>
        /// <param name="connectionStringBuilder">The connection string builder.</param>
        /// <returns>IConnection.</returns>
        /// <exception cref="System.NotImplementedException">
        ///     The ConnectionFactory does not yet support the IMsSqlConnectionStringBuilderDecorater as input
        ///     or
        ///     The ConnectionFactory does not yet support the IMySqlConnectionStringBuilderDecorater as input
        /// </exception>
        /// <exception cref="ConnectionException">Derived IConnectionStringBuilder type is not supported</exception>
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            if(connectionStringBuilder is IOracleConnectionStringBuilderDecorater)
                return new OracleConnectionDecorater(connectionStringBuilder as IOracleConnectionStringBuilderDecorater);
            if(connectionStringBuilder is IMsSqlConnectionStringBuilderDecorater)
                throw new NotImplementedException("The ConnectionFactory does not yet support the IMsSqlConnectionStringBuilderDecorater as input");
            if(connectionStringBuilder is IMySqlConnectionStringBuilderDecorater)
                throw new NotImplementedException("The ConnectionFactory does not yet support the IMySqlConnectionStringBuilderDecorater as input");
            throw new ConnectionException("Derived IConnectionStringBuilder type is not supported");
        }
    }
}