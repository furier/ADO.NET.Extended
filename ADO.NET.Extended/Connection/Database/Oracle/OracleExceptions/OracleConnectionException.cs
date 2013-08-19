#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleConnectionException.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using System;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class OracleConnectionException
    /// </summary>
    public class OracleConnectionException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionException" /> class.
        /// </summary>
        public OracleConnectionException() {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OracleConnectionException(string message) : base(message) {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OracleConnectionException(string message, Exception innerException) : base(message, innerException) {}
    }
}