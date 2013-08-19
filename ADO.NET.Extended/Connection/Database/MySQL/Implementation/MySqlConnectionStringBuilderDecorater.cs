#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="MySqlConnectionStringBuilderDecorater.cs" company="Statoil">
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
    internal class MySqlConnectionStringBuilderDecorater : IMySqlConnectionStringBuilderDecorater
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
        public bool UseSingleSignOn { get; set; }
    }
}