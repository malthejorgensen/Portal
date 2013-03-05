﻿namespace Chaos.Portal.Test.Extension
{
    using Chaos.Portal.Exceptions;

    using NUnit.Framework;

    [TestFixture]
    public class ClientSettingsTest : TestBase
    {
        [Test]
        public void Get_GivenGuid_CallUnderlyingPortalRepositoryAndReturnResult()
        {
            var extension      = Make_ClientSettingsExtension();
            var clientSettings = Make_ClientSettings();
            PortalRepository.Setup(m => m.ClientSettingsGet(clientSettings.Guid)).Returns(clientSettings);

            var results = extension.Get(CallContext.Object, clientSettings.Guid);

            Assert.That(results, Is.SameAs(clientSettings));
        }

        [Test]
        public void Set_CreateANewClientSetting_ReturnsOne()
        {
            var extension      = Make_ClientSettingsExtension();
            var clientSettings = Make_ClientSettings();
            CallContext.SetupGet( p => p.User ).Returns(Make_User());
            PortalRepository.Setup(m => m.ClientSettingsSet(clientSettings.Guid, clientSettings.Name, clientSettings.Settings)).Returns(1);

            var results = extension.Set(CallContext.Object, clientSettings.Guid, clientSettings.Name, clientSettings.Settings);

            Assert.That(results, Is.EqualTo(1));
        }
        
        [Test, ExpectedException(typeof(InsufficientPermissionsException))]
        public void Set_WithoutPermission_ThrowsException()
        {
            var extension      = Make_ClientSettingsExtension();
            var clientSettings = Make_ClientSettings();
            var user           = Make_User();
            user.SystemPermissions = 0;
            CallContext.SetupGet(p => p.User).Returns(user);

            extension.Set(CallContext.Object, clientSettings.Guid, clientSettings.Name, clientSettings.Settings);
        }
    }
}