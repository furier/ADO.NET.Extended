#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleConnectionDecorater.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text.RegularExpressions;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions;
using Oracle.DataAccess.Client;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>
    ///     Class OracleConnectionDecorater
    /// </summary>
    public class OracleConnectionDecorater : IOracleConnectionDecorater
    {
        #region Fields

        /// <summary>
        ///     The match oracle blocks
        /// </summary>
        protected const string MatchOracleBlocks = "((BEGIN|DECLARE).*?^END;)";

        /// <summary>
        ///     The new line slash new line
        /// </summary>
        protected static readonly string NewLineSlashNewLine = string.Format("({0}/{0})", Environment.NewLine);

        /// <summary>
        ///     The single oracle comment line
        /// </summary>
        protected const string SingleOracleCommentLine = "(?:^--.*)";

        /// <summary>
        ///     The open connection exception text.
        /// </summary>
        protected const string OpenConnectionExceptionText = "Failed to open connection\n" +
                                                             "ConnectionString: {0}\n" +
                                                             "ProductVersion: {1}\n" +
                                                             "Location: {2}\n" +
                                                             "Windows Account: {3}";

        /// <summary>
        ///     The close connection exception text.
        /// </summary>
        protected const string CloseConnectionExceptionText = "Failed to close the connection, DataSource: {0}";

        /// <summary>
        ///     The failed to run SQL command.
        /// </summary>
        protected const string FailedToRunSQLCommand = "[ Failed to run SQL Command @ {0}: {1} ]";

        /// <summary>
        ///     The _command
        /// </summary>
        protected global::Oracle.DataAccess.Client.OracleCommand Command;

        /// <summary>
        ///     The _connection
        /// </summary>
        protected OracleConnection Connection;

        /// <summary>
        ///     The _connection string
        /// </summary>
        protected string ConnectionString;

        /// <summary>
        ///     The script builder.
        /// </summary>
        protected internal IOracleScriptBuilder ScriptBuilder;

        #endregion

        #region Constructors

        /// <summary>
        /// </summary>
        public OracleConnectionDecorater()
        {
            ScriptBuilder = new OracleScriptBuilder();
            Connection = new OracleConnection();
            Command = new global::Oracle.DataAccess.Client.OracleCommand {Connection = Connection};
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionDecorater" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public OracleConnectionDecorater(string connectionString)
        {
            ScriptBuilder = new OracleScriptBuilder();
            ConnectionString = connectionString;
            Connection = new OracleConnection(connectionString);
            Command = new global::Oracle.DataAccess.Client.OracleCommand {Connection = Connection};
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionDecorater" /> class.
        /// </summary>
        /// <param name="connectionStringBuilder">The connection string builder.</param>
        public OracleConnectionDecorater(IOracleConnectionStringBuilderDecorater connectionStringBuilder)
        {
            ScriptBuilder = new OracleScriptBuilder();
            ConnectionString = connectionStringBuilder.ConnectionString;
            Connection = new OracleConnection(connectionStringBuilder.ConnectionString);
            Command = new global::Oracle.DataAccess.Client.OracleCommand {Connection = Connection};
        }

        #endregion
        
        /// <summary>
        ///     Throws the failed to run SQL sql exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>OracleSqlCommandException.</returns>
        protected virtual OracleSqlCommandException ThrowFailedToRunSqlCommandException(Exception ex)
        {
            var exceptionMessage = string.Format(FailedToRunSQLCommand, Connection.DataSource, Command.CommandText);
            return new OracleSqlCommandException(exceptionMessage, ex);
        }

        #region Public Members

        /// <summary>
        ///     Event queue for all listeners interested in Disposed events.
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        ///     Executes the dispose action.
        /// </summary>
        /// <remarks>
        ///     SASTRU, 30.07.2013.
        /// </remarks>
        protected virtual void OnDispose()
        {
            var handler = Disposed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Event queue for all listeners interested in Opened events.
        /// </summary>
        public event EventHandler Opened;

        /// <summary>
        ///     Executes the open action.
        /// </summary>
        /// <remarks>
        ///     SASTRU, 30.07.2013.
        /// </remarks>
        protected virtual void OnOpen()
        {
            var handler = Opened;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Event queue for all listeners interested in Closed events.
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        ///     Executes the close action.
        /// </summary>
        /// <remarks>
        ///     SASTRU, 30.07.2013.
        /// </remarks>
        protected virtual void OnClose()
        {
            var handler = Closed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        ///     The State of the connection
        /// </summary>
        /// <value>The state.</value>
        public virtual ConnectionState State
        {
            get { return Connection.State; }
        }

        /// <summary>
        ///     Address to target host
        /// </summary>
        /// <value>The data source.</value>
        public virtual string DataSource
        {
            get { return Connection.DataSource; }
        }

        /// <summary>
        ///     Opens the connection and returns itself
        /// </summary>
        /// <returns>IConnection.</returns>
        /// <exception cref="OracleConnectionException"></exception>
        public virtual IOracleConnectionDecorater Open()
        {
            try
            {
                Connection.Open();
                OnOpen();
                return this;
            }
            catch(Exception ex)
            {
                var assembly = Assembly.GetAssembly(typeof(OracleConnection));
                var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
                var location = assembly.Location;
                var currentUser = WindowsIdentity.GetCurrent();
                throw new OracleConnectionException(string.Format(OpenConnectionExceptionText,
                                                                  ConnectionString,
                                                                  version,
                                                                  location,
                                                                  currentUser),
                                                    ex);
            }
        }

        /// <summary>
        ///     Opens the connection and returns itself
        /// </summary>
        /// <returns>IConnection.</returns>
        IConnection IConnection.Open()
        {
            return Open();
        }

        /// <summary>
        ///     Closes the ConnectionBase
        /// </summary>
        /// <exception cref="OracleConnectionException"></exception>
        public virtual void Close()
        {
            try
            {
                Connection.Close();
                OnClose();
            }
            catch(Exception ex)
            {
                throw new OracleConnectionException(string.Format(CloseConnectionExceptionText, DataSource), ex);
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            Command.Dispose();
            Connection.Dispose();
            OnDispose();
        }

        /// <summary>
        ///     executes a query with no return value, executes the supplied sql with arguments if supplied
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="args">The args.</param>
        /// <returns>System.Int32.</returns>
        public virtual int ExecuteNonQuery(string sql, params object[] args)
        {
            try
            {
                Command.CommandText = args.Length > 0 ? string.Format(sql, args) : sql;
                return Command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ThrowFailedToRunSqlCommandException(ex);
            }
        }

        /// <summary>
        ///     Executes the scalar.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="args">The args.</param>
        /// <returns>System.Object.</returns>
        public virtual object ExecuteScalar(string sql, params object[] args)
        {
            try
            {
                Command.CommandText = args.Length > 0 ? string.Format(sql, args) : sql;
                return Command.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw ThrowFailedToRunSqlCommandException(ex);
            }
        }

        /// <summary>
        ///     executes a query where return values are expected executes the supplied sql with arguments if supplied
        /// </summary>
        /// <param name="disposeConnection"></param>
        /// <param name="sql">The SQL.</param>
        /// <param name="args">The args.</param>
        /// <returns>DbDataReader.</returns>
        IDbDataReader IConnection.ExecuteReader(bool disposeConnection, string sql, params object[] args)
        {
            return ExecuteReader(disposeConnection, sql, args);
        }

        /// <summary>
        ///     executes a query where return values are expected executes the supplied sql with arguments if supplied
        /// </summary>
        /// <param name="disposeConnection"></param>
        /// <param name="sql">The SQL.</param>
        /// <param name="args">The args.</param>
        /// <returns>DbDataReader.</returns>
        public virtual IOracleDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args)
        {
            try
            {
                Command.CommandText = args.Length > 0 ? string.Format(sql, args) : sql;
                return disposeConnection ? new OracleDataReader(Command.ExecuteReader(), this) : new OracleDataReader(Command.ExecuteReader());
            }
            catch(Exception ex)
            {
                throw ThrowFailedToRunSqlCommandException(ex);
            }
        }

        /// <summary>
        ///     Trys to execute whatever is inside the file found under the path supplied
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public virtual void ExecuteSqlFile(string filePath)
        {
            var file = new StreamReader(filePath);
            var script = file.ReadToEnd();
            file.Close();
            ExecuteSqlScript(script);
        }

        /// <summary>
        ///     Trys to execute whatever script is supplied in the parameter
        /// </summary>
        /// <param name="sqlScript">The SQL script.</param>
        public virtual void ExecuteSqlScript(string sqlScript)
        {
            //Regex to trim away all comments in an sql script
            sqlScript = Regex.Replace(sqlScript, SingleOracleCommentLine, "", RegexOptions.Multiline);
            //Regex to split the script into executable blocks or singe sql statements.
            var commands = Regex.Split(sqlScript, NewLineSlashNewLine, RegexOptions.Multiline).ToList();
            //Remove garbage in the list with commands to run against the oracle data base.
            commands.RemoveAll(x => x.Equals(NewLineSlashNewLine.Trim('(', ')')) || string.IsNullOrEmpty(x.Trim()));
            //Run all the commands with a loop
            foreach(var command in commands)
            {
                try
                {
                    //Set sql text and execute
                    Command.CommandText = Regex.IsMatch(command, MatchOracleBlocks, RegexOptions.Multiline | RegexOptions.Singleline) ? command : command.TrimEnd(';');
                    Command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw ThrowFailedToRunSqlCommandException(ex);
                }
            }
        }

        /// <summary>
        ///     Send in a list of sql commands,
        ///     they will be executed in one transaction
        /// </summary>
        /// <param name="commands">The commands.</param>
        public virtual void ExecuteCommands(ICollection<ICommand> commands)
        {
            if(!commands.Any()) return;
            var script = ScriptBuilder.Create(commands);
            try
            {
                //execute the anonymous pl/sql block in one transaction.
                ExecuteNonQuery(script);
            }
            catch(Exception ex)
            {
                var successfullCommands = new List<string>();
                var failedCommands = new List<string>();
                foreach(var command in commands)
                {
                    try
                    {
                        ExecuteNonQuery(command.Value);
                        successfullCommands.Add(command.Value);
                    }
                    catch(Exception exc)
                    {
                        failedCommands.Add(command.Value);
                    }
                }
            }
        }

        #endregion
    }
}