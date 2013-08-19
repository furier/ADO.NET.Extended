using System.Collections.Generic;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Utilities.Lists;

namespace ADO.NET.Extended.Connection.Database.Implementation
{
    /// <summary>
    ///     Collection of scripts.
    /// </summary>
    /// <remarks>
    ///     Sastru, 24.07.2013.
    /// </remarks>
    public class ScriptBundle : object
    {
        /// <summary>
        ///     Gets or sets the script.
        /// </summary>
        /// <value>
        ///     The script.
        /// </value>
        public string Script { get; set; }

        /// <summary>
        ///     Gets or sets the commands.
        /// </summary>
        /// <value>
        ///     The commands.
        /// </value>
        public ICollection<ICommand> Commands { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var scriptBundle = obj as ScriptBundle;
            if (scriptBundle == null) return false;
            return Script.Equals(scriptBundle.Script) &&
                Commands.AreEqual(scriptBundle.Commands);
        }

        public override int GetHashCode()
        {
            return Script.GetHashCode() + Commands.GetHashCode(); //Commands.Sum(command => command.GetHashCode());
        }
    }
}