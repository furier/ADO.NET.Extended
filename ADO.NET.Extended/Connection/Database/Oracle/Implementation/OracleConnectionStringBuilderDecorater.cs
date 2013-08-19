#region File Header

// // ***********************************************************************
// // Author           : Sander Struijk
// // ***********************************************************************
// // <copyright file="OracleConnectionStringBuilderDecorater.cs" company="Statoil">
// //     Copyright (c) Statoil. All rights reserved.
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

#endregion

#region Using statements

using ADO.NET.Extended.Connection.Database.Oracle.Interface;
using Oracle.DataAccess.Client;

#endregion

namespace ADO.NET.Extended.Connection.Database.Oracle.Implementation
{
    /// <summary>
    ///     Author: Sander Struijk
    ///     Class OracleConnectionStringBuilderDecorater
    /// </summary>
    public class OracleConnectionStringBuilderDecorater : IOracleConnectionStringBuilderDecorater
    {
        /// <summary>
        ///     The integrated security
        /// </summary>
        private const string IntegratedSecurity = "Integrated Security";

        /// <summary>
        ///     The _oracle connection string builder
        /// </summary>
        private readonly OracleConnectionStringBuilder _oracleConnectionStringBuilder;

        /// <summary>
        ///     The _integrated security used
        /// </summary>
        private bool _integratedSecurityUsed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionStringBuilderDecorater" /> class.
        /// </summary>
        public OracleConnectionStringBuilderDecorater()
        {
            _oracleConnectionStringBuilder = new OracleConnectionStringBuilder();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionStringBuilderDecorater" /> class.
        /// </summary>
        /// <param name="oracleConnectionStringBuilder">The oracle connection string builder.</param>
        public OracleConnectionStringBuilderDecorater(OracleConnectionStringBuilder oracleConnectionStringBuilder)
        {
            _oracleConnectionStringBuilder = oracleConnectionStringBuilder;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OracleConnectionStringBuilderDecorater" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public OracleConnectionStringBuilderDecorater(string connectionString)
        {
            _oracleConnectionStringBuilder = new OracleConnectionStringBuilder(connectionString);
        }

        /// <summary>
        ///     Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host
        {
            get { return _oracleConnectionStringBuilder.DataSource; }
            set { _oracleConnectionStringBuilder.DataSource = value; }
        }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get { return _oracleConnectionStringBuilder.UserID; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                    _oracleConnectionStringBuilder.UserID = value;
            }
        }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get { return _oracleConnectionStringBuilder.Password; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                    _oracleConnectionStringBuilder.Password = value;
            }
        }

        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return _oracleConnectionStringBuilder.ConnectionString; }
            set { _oracleConnectionStringBuilder.ConnectionString = value; }
        }

        /// <summary>
        ///     Gets or sets if the connection should be authenticated by username/password or by operating system's auth token
        /// </summary>
        /// <value>
        ///     <c>true</c> if [use single sign on]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSingleSignOn
        {
            get { return _oracleConnectionStringBuilder.ContainsKey(IntegratedSecurity) && _oracleConnectionStringBuilder[IntegratedSecurity].Equals("SSPI"); }
            set { SetSingleSignOnValues(value); }
        }

        /// <summary>
        ///     Sets the single sign on values.
        /// </summary>
        /// <param name="value">
        ///     if set to <c>true</c> [value].
        /// </param>
        private void SetSingleSignOnValues(bool value)
        {
            try
            {
                //if value is true then we are trying to set single sign on true!
                if(value)
                {
                    //if the Integrated Security key does not exist in the connection string builder dictionary, add it!
                    if(!_oracleConnectionStringBuilder.ContainsKey(IntegratedSecurity))
                        _oracleConnectionStringBuilder.Add(IntegratedSecurity, "SSPI");
                    else //if the Integrated Security exists then update it!
                        _oracleConnectionStringBuilder[IntegratedSecurity] = "SSPI";
                    //set local internal value that Integrated Security was used!
                    _integratedSecurityUsed = true;
                }
            }
            catch(OracleException)
            {
                //If an OracleException was thrown, the Integrated Security keyword was not supported in the connection string builder dictionary
                //So then we just set the username to be a slash "/" and password to be empty, and we set the local internal value that Integrated Security is not used!
                _oracleConnectionStringBuilder.UserID = "/";
                _oracleConnectionStringBuilder.Password = "";
                _integratedSecurityUsed = false;
            }
            //if value is true we are done, return!
            if(value) return;
            //if we get here we are trying to set use single sign on to false!
            //if Integrated Security has previously been used then we check if the key exist in the connection string builder dictionary and remove it
            if(_integratedSecurityUsed || _oracleConnectionStringBuilder.ContainsKey(IntegratedSecurity))
            {
                _oracleConnectionStringBuilder.Remove(IntegratedSecurity);
                _integratedSecurityUsed = false;
            }
                    //if the key did not exist or Integrated Security has not been used, just set the username to blank
            else
                _oracleConnectionStringBuilder.UserID = "";
        }
    }
}