#region File Header

// //////////////////////////////////////////////////////
// /// File: OracleCommand.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.Oracle.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>   Author: Sander Struijk Class OracleCommand. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.Oracle.Interface.IOracleCommand"/>
    public class OracleCommand : IOracleCommand
    {
        /// <summary>   Constructor. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="value">    The value. </param>
        public OracleCommand(string value)
        {
            Value = value;
        }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; private set; }

        /// <summary>   Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:System.Object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var cmd = obj as OracleCommand;
            if (cmd == null) return false;
            return Value.Equals(cmd.Value);
        }

        /// <summary>   Serves as a hash function for a particular type. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:System.Object.GetHashCode()"/>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}