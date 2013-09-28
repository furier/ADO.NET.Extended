#region File Header

// //////////////////////////////////////////////////////
// /// File: ScriptBundle.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System.Collections.Generic;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Utilities.Lists;

#endregion

namespace ADO.NET.Extended.Connection.Database.Implementation
{
    /// <summary>   Collection of scripts. </summary>
    /// <remarks>   Sander Struijk, 24.07.2013. </remarks>
    public class ScriptBundle : object
    {
        /// <summary>   Gets or sets the script. </summary>
        /// <value> The script. </value>
        public string Script { get; set; }

        /// <summary>   Gets or sets the commands. </summary>
        /// <value> The commands. </value>
        public ICollection<ICommand> Commands { get; set; }

        /// <summary>   Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:System.Object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var scriptBundle = obj as ScriptBundle;
            if (scriptBundle == null) return false;
            return Script.Equals(scriptBundle.Script) && Commands.AreEqual(scriptBundle.Commands);
        }

        /// <summary>   Serves as a hash function for a particular type. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <seealso cref="M:System.Object.GetHashCode()"/>
        public override int GetHashCode()
        {
            return Script.GetHashCode() + Commands.GetHashCode(); //Commands.Sum(command => command.GetHashCode());
        }
    }
}