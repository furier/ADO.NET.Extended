#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleDataReader.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting;
using ADO.NET.Extended.Connection.Database.Implementation;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class OracleDataReader
    /// </summary>
    public class OracleDataReader : IOracleDataReader
    {
        /// <summary>
        ///     The _connection
        /// </summary>
        private readonly IConnection _connection;

        /// <summary>
        ///     The _DB data reader
        /// </summary>
        private readonly DbDataReader _dbDataReader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleDataReader" /> class.
        /// </summary>
        /// <param name="dbDataReader">The db data reader.</param>
        /// <param name="connection">The connection.</param>
        public OracleDataReader(DbDataReader dbDataReader, IConnection connection)
        {
            _dbDataReader = dbDataReader;
            _connection = connection;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleDataReader" /> class.
        /// </summary>
        /// <param name="dbDataReader">The db data reader.</param>
        public OracleDataReader(DbDataReader dbDataReader)
        {
            _dbDataReader = dbDataReader;
            _connection = null;
        }

        /// <summary>
        ///     Gets the index of the column.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="OracleDataReaderException"></exception>
        /// <exception cref="ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions.OracleDataReaderException"></exception>
        public int GetColumnIndex(string name)
        {
            try
            {
                return _dbDataReader.GetOrdinal(name);
            }
            catch(Exception ex)
            {
                throw new OracleDataReaderException(string.Format("Expected column: {0} not found", name), ex);
            }
        }

        /// <summary>
        ///     Gets the column value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="OracleDataReaderException"></exception>
        /// <exception cref="ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions.OracleDataReaderException"></exception>
        public object GetColumnValue(string name)
        {
            try
            {
                return _dbDataReader[GetColumnIndex(name)];
            }
            catch(Exception ex)
            {
                throw new OracleDataReaderException(string.Format("GetColumnValue failed to get row value from column {0}", name), ex);
            }
        }

        /// <summary>
        ///     Closes this instance.
        /// </summary>
        public void Close()
        {
            if (_connection != null)
                _connection.Close();
            _dbDataReader.Close();
        }

        /// <summary>
        ///     Creates the obj ref.
        /// </summary>
        /// <param name="requestedType">Type of the requested.</param>
        /// <returns>ObjRef.</returns>
        public ObjRef CreateObjRef(Type requestedType)
        {
            return _dbDataReader.CreateObjRef(requestedType);
        }

        /// <summary>
        ///     Gets the depth.
        /// </summary>
        /// <value>The depth.</value>
        public int Depth
        {
            get { return _dbDataReader.Depth; }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if(_connection != null)
                _connection.Dispose();
            _dbDataReader.Dispose();
        }

        /// <summary>
        ///     Gets the field count.
        /// </summary>
        /// <value>The field count.</value>
        public int FieldCount
        {
            get { return _dbDataReader.FieldCount; }
        }

        /// <summary>
        ///     Gets the boolean.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>
        ///     <c>true</c> if XXXX, <c>false</c> otherwise
        /// </returns>
        public bool GetBoolean(int ordinal)
        {
            return _dbDataReader.GetBoolean(ordinal);
        }

        /// <summary>
        ///     Gets the byte.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Byte.</returns>
        public byte GetByte(int ordinal)
        {
            return _dbDataReader.GetByte(ordinal);
        }

        /// <summary>
        ///     Gets the bytes.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="dataOffset">The data offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bufferOffset">The buffer offset.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.Int64.</returns>
        public long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _dbDataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        ///     Gets the char.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Char.</returns>
        public char GetChar(int ordinal)
        {
            return _dbDataReader.GetChar(ordinal);
        }

        /// <summary>
        ///     Gets the chars.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="dataOffset">The data offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bufferOffset">The buffer offset.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.Int64.</returns>
        public long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return _dbDataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        ///     Gets the data.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader GetData(int i)
        {
            return ((IDataRecord)_dbDataReader).GetData(i);
        }

        /// <summary>
        ///     Gets the name of the data type.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.String.</returns>
        public string GetDataTypeName(int ordinal)
        {
            return _dbDataReader.GetDataTypeName(ordinal);
        }

        /// <summary>
        ///     Gets the date time.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.DateTime.</returns>
        public DateTime GetDateTime(int ordinal)
        {
            return _dbDataReader.GetDateTime(ordinal);
        }

        /// <summary>
        ///     Gets the decimal.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetDecimal(int ordinal)
        {
            return _dbDataReader.GetDecimal(ordinal);
        }

        /// <summary>
        ///     Gets the double.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Double.</returns>
        public double GetDouble(int ordinal)
        {
            return _dbDataReader.GetDouble(ordinal);
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            return _dbDataReader.GetEnumerator();
        }

        /// <summary>
        ///     Gets the type of the field.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>Type.</returns>
        public Type GetFieldType(int ordinal)
        {
            return _dbDataReader.GetFieldType(ordinal);
        }

        /// <summary>
        ///     Gets the float.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Single.</returns>
        public float GetFloat(int ordinal)
        {
            return _dbDataReader.GetFloat(ordinal);
        }

        /// <summary>
        ///     Gets the GUID.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>Guid.</returns>
        public Guid GetGuid(int ordinal)
        {
            return _dbDataReader.GetGuid(ordinal);
        }

        /// <summary>
        ///     Gets the int16.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Int16.</returns>
        public short GetInt16(int ordinal)
        {
            return _dbDataReader.GetInt16(ordinal);
        }

        /// <summary>
        ///     Gets the int32.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Int32.</returns>
        public int GetInt32(int ordinal)
        {
            return _dbDataReader.GetInt32(ordinal);
        }

        /// <summary>
        ///     Gets the int64.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Int64.</returns>
        public long GetInt64(int ordinal)
        {
            return _dbDataReader.GetInt64(ordinal);
        }

        /// <summary>
        ///     Gets the lifetime service.
        /// </summary>
        /// <returns>System.Object.</returns>
        public object GetLifetimeService()
        {
            return _dbDataReader.GetLifetimeService();
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.String.</returns>
        public string GetName(int ordinal)
        {
            return _dbDataReader.GetName(ordinal);
        }

        /// <summary>
        ///     Gets the ordinal.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int GetOrdinal(string name)
        {
            return _dbDataReader.GetOrdinal(name);
        }

        /// <summary>
        ///     Gets the type of the provider specific field.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>Type.</returns>
        public Type GetProviderSpecificFieldType(int ordinal)
        {
            return _dbDataReader.GetProviderSpecificFieldType(ordinal);
        }

        /// <summary>
        ///     Gets the provider specific value.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Object.</returns>
        public object GetProviderSpecificValue(int ordinal)
        {
            return _dbDataReader.GetProviderSpecificValue(ordinal);
        }

        /// <summary>
        ///     Gets the provider specific values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Int32.</returns>
        public int GetProviderSpecificValues(object[] values)
        {
            return _dbDataReader.GetProviderSpecificValues(values);
        }

        /// <summary>
        ///     Gets the schema table.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable GetSchemaTable()
        {
            return _dbDataReader.GetSchemaTable();
        }

        /// <summary>
        ///     Gets the string.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.String.</returns>
        public string GetString(int ordinal)
        {
            return _dbDataReader.GetString(ordinal);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Object.</returns>
        public object GetValue(int ordinal)
        {
            return _dbDataReader.GetValue(ordinal);
        }

        /// <summary>
        ///     Gets the values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Int32.</returns>
        public int GetValues(object[] values)
        {
            return _dbDataReader.GetValues(values);
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has rows.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has rows; otherwise, <c>false</c>.
        /// </value>
        public bool HasRows
        {
            get { return _dbDataReader.HasRows; }
        }

        /// <summary>
        ///     Initializes the lifetime service.
        /// </summary>
        /// <returns>System.Object.</returns>
        public object InitializeLifetimeService()
        {
            return _dbDataReader.InitializeLifetimeService();
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is closed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed
        {
            get { return _dbDataReader.IsClosed; }
        }

        /// <summary>
        ///     Determines whether [is DB null] [the specified ordinal].
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>
        ///     <c>true</c> if [is DB null] [the specified ordinal]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDBNull(int ordinal)
        {
            return _dbDataReader.IsDBNull(ordinal);
        }

        /// <summary>
        ///     Gets the <see cref="System.Object" /> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        public object this[string name]
        {
            get { return _dbDataReader[name]; }
        }

        /// <summary>
        ///     Gets the <see cref="System.Object" /> with the specified ordinal.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Object.</returns>
        public object this[int ordinal]
        {
            get { return _dbDataReader[ordinal]; }
        }

        /// <summary>
        ///     Nexts the result.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if XXXX, <c>false</c> otherwise
        /// </returns>
        public bool NextResult()
        {
            return _dbDataReader.NextResult();
        }

        /// <summary>
        ///     Reads this instance.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if XXXX, <c>false</c> otherwise
        /// </returns>
        public bool Read()
        {
            return _dbDataReader.Read();
        }

        /// <summary>
        ///     Gets the records affected.
        /// </summary>
        /// <value>The records affected.</value>
        public int RecordsAffected
        {
            get { return _dbDataReader.RecordsAffected; }
        }

        /// <summary>
        ///     Gets the visible field count.
        /// </summary>
        /// <value>The visible field count.</value>
        public int VisibleFieldCount
        {
            get { return _dbDataReader.VisibleFieldCount; }
        }

        /// <summary>
        ///     Creates the oracle object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>``0.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Get<T>() where T : DbObjectBase
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            foreach(var column in obj.Columns)
            {
                obj.SetColumn(column, GetColumnValue(column));
            }
            return obj;
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ICollection{``0}.</returns>
        public ICollection<T> GetAll<T>() where T : DbObjectBase
        {
            var returnValues = new Collection<T>();
            while(Read())
                returnValues.Add(Get<T>());
            return returnValues;
        }
    }
}