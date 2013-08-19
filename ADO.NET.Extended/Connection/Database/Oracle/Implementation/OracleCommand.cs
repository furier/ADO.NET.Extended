#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleCommand.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using ADO.NET.Extended.Connection.Database.Oracle.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class OracleCommand
    /// </summary>
    public class OracleCommand : IOracleCommand
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; private set; }

        public OracleCommand(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            var cmd = obj as OracleCommand;
            if(cmd == null) return false;
            return Value.Equals(cmd.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}