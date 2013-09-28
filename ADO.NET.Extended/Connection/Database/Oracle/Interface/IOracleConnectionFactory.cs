#region File Header

// //////////////////////////////////////////////////////
// /// File: IOracleConnectionFactory.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Interface
{
    /// <summary>   Author: Sander Struijk Interface IOracleConnectionFactory. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:IConnectionFactory"/>
    public interface IOracleConnectionFactory : IConnectionFactory
    {
        /// <summary>   Creates the connection. </summary>
        /// <param name="connectionStringBuilder">  The connection string builder. </param>
        /// <returns>   IOracleConnectionDecorater. </returns>
        IOracleConnectionDecorater CreateConnection(IOracleConnectionStringBuilderDecorater connectionStringBuilder);
    }
}