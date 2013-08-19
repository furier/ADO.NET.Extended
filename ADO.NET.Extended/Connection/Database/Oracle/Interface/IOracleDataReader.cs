#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="IOracleDataReader.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using System.Collections;
using System.Runtime.Remoting;
using ADO.NET.Extended.Connection.Database.Implementation;
using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface IOracleDataReader
    /// </summary>
    public interface IOracleDataReader : IDbDataReader
    {
        /// <summary>
        ///     Gets the visible field count.
        /// </summary>
        /// <value>The visible field count.</value>
        int VisibleFieldCount { get; }

        /// <summary>
        ///     Gets the index of the column.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        int GetColumnIndex(string name);

        /// <summary>
        ///     Gets the column value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        object GetColumnValue(string name);

        /// <summary>
        ///     Creates the obj ref.
        /// </summary>
        /// <param name="requestedType">Type of the requested.</param>
        /// <returns>ObjRef.</returns>
        ObjRef CreateObjRef(Type requestedType);

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        IEnumerator GetEnumerator();

        /// <summary>
        ///     Gets the lifetime service.
        /// </summary>
        /// <returns>System.Object.</returns>
        object GetLifetimeService();

        /// <summary>
        ///     Gets the type of the provider specific field.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>Type.</returns>
        Type GetProviderSpecificFieldType(int ordinal);

        /// <summary>
        ///     Gets the provider specific value.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Object.</returns>
        object GetProviderSpecificValue(int ordinal);

        /// <summary>
        ///     Gets the provider specific values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Int32.</returns>
        int GetProviderSpecificValues(object[] values);

        /// <summary>
        ///     Initializes the lifetime service.
        /// </summary>
        /// <returns>System.Object.</returns>
        object InitializeLifetimeService();

        /// <summary>
        ///     Creates the DbObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>``0.</returns>
        T Get<T>() where T : DbObjectBase;
    }
}