#region File Header

// //////////////////////////////////////////////////////
// /// File: IConnectionFactory.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>   Author: Sander Struijk Interface IConnectionFactory. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    public interface IConnectionFactory
    {
        /// <summary>   Create a connection by supplying a connection string builder. </summary>
        /// <param name="connectionStringBuilder">  The connection string builder. </param>
        /// <returns>   IConnection. </returns>
        IConnection CreateConnection(IConnectionStringBuilder connectionStringBuilder);
    }
}