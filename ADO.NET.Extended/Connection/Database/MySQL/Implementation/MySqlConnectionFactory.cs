#region File Header

// //////////////////////////////////////////////////////
// /// File: MySqlConnectionFactory.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.MySQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MySQL.Implementation
{
    /// <summary>   My SQL connection factory. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.MySQL.Interface.IMySqlConnectionFactory"/>
    internal class MySqlConnectionFactory : IMySqlConnectionFactory
    {
        /// <summary>   Creates a connection. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="connectionStringBuilder">  The connection string builder. </param>
        /// <returns>   The new connection. </returns>
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Creates a connection. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="connectionStringBuilder">  The connection string builder. </param>
        /// <returns>   The new connection&lt; t&gt; </returns>
        public T CreateConnection<T>(IConnectionStringBuilder connectionStringBuilder) where T : IConnection
        {
            throw new NotImplementedException();
        }
    }
}