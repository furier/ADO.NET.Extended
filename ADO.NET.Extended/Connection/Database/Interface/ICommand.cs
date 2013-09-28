#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface ICommand
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        string Value { get; }
    }
}
