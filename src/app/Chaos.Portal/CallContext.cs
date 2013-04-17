﻿namespace Chaos.Portal
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Chaos.Portal.Cache;
    using Chaos.Portal.Core.Data.Model;
    using Chaos.Portal.Core.Exceptions;
    using Chaos.Portal.Indexing.View;
    using Chaos.Portal.Logging;
    using Chaos.Portal.Request;
    using Chaos.Portal.Response;
    using Chaos.Portal.Response.Specification;
    

    public class CallContext : ICallContext
    {
        #region Fields

        private Session                       _session;
        private UserInfo                      _user;
        private IEnumerable<SubscriptionInfo> _subscriptions;
        private IEnumerable<Group>            _group;
		
	    private const string SessionguidParameterName = "sessionGUID";

        private static readonly Guid _anonymousUserGuid;
        private static readonly IDictionary<ReturnFormat, IResponseSpecification> ResponseSpecifications = new Dictionary<ReturnFormat, IResponseSpecification>(); 

        #endregion
        #region Properties

        public IPortalApplication Application { get; set; }
        public IPortalRequest     Request { get; set; }
        public IPortalResponse    Response { get; set; }
        public ICache             Cache { get; set; }
        public IViewManager       ViewManager { get; set; }
        public ILog               Log { get; private set; }

        /// <summary>
        /// Returns the current user, the user is cached and will not be updated during the callContexts life.
        /// </summary>
        public UserInfo User 
        { 
            get
            {
                if( _user == null )
                {
                    _user = Application.PortalRepository.UserInfoGet(null, Session.Guid, null).FirstOrDefault();
                        
                    if( _user == null ) throw new SessionDoesNotExistException( "No user associted with session" );
                }

                return _user;
            }
        }

		/// <summary>
		/// Get the current session
		/// </summary>
        public Session Session
        {
            get
            {
				if( GetSessionFromDatabase() == null) throw new SessionDoesNotExistException( "SessionGUID is invalid or has expired" );

				return _session;
            }
        }

		/// <summary>
		/// Get subscriptions associated with the current user
		/// </summary>
        public IEnumerable<SubscriptionInfo> Subscriptions
        {
            get 
            {
                return _subscriptions ?? (_subscriptions = Application.PortalRepository.SubscriptionGet(null, User.Guid));
            }
        }

        /// <summary>
        /// returns the groups the current user is part of, the Groups are cached, changes in the database will not be pickup up during the callContext life.
        /// </summary>
        public IEnumerable<Group> Groups
        {
            get { return _group ?? (_group = Application.PortalRepository.GroupGet(null, null, User.Guid).ToList()); }
        }

		/// <summary>
		/// True if current user is anonymous
		/// </summary>
        public bool IsAnonymousUser
        {
            get { return GetSessionFromDatabase() == null || AnonymousUserGuid.ToString() == Session.UserGuid.ToString(); }
        }

		/// <summary>
		/// Get the UUID of the anonymous user
		/// </summary>
        public Guid AnonymousUserGuid { get { return _anonymousUserGuid;  } }

        #endregion
        #region Constructors

        static CallContext()
        {
            ResponseSpecifications.Add(ReturnFormat.XML, new XmlResponse());
            ResponseSpecifications.Add(ReturnFormat.JSON, new JsonResponse());
            ResponseSpecifications.Add(ReturnFormat.JSONP, new JsonpResponse());
            ResponseSpecifications.Add(ReturnFormat.ATTACHMENT, new StreamResponse());

            _anonymousUserGuid = new Guid( ConfigurationManager.AppSettings["AnonymousUserGUID"] );
        }

        public CallContext(IPortalApplication application, IPortalRequest request, IPortalResponse response, ILog log)
        {
            Application = application;
            Request     = request;
            Response    = response.WithResponseSpecification(ResponseSpecifications[request.ReturnFormat]);
            Cache       = application.Cache;
            ViewManager = application.ViewManager;
            Log         = log;
            
            response.Header.ReturnFormat = request.ReturnFormat;
            response.Header.Callback     = request.Parameters.ContainsKey("callback") ? request.Parameters["callback"] : null;
        }

        #endregion
        #region Business Logic

		/// <summary>
		/// Gets the current session from the database
		/// </summary>
		/// <returns>The current session from the database, or null if sessionGUID is not specified</returns>
		public Session GetSessionFromDatabase()
		{
			if( _session == null )
            {
                if( !Request.Parameters.ContainsKey( SessionguidParameterName ) )
                    return null;

                _session = Application.PortalRepository.SessionGet(new Guid(Request.Parameters[SessionguidParameterName]), null).FirstOrDefault();

				if( _session == null )
					return null;
            }

			return _session;
		}

        #endregion
    }
}
