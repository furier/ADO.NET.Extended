#region File Header

// //////////////////////////////////////////////////////
// /// File: IConnection.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Data;

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>   Author: Sander Struijk Interface IConnection. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:IDisposable"/>
    public interface IConnection : IDisposable
    {
        /// <summary>   Returns the state of the connection. </summary>
        /// <value> The state. </value>
        ConnectionState State { get; }

        /// <summary>   Returns the DataSource. </summary>
        /// <value> The data source. </value>
        string DataSource { get; }

        /// <summary>   Event queue for all listeners interested in Disposed events. </summary>
        event EventHandler Disposed;

        /// <summary>   Event queue for all listeners interested in Opened events. </summary>
        event EventHandler Opened;

        /// <summary>   Event queue for all listeners interested in Closed events. </summary>
        event EventHandler Closed;

        /// <summary>   Opens the connection and returns itself. </summary>
        /// <returns>   IConnection. </returns>
        IConnection Open();

        /// <summary>   Closes the connection. </summary>
        void Close();

        /// <summary>   executes a query with no return value, executes the supplied sql with arguments if supplied. </summary>
        /// <param name="sql">  The SQL. </param>
        /// <param name="args"> The args. </param>
        /// <returns>   System.Int32. </returns>
        int ExecuteNonQuery(string sql, params object[] args);

        /// <summary>   Executes the scalar. </summary>
        /// <param name="sql">  The SQL. </param>
        /// <param name="args"> The args. </param>
        /// <returns>   System.Object. </returns>
        object ExecuteScalar(string sql, params object[] args);

        /// <summary>   executes a query where return values are expected executes the supplied sql with arguments if supplied. </summary>
        /// <param name="disposeConnection">    . </param>
        /// <param name="sql">                  The SQL. </param>
        /// <param name="args">                 The args. </param>
        /// <returns>   DbDataReader. </returns>
        IDbDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args);

        /// <summary>   Trys to execute whatever is inside the file found under the path supplied. </summary>
        /// <param name="filePath"> The file path. </param>
        void ExecuteSqlFile(string filePath);

        /// <summary>   Trys to execute whatever script is supplied in the parameter. </summary>
        /// <param name="sqlScript">    The SQL script. </param>
        void ExecuteSqlScript(string sqlScript);

        /// <summary>   Send in a list of sql commands, they will be executed in one transaction. </summary>
        /// <param name="commands"> The commands. </param>
        void ExecuteCommands(ICollection<ICommand> commands);
    }
}