﻿using System.Linq;
using System.Xml.Linq;
using Geckon.Portal.Core;
using Geckon.Portal.Core.Exception;
using Geckon.Portal.Core.Standard.Extension;
using NUnit.Framework;

namespace Geckon.Portal.Extensions.Standard.Test
{
    [TestFixture]
    public class SubscriptionTest : TestBase
    {
        [Test]
        public void Should_Get_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension( );
            extension.Init( new PortalContextMock(),new Result(), AdminSession.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Get( AdminUser.SessionID.ToString(), Subscription.GUID.ToString() );

            Assert.AreEqual( Subscription.GUID.ToString(), XDocument.Parse(extension.GetContentResult().Content).Descendants( "GUID" ).First().Value );
        }

        [Test, ExpectedException( typeof(InsufficientPermissionsExcention) )]
        public void Should_Throw_InssurficientPermissionsException_On_Get_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension(  );
            extension.Init( new PortalContextMock(),new Result(), Session.SessionID.ToString() );

            extension.Get( User.SessionID.ToString(), Subscription.GUID.ToString() );
        }

        [Test]
        public void Should_Create_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension( );
            extension.Init( new PortalContextMock(),new Result(), AdminSession.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Create( AdminUser.SessionID.ToString(), "some name" );

            Assert.AreEqual( "some name", XDocument.Parse(extension.GetContentResult().Content).Descendants( "Name" ).First().Value );
        }

        [Test, ExpectedException( typeof(InsufficientPermissionsExcention) )]
        public void Should_Throw_InssurficientPermissionsException_On_Create_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension(  );
            extension.Init( new PortalContextMock(),new Result(), Session.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Create( User.SessionID.ToString(), "some name" );
        }

        [Test]
        public void Should_Delete_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension(  );
            extension.Init( new PortalContextMock(),new Result(), AdminSession.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Delete( AdminUser.SessionID.ToString(), Subscription.GUID.ToString() );

            Assert.AreEqual( "1", XDocument.Parse(extension.GetContentResult().Content).Descendants( "Value" ).First().Value );
        }

        [Test, ExpectedException( typeof(InsufficientPermissionsExcention) )]
        public void Should_Throw_InsufficientPermissionsExcention_When_Trying_To_Delete_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension(  );
            extension.Init( new PortalContextMock(),new Result(), Session.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Delete( User.SessionID.ToString(), Subscription.GUID.ToString() );
        }

        [Test]
        public void Should_Update_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension( );
            extension.Init( new PortalContextMock(),new Result(), AdminSession.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Update( AdminUser.SessionID.ToString(), Subscription.GUID.ToString(), "new subscription name" );

            Assert.AreEqual( "1", XDocument.Parse(extension.GetContentResult().Content).Descendants( "Value" ).First().Value );
        }

        [Test, ExpectedException( typeof(InsufficientPermissionsExcention) )]
        public void Should_Throw_InsufficientPermissionsExcention_When_Trying_To_Update_Subscription()
        {
            SubscriptionExtension extension = new SubscriptionExtension(  );
            extension.Init( new PortalContextMock(),new Result(), Session.SessionID.ToString() );
            extension.CallContext.Parameters = new Parameter[0];

            extension.Update( User.SessionID.ToString(), Subscription.GUID.ToString(), "new subscription name" );
        }
    }
}
