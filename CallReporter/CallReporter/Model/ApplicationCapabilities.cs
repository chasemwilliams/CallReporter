﻿#if !SERVER_SIDE
using Microsoft.WindowsAzure.MobileServices;
//using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
//using Microsoft.WindowsAzure.MobileServices.Sync;
#endif
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace CallReporter.Model
{
    public class ApplicationCapabilities
    {
        #region Authentication Capability
        /// <summary>
        /// Specifies whether or not authentication is required for this application
        /// </summary>
        /// <remarks>
        /// To require authentication:
        ///     1) Change this property to return true
        ///     2) Configure one or more identity providers in Azure and the providers portal
        ///        (see http:...)
        ///     3) Remove any unwanted/unconfigured identity providers
        ///        (find _IdentityProviders dictionary below and comment out the unwated/unconfigured)
        ///     4) Enable server-side authentication capability by defining AUTHENTICATION_REQUIRED
        ///        as a conditional compliation symbol on the Build tab of the project properties on
        ///        the backend app service (i.e. the project with 'Service' in its name).  Its
        ///        important to do this for both the Debug and Release configurations!
        ///     5) Republish the backend app service to Azure
        /// </remarks>
        static public bool IsAuthenticationRequired { get { return false; } }

        #region Authentication Providers
#if !SERVER_SIDE
        static Dictionary<string, MobileServiceAuthenticationProvider> _IdentityProviders = new Dictionary<string, MobileServiceAuthenticationProvider>
        {
            // Supported identity providers
            // Note: comment out any unwated/unconfigured identity provider
            { "Facebook Account", MobileServiceAuthenticationProvider.Facebook },
            { "Twitter Account", MobileServiceAuthenticationProvider.Twitter },
            { "Microsoft Account", MobileServiceAuthenticationProvider.MicrosoftAccount },
            { "Google Account", MobileServiceAuthenticationProvider.Google },
            { "Azure Account", MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory },
        };

        static public List<string> IdentityProviders
        {
            get { return _IdentityProviders.Keys.ToList(); }
        }

        static public MobileServiceAuthenticationProvider ConvertString2IdentityProvider(string identityProvider)
        {
            return _IdentityProviders[identityProvider];
        }
#endif
        #endregion

        #endregion

        #region Push Notification Capability
        /// <summary>
        /// Specifies whether or not push notifications are required for this application
        /// </summary>
        /// <remarks>
        /// To require push notification:
        ///     1) Change this property to return true
        ///     2) Republish the Service project to Azure to update this value in that code base 
        /// </remarks>
        static public bool IsPushNotificationRequired { get { return false; } }
        #endregion

        /// <summary>
        /// Specifies what mode of operation is required: Online-Only, Online & Offline, Offline only
        /// </summary>
        /// <remarks>
        /// When you change the value of this property follow the directions in the 
        /// comments associated with each table declaration in Locator.cs
        /// 
        /// You don't need to republish the server project to Azure when you change this
        /// setting since it is not currently referenced by the backend app service.
        /// </remarks>
        static public ModeOfOperation ModeOfOperation { get { return ModeOfOperation.OnlineAndOffline; } }
    }

    public enum ModeOfOperation
    {
        OnlineOnly,
        OnlineAndOffline,
        OfflineOnly
    }
}
