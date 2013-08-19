#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="IConnectionStringBuilder.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

namespace ADO.NET.Extended.Connection.Database.Interface
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Interface, declaring the necessary properties for any custom connectionstringbuilder to implement in order to work with this solution.
    /// </summary>
    public interface IConnectionStringBuilder
    {
        /// <summary>
        ///     Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        string Host { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }

        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; set; }

        /// <summary>
        ///     Gets or sets if the connection should be authenticated by username/password or by operating system's auth token
        /// </summary>
        /// <value>
        ///     <c>true</c> if [use single sign on]; otherwise, <c>false</c>.
        /// </value>
        bool UseSingleSignOn { get; set; }
    }
}