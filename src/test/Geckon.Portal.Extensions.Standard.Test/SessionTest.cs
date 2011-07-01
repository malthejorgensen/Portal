﻿using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using Geckon.Portal.Core.Standard.Extension;
using NUnit.Framework;

namespace Geckon.Portal.Extensions.Standard.Test
{
    [TestFixture]
    public class SessionTest : TestBase
    {
        [Test]
        public void Should_Create_A_New_Session()
        {
            SessionExtension sessionExtension = new SessionExtension( new PortalContextMock() );
            sessionExtension.Init( new Result() );
            
            ContentResult result = sessionExtension.Create( 1, 3 );

            Assert.IsNotNull( XDocument.Parse( result.Content ).Descendants("SessionID").FirstOrDefault() );
        }

        [Test]
        public void Should_Update_A_Session()
        {
            SessionExtension sessionExtension = new SessionExtension(new PortalContextMock());
            sessionExtension.Init( new Result() );

            ContentResult result = sessionExtension.Update( Session.SessionID.ToString() );

            Assert.IsNotNull( XDocument.Parse( result.Content ).Descendants("SessionID").FirstOrDefault() );
            Assert.AreNotEqual( Session.DateModified.ToString(), XDocument.Parse( result.Content ).Descendants("DateModified").FirstOrDefault().Value );
        }

        [Test]
        public void Should_Delete_A_Session()
        {
            SessionExtension sessionExtension = new SessionExtension(new PortalContextMock());
            sessionExtension.Init( new Result() );

            ContentResult result = sessionExtension.Delete( Session.SessionID.ToString() );

            Assert.IsNotNull( XDocument.Parse( result.Content ).Descendants("Geckon.Portal.Data.Dto.ScalarResult").FirstOrDefault() );
        }
    }
}
