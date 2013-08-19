#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="MySqlCommand.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using ADO.NET.Extended.Connection.Database.MySQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MySQL.Implementation
{
    internal class MySqlCommand : IMySqlCommand
    {
        public string Value { get; private set; }

        public MySqlCommand(string value)
        {
            Value = value;
        }
    }
}