﻿using System.Linq;
using System.Xml.Linq;
using Geckon.Portal.Test;
using NUnit.Framework;

namespace Geckon.Portal.Extensions.Standard.Test
{
    [TestFixture]
    public class UserTest : TestBase
    {
        [Test]
        public void Should_Update_User()
        {
            UserExtension extension = new UserExtension(  );
            extension.Init( new PortalContextMock() );

            extension.Update( AnonCallContext, "new", null, null, null  );

            Assert.AreEqual( "new", XDocument.Parse(extension.Result).Descendants( "Firstname" ).First().Value );
        }

        [Test]
        public void Should_Create_User()
        {
            UserExtension extension = new UserExtension();

            extension.Init( new PortalContextMock() );
            extension.Create( AnonCallContext, "new", null, null, "email");

            Assert.AreEqual("new", XDocument.Parse(extension.Result).Descendants("Firstname").First().Value);
        }

        [Test]
        public void Should_Get_User()
        {
            UserExtension extension = new UserExtension();

            extension.Init( new PortalContextMock() );
            extension.Get( AnonCallContext );

            Assert.AreEqual("anon@ymo.us", XDocument.Parse(extension.Result).Descendants("Email").First().Value);
        }

        [Test]
        public void Should_Delete_User()
        {
            UserExtension extension = new UserExtension();

            extension.Init( new PortalContextMock() );
            extension.Delete( AnonCallContext, UserAnonymous.GUID.ToString() );

            Assert.AreEqual("1", XDocument.Parse(extension.Result).Descendants("Value").First().Value);
        }
    }
}
