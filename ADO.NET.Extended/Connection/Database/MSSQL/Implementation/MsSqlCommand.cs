#region File Header

// //////////////////////////////////////////////////////
// /// File: MsSqlCommand.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.MSSQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Implementation
{
    /// <summary>   Milliseconds SQL command. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.MSSQL.Interface.IMsSqlCommand"/>
    internal class MsSqlCommand : IMsSqlCommand
    {
        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; private set; }
    }
}