#region File Header

// //////////////////////////////////////////////////////
// /// File: IMySqlCommand.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Connection.Database.MySQL.Interface
{
    /// <summary>   Interface for my SQL command. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:ICommand"/>
    internal interface IMySqlCommand : ICommand {}
}