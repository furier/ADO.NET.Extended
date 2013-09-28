#region File Header

// //////////////////////////////////////////////////////
// /// File: IOracleConnectionDecorater.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Interface
{
    /// <summary>   Author: Sander Struijk Interface IOracleConnectionDecorater. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:IConnection"/>
    public interface IOracleConnectionDecorater : IConnection
    {
        /// <summary>   Executes the reader operation. </summary>
        /// <param name="disposeConnection">    true to dispose connection. </param>
        /// <param name="sql">                  The SQL. </param>
        /// <param name="args">                 A variable-length parameters list containing arguments. </param>
        /// <returns>   . </returns>
        IOracleDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args);

        /// <summary>   Gets the open. </summary>
        /// <returns>   . </returns>
        IOracleConnectionDecorater Open();
    }
}