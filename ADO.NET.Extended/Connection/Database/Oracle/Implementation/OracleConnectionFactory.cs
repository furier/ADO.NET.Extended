#region File Header

// //////////////////////////////////////////////////////
// /// File: OracleConnectionFactory.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>   Author: Sander Struijk Class OracleConnectionFactory. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.Oracle.Interface.IOracleConnectionFactory"/>
    public class OracleConnectionFactory : IOracleConnectionFactory
    {
        /// <summary>   Creates the connection. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:ADO.NET.Extended.Connection.Database.Oracle.Interface.IOracleConnectionFactory.CreateConnection(IOracleConnectionStringBuilderDecorater)"/>
        public IOracleConnectionDecorater CreateConnection(IOracleConnectionStringBuilderDecorater connectionStringBuilder)
        {
            return new OracleConnectionDecorater(connectionStringBuilder);
        }

        /// <summary>   Create a connection by supplying a connection string builder. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="connectionStringBuilder">  The connection string builder. </param>
        /// <returns>   IConnection. </returns>
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            throw new NotImplementedException();
        }
    }
}