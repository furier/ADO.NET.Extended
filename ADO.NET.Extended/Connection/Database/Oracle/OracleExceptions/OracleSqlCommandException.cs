#region File Header

// //////////////////////////////////////////////////////
// /// File: OracleSqlCommandException.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.OracleExceptions
{
    /// <summary>   Author: Sander Struijk Class OracleSqlCommandException. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:System.Exception"/>
    public class OracleSqlCommandException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="message">          The error message that explains the reason for the exception. </param>
        /// <param name="innerException">   The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public OracleSqlCommandException(string message, Exception innerException) : base(message, innerException) {}

        /// <summary>   Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="message">  The message that describes the error. </param>
        public OracleSqlCommandException(string message) : base(message) {}

        /// <summary>   Initializes a new instance of the <see cref="OracleSqlCommandException" /> class. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        public OracleSqlCommandException() {}
    }
}