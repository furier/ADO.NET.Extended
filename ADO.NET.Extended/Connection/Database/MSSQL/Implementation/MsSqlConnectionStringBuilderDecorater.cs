#region File Header

// //////////////////////////////////////////////////////
// /// File: MsSqlConnectionStringBuilderDecorater.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.MSSQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Implementation
{
    /// <summary>   Milliseconds SQL connection string builder decorater. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.MSSQL.Interface.IMsSqlConnectionStringBuilderDecorater"/>
    internal class MsSqlConnectionStringBuilderDecorater : IMsSqlConnectionStringBuilderDecorater
    {
        /// <summary>   Gets or sets the host. </summary>
        /// <value> The host. </value>
        public string Host { get; set; }

        /// <summary>   Gets or sets the name of the user. </summary>
        /// <value> The name of the user. </value>
        public string UserName { get; set; }

        /// <summary>   Gets or sets the password. </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary>   Gets or sets the connection string. </summary>
        /// <value> The connection string. </value>
        public string ConnectionString { get; set; }

        /// <summary>   Gets or sets a value indicating whether this object use single sign on. </summary>
        /// <value> true if use single sign on, false if not. </value>
        public bool UseSingleSignOn { get; set; }
    }
}