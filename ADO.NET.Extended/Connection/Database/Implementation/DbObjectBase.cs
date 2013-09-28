#region File Header

// //////////////////////////////////////////////////////
// /// File: DbObjectBase.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace ADO.NET.Extended.Connection.Database.Implementation
{
    /// <summary>   Author: Sander Struijk Class DbObject. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    public abstract class DbObjectBase
    {
        /// <summary>   Initializes a new instance of the <see cref="DbObjectBase" /> class. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        protected DbObjectBase()
        {
            Columns = new Collection<string>();
        }

        /// <summary>   Gets or sets the columns. </summary>
        /// <value> The columns. </value>
        public ICollection<string> Columns { get; protected set; }

        /// <summary>   Sets the column. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="name">     The name. </param>
        /// <param name="value">    The value. </param>
        public abstract void SetColumn(string name, object value);
    }
}