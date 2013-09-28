#region File Header

// //////////////////////////////////////////////////////
// /// File: ConnectionFactory.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

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
    /// <summary>   Author: Sander Struijk Class ConnectionFactory. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.Interface.IConnectionFactory"/>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>   Create a connection by supplying a connection string builder. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:ADO.NET.Extended.Connection.Database.Interface.IConnectionFactory.CreateConnection(IConnectionStringBuilder)"/>
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            if (connectionStringBuilder is IOracleConnectionStringBuilderDecorater) return new OracleConnectionDecorater(connectionStringBuilder as IOracleConnectionStringBuilderDecorater);
            if (connectionStringBuilder is IMsSqlConnectionStringBuilderDecorater) throw new NotImplementedException("The ConnectionFactory does not yet support the IMsSqlConnectionStringBuilderDecorater as input");
            if (connectionStringBuilder is IMySqlConnectionStringBuilderDecorater) throw new NotImplementedException("The ConnectionFactory does not yet support the IMySqlConnectionStringBuilderDecorater as input");
            throw new ConnectionException("Derived IConnectionStringBuilder type is not supported");
        }
    }
}