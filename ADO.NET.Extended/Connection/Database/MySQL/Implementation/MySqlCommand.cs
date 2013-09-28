#region File Header

// //////////////////////////////////////////////////////
// /// File: MySqlCommand.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.MySQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MySQL.Implementation
{
    /// <summary>   My SQL command. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.MySQL.Interface.IMySqlCommand"/>
    internal class MySqlCommand : IMySqlCommand
    {
        /// <summary>   Constructor. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="value">    The value. </param>
        public MySqlCommand(string value)
        {
            Value = value;
        }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; private set; }
    }
}