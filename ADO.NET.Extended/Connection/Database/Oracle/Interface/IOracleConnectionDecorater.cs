#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="IOracleConnectionDecorater.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface IOracleConnectionDecorater
    /// </summary>
    public interface IOracleConnectionDecorater : IConnection
    {
        /// <summary>
        ///     Executes the reader.
        /// </summary>
        /// <param name="disposeConnection"></param>
        /// <param name="sql">The SQL.</param>
        /// <param name="args">The args.</param>
        /// <returns>IOracleDataReader.</returns>
#pragma warning disable 108,114
        IOracleDataReader ExecuteReader(bool disposeConnection, string sql, params object[] args);
#pragma warning restore 108,114

        /// <summary>
        ///     Opens this instance.
        /// </summary>
        /// <returns>IOracleConnectionDecorater.</returns>
#pragma warning disable 108,114
        IOracleConnectionDecorater Open();
#pragma warning restore 108,114
    }
}