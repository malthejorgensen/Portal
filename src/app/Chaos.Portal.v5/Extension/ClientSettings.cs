namespace Chaos.Portal.v5.Extension
{
    using System;

    using Chaos.Portal.Core;
    using Chaos.Portal.Core.Data.Model;
    using Chaos.Portal.Core.Exceptions;
    using Chaos.Portal.Core.Extension;

    public class ClientSettings : AExtension
    {
        #region Initialization

        public ClientSettings(IPortalApplication portalApplication): base(portalApplication)
        {
        }

        #endregion
        #region Get

        public Dto.ClientSettings Get(Guid guid)
        {
            var clientSettings = PortalRepository.ClientSettingsGet(guid);

            return new Dto.ClientSettings(clientSettings);
        }

        #endregion
        #region Set

        public uint Set( Guid guid, string name, string settings )
        {
            if(!Request.User.HasPermission(SystemPermissons.Manage)) throw new InsufficientPermissionsException( "User does not have manage permissions" );

            return PortalRepository.ClientSettingsSet(guid, name, settings);
        }

        #endregion
    }
}