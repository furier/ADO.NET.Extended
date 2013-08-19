#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="MsSqlConnectionStringBuilderDecorater.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using ADO.NET.Extended.Connection.Database.MSSQL.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Implementation
{
    internal class MsSqlConnectionStringBuilderDecorater : IMsSqlConnectionStringBuilderDecorater
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
        public bool UseSingleSignOn { get; set; }
    }
}