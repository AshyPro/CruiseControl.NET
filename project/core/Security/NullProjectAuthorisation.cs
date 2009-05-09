﻿using Exortech.NetReflector;
using System;
using System.Collections.Generic;
using System.Text;
using ThoughtWorks.CruiseControl.Remote.Security;

namespace ThoughtWorks.CruiseControl.Core.Security
{
    [ReflectorType("nullProjectSecurity")]
    public class NullProjectAuthorisation
        : IProjectAuthorisation
    {
        #region Private fields
        #endregion

        #region Constructors
        /// <summary>
        /// Start a new blank instance.
        /// </summary>
        public NullProjectAuthorisation() { }
        #endregion

        #region Public properties
        #region RequiresServerSecurity
        /// <summary>
        /// Does this authorisation require security to be configured on the server?
        /// </summary>
        public bool RequiresServerSecurity
        {
            get { return false; }
        }
        #endregion
        #endregion

        #region Public methods
        #region RequiresSession
        /// <summary>
        /// Does this authorisation require a valid session?
        /// </summary>
        public bool RequiresSession(ISecurityManager manager)
        {
            return false;
        }
        #endregion

        #region CheckPermission()
        /// <summary>
        /// Checks whether the user can perform the specified action.
        /// </summary>
        /// <param name="userName">The name of the user that is being checked.</param>
        /// <param name="permission">The permission to check.</param>
        /// <param name="defaultRight">The default right to use.</param>
        /// <returns>True if the permission is valid, false otherwise.</returns>
        public virtual bool CheckPermission(ISecurityManager manager, 
            string userName, 
            SecurityPermission permission,
            SecurityRight defaultRight)
        {
            return true;
        }
        #endregion
        #endregion
    }
}
