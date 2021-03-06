namespace Chaos.Portal.v6.Module
{
    using System.Collections.Generic;
    using System.Configuration;

    using Chaos.Portal.Core;
    using Chaos.Portal.Core.Exceptions;
    using Chaos.Portal.Core.Extension;
    using Chaos.Portal.Core.Module;
    using Chaos.Portal.v6.Extension;

    public class PortalModule : IModule
    {
        #region Field

        private IPortalApplication _portalApplication;

        #endregion
        #region Initialization

        public void Load(IPortalApplication portalApplication)
        {
            _portalApplication = portalApplication;
        }

        #endregion
        #region Properties


        #endregion
        #region Business Logic

        public IEnumerable<string> GetExtensionNames()
        {
            yield return "ClientSettings";
            yield return "Group";
            yield return "Session";
            yield return "Subscription";
            yield return "User";
            yield return "UserSettings";
            yield return "View";

        }

        public IExtension GetExtension<TExtension>() where TExtension : IExtension
        {
            return GetExtension(typeof(TExtension).Name);
        }

        public IExtension GetExtension(string name)
        {
            if (_portalApplication == null) throw new ConfigurationErrorsException("Load not call on module");

            switch(name)
            {
                case "ClientSettings":
                    return new v5.Extension.ClientSettings().WithPortalApplication(_portalApplication);
                case "Group":
                    return new Group().WithPortalApplication(_portalApplication);
                case "Session":
                    return new v5.Extension.Session().WithPortalApplication(_portalApplication);
                case "Subscription":
                    return new v5.Extension.Subscription().WithPortalApplication(_portalApplication);
                case "User":
                    return new User().WithPortalApplication(_portalApplication);
                case "UserSettings":
                    return new v5.Extension.UserSettings().WithPortalApplication(_portalApplication);
                case "View":
                    return new v5.Extension.View().WithPortalApplication(_portalApplication);
                default:
                    throw new ExtensionMissingException(string.Format("No extension by the name {0}, found on the Portal Module", name));
            }
        }

        #endregion
    }
}