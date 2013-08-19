#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="MySqlConnectionFactory.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.MySQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MySQL.Implementation
{
    internal class MySqlConnectionFactory : IMySqlConnectionFactory
    {
        public IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            throw new NotImplementedException();
        }

        public T CreateConnection<T>(IConnectionStringBuilder connectionStringBuilder) where T : IConnection
        {
            throw new NotImplementedException();
        }
    }
}