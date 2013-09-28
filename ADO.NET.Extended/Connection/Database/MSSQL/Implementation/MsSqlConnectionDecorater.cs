#region File Header

// //////////////////////////////////////////////////////
// /// File: MsSqlConnectionDecorater.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Data;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.MSSQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Implementation
{
    /// <summary>   Milliseconds SQL connection decorater. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.MSSQL.Interface.IMsSqlConnectionDecorater"/>
    internal class MsSqlConnectionDecorater : IMsSqlConnectionDecorater
    {
        /// <summary>   Event queue for all listeners interested in Disposed events. </summary>
        public event EventHandler Disposed;

        /// <summary>   Event queue for all listeners interested in Opened events. </summary>
        public event EventHandler Opened;

        /// <summary>   Event queue for all listeners interested in Closed events. </summary>
        public event EventHandler Closed;

        /// <summary>   Gets or sets the state. </summary>
        /// <value> The state. </value>
        public ConnectionState State { get; private set; }

        /// <summary>   Gets or sets the data source. </summary>
        /// <value> The data source. </value>
        public string DataSource { get; private set; }

        /// <summary>   Gets the open. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <returns>   . </returns>
        public IConnection Open()
        {
            throw new NotImplementedException();
        }

        /// <summary>   Closes this object. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the non query operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="sql">  The SQL. </param>
        /// <param name="args"> A variable-length parameters list containing arguments. </param>
        /// <returns>   . </returns>
        public int ExecuteNonQuery(string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the scalar operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="sql">  The SQL. </param>
        /// <param name="args"> A variable-length parameters list containing arguments. </param>
        /// <returns>   . </returns>
        public object ExecuteScalar(string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the reader operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="disposeConnection">    true to dispose connection. </param>
        /// <param name="sql">                  The SQL. </param>
        /// <param name="args">                 A variable-length parameters list containing arguments. </param>
        /// <returns>   . </returns>
        public IDbDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the SQL file operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="filePath"> Full pathname of the file. </param>
        public void ExecuteSqlFile(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the SQL script operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="sqlScript">    The SQL script. </param>
        public void ExecuteSqlScript(string sqlScript)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Executes the commands operation. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        /// <param name="commands"> The commands. </param>
        public void ExecuteCommands(ICollection<ICommand> commands)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <exception cref="NotImplementedException">  Thrown when the requested operation is unimplemented. </exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>   Event queue for all listeners interested in Created events. </summary>
        public event EventHandler Created;
    }
}