#region File Header

// //////////////////////////////////////////////////////
// /// File: IScriptBuilder.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System.Collections.Generic;
using ADO.NET.Extended.Connection.Database.Implementation;

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>   Interface for script builder. </summary>
    /// <remarks>   Sander Struijk, 23.07.2013. </remarks>
    public interface IScriptBuilder
    {
        /// <summary>   Creates a script out of the provided commands. </summary>
        /// <param name="commands"> The commands. </param>
        /// <returns>   . </returns>
        string Create(ICollection<ICommand> commands);

        /// <summary>   Creates a script out of the provided commands. </summary>
        /// <param name="commands">     The commands. </param>
        /// <param name="batchSize">    Size of the batch. </param>
        /// <returns>   . </returns>
        string Create(ICollection<ICommand> commands, int batchSize);

        /// <summary>   Creates script batch bundles. </summary>
        /// <param name="commands">     The commands. </param>
        /// <param name="batchSize">    Size of the batch. </param>
        /// <returns>   The new script batch bundles. </returns>
        ICollection<ScriptBundle> CreateScriptBundles(ICollection<ICommand> commands, int batchSize);
    }
}