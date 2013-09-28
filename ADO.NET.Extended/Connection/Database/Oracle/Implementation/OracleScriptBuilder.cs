#region File Header

// //////////////////////////////////////////////////////
// /// File: OracleScriptBuilder.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ADO.NET.Extended.Connection.Database.Implementation;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Interface;
using ADO.NET.Extended.Utilities.Lists;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>   Oracle script builder. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ADO.NET.Extended.Connection.Database.Oracle.Interface.IOracleScriptBuilder"/>
    public class OracleScriptBuilder : IOracleScriptBuilder
    {
        /// <summary>   Creates this object. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="commands"> The commands. </param>
        /// <returns>   . </returns>
        public string Create(ICollection<ICommand> commands)
        {
            return Create(commands, 0);
        }

        /// <summary>   Creates this object. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="commands">     The commands. </param>
        /// <param name="batchSize">    Size of the batch. </param>
        /// <returns>   . </returns>
        public string Create(ICollection<ICommand> commands, int batchSize)
        {
            if (commands.Count <= batchSize || batchSize == 0) return CreateScript(commands);
            var commandBatches = commands.Split(batchSize);
            var script = string.Empty;
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (var commandBatch in commandBatches) // ReSharper restore LoopCanBeConvertedToQuery
                script += string.Format(@"{1}{0}{0}/{0}{0}", Environment.NewLine, CreateScript(commandBatch));
            return script;
        }

        /// <summary>   Creates script bundles. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="commands">     The commands. </param>
        /// <param name="batchSize">    Size of the batch. </param>
        /// <returns>   The new script bundles. </returns>
        public ICollection<ScriptBundle> CreateScriptBundles(ICollection<ICommand> commands, int batchSize)
        {
            if (commands.Count <= batchSize || batchSize == 0) return new Collection<ScriptBundle> {new ScriptBundle {Script = CreateScript(commands), Commands = commands}};
            var commandBatches = commands.Split(batchSize);
            return commandBatches.Select(CreateScriptCollection).ToList();
        }

        /// <summary>   Creates script collection. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="commands"> The commands. </param>
        /// <returns>   The new script collection. </returns>
        private ScriptBundle CreateScriptCollection(ICollection<ICommand> commands)
        {
            var script = CreateScript(commands);
            return new ScriptBundle {Script = script, Commands = commands};
        }

        /// <summary>   Creates a script. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="commands"> The commands. </param>
        /// <returns>   The new script. </returns>
        private string CreateScript(IEnumerable<ICommand> commands)
        {
            //Create an empty string to contain the script
            var script = string.Empty;
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (var command in commands.Where(x => !string.IsNullOrEmpty(x.Value)).ToList()) // ReSharper restore LoopCanBeConvertedToQuery
            {
                //put them together to be executed as a pl/sql block
                //trim any semicolonds of the command at the end of the string
                if (string.IsNullOrEmpty(command.Value)) continue;
                script += string.Format("EXECUTE IMMEDIATE ('{0}');{1}", command.Value.TrimEnd(';'), Environment.NewLine);
            }
            //The start and end of the pl/sql block
            var begin = string.Format("BEGIN{0}", Environment.NewLine);
            var end = string.Format("END;{0}", Environment.NewLine);
            //put the block together
            script = string.Format("{0}{1}{2}", begin, script, end);
            return script;
        }
    }
}