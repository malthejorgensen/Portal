﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Geckon.Portal.Core.Extension;
using Geckon.Portal.Core.Module;
using Geckon.Serialization.Xml;

namespace Geckon.Portal.Core.Standard.Extension
{
    public abstract class AExtension : Controller, IExtension
    {
        #region Fields

        #endregion
        #region Properties

        public IPortalContext PortalContext { get; private set; }

        protected IResult ResultBuilder { get; set; }
        protected IDictionary<Type, IChecked<IModule>> AssociatedModules { get; set; }
        protected string Controller { get; set; }
        protected string Action { get; set; }
        public ICallContext CallContext { get; set; }

        #endregion
        #region Constructors

        public AExtension()
        {
            AssociatedModules = new Dictionary<Type, IChecked<IModule>>();
        }

        public void Init( IPortalContext portalContext, IResult result, string sessionID )
        {
            PortalContext = portalContext;
            ResultBuilder = result;
            CallContext   = new CallContext( portalContext.Cache, portalContext.Solr, sessionID );
        }

        #endregion
        #region Business Logic

        #region Override

        /// <summary>
        /// Initializes the list of registered modules that wants calls from the current extension call
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            Controller = filterContext.RouteData.Values["Controller"].ToString();
            Action     = filterContext.RouteData.Values["Action"].ToString();

            foreach( IModule module in PortalContext.GetModules( Controller, Action ) )
            {
                AssociatedModules.Add( module.GetType(), new Checked<IModule>( module ) );
            }

            // This Set the CallContext on the Method if specified
            if( filterContext.ActionParameters.ContainsKey( "callContext" ) )
                filterContext.ActionParameters["callContext"] = CallContext;

            CallContext.Parameters = filterContext.ActionParameters.Select( (parameter) => new Parameter( parameter.Key, parameter.Value ) );

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// This Method Call all modules subscriping to this Extension call, that haven't yet been checked
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Result = GetContentResult();

            base.OnActionExecuted(filterContext);
        }

        protected override void OnException( ExceptionContext filterContext )
        {
            base.OnException( filterContext );

            if( filterContext.Exception is TargetInvocationException )
                filterContext.Exception = filterContext.Exception.InnerException; 
            
            filterContext.ExceptionHandled = true;
            filterContext.Result           = GetContentResult( string.Format( "<Error><Exception>{0}</Exception><Message><![CDATA[{1}]]></Message><StackTrace><![CDATA[{2}]]></StackTrace></Error>" , 
                                                               filterContext.Exception.GetType().FullName, 
                                                               filterContext.Exception.Message,
                                                               filterContext.Exception.StackTrace ) 
                                                             );

            // TODO: Not all clients support status codes, this should be dependant on ClientSettings
            filterContext.HttpContext.Response.StatusCode = 500;
        }

        #endregion
        #region Result formatting

        public ContentResult GetContentResult()
        {
            CallModules( CallContext.Parameters.ToList() );

            return GetContentResult( ResultBuilder.Content );
        }

        protected ContentResult GetContentResult( string content )
        {
            ContentResult result = new ContentResult();
            
            result.Content         = content;
            result.ContentType     = "text/xml";
            result.ContentEncoding = Encoding.UTF8;
            
            return result;
        }


        protected ContentResult GetContentResult( XmlDocument content )
        {
            return GetContentResult( content.OuterXml );
        }

        protected ContentResult GetContentResult( XmlSerialize content )
        {
            return GetContentResult( content.ToXML().OuterXml );
        }

        #endregion
        #region Module

        protected void CallModules( params Parameter[] parameters )
        {
            CallModules( parameters.Select( (parameter)=>parameter ).ToList() );
        }

        private void CallModules(IList<Parameter> parameters)
        {
            foreach( IChecked<IModule> associatedModule in AssociatedModules.Values.Where( module => !module.IsChecked ) )
            {
                parameters.Add( new Parameter( "callContext", CallContext ) );

                ResultBuilder.Add( associatedModule.Value.GetType().FullName,
                                   associatedModule.Value.InvokeMethod( new MethodQuery( Controller,
                                                                                         Action,
                                                                                         parameters ) ) );

                associatedModule.IsChecked = true;
            }
        }

        protected T GetModule<T>() where T : IModule
        {
            return PortalContext.GetModule<T>();
        }

        #endregion

        #endregion
    }
}
