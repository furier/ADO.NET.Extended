#region File Header

// //////////////////////////////////////////////////////
// /// File: ICommand.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>   Author: Sander Struijk Interface ICommand. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    public interface ICommand
    {
        /// <summary>   Gets the value. </summary>
        /// <value> The value. </value>
        string Value { get; }
    }
}