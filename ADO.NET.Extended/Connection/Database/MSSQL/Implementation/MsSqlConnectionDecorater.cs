#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="MsSqlConnectionDecorater.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using System.Collections.Generic;
using System.Data;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.MSSQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Implementation
{
    internal class MsSqlConnectionDecorater : IMsSqlConnectionDecorater
    {
        public event EventHandler Created;
        public event EventHandler Disposed;
        public event EventHandler Opened;
        public event EventHandler Closed;
        public ConnectionState State { get; private set; }
        public string DataSource { get; private set; }

        public IConnection Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IDbDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void ExecuteSqlFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void ExecuteSqlScript(string sqlScript)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommands(ICollection<ICommand> commands)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}