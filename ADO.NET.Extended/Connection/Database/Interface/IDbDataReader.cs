#region File Header

// //////////////////////////////////////////////////////
// /// File: IDbDataReader.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System.Collections.Generic;
using System.Data;
using ADO.NET.Extended.Connection.Database.Implementation;

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>   Author: Sander Struijk Interface IDbDataReader. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    /// <seealso cref="T:IDataReader"/>
    public interface IDbDataReader : IDataReader
    {
        /// <summary>   Gets a value indicating whether this instance has rows. </summary>
        /// <value> <c>true</c> if this instance has rows; otherwise, <c>false</c>. </value>
        bool HasRows { get; }

        /// <summary>   Gets all. </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <returns>   The all&lt; t&gt; </returns>
        ICollection<T> GetAll<T>() where T : DbObjectBase;
    }
}