#region File Header

// //////////////////////////////////////////////////////
// /// File: IMsSqlConnectionDecorater.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MSSQL.Interface
{
    /// <summary>   Interface for milliseconds SQL connection decorater. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:IConnection"/>
    internal interface IMsSqlConnectionDecorater : IConnection {}
}