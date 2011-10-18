﻿using System.Web.Mvc;
using Geckon.Portal.Core.Standard.Extension;

namespace Geckon.Portal.Core.Standard
{
    public class ExtensionFactory : DefaultControllerFactory
    {
        #region Properties

        protected APortalApplication Application { get; set; }

        #endregion
        #region Constructors

        public ExtensionFactory( APortalApplication application )
        {
            Application = application;
        }

        #endregion
        public override IController CreateController( System.Web.Routing.RequestContext requestContext, string controllerName )
        {
            if( Application.PortalContext.LoadedExtensions.ContainsKey( controllerName ) )
            {
                IExtensionLoader loader = Application.PortalContext.LoadedExtensions[controllerName];
                
                AExtension extension = (AExtension) loader.Assembly.CreateInstance( loader.Extension.Fullname );
                
                extension.Init( Application.PortalContext,
                                new CallContext { SessionID = requestContext.HttpContext.Request.QueryString["sessionID"] } ,
                                requestContext.HttpContext.Request.QueryString["format"] ?? "GXML",
                                requestContext.HttpContext.Request.QueryString["useHttpStatusCodes"] ?? "true" );
                
                return extension;
            }

            return base.CreateController( requestContext, controllerName );
        }
    }
}
