﻿using System;
using CHAOS.Portal.Core.Extension;

namespace CHAOS.Portal.Core.Test
{
    public class MockExtension : AExtension
    {
        public void Test( ICallContext callContext )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( "Test" ) );
        }

        public void TestStringParameter( ICallContext callContext, string test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test ) );
        }

        public void TestInt32Parameter( ICallContext callContext, int test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.ToString() ) );
        }

        public void TestNullableInt32Parameter( ICallContext callContext, int? test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.HasValue.ToString() ) );
        }

        public void TestUInt32Parameter( ICallContext callContext, uint test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.ToString() ) );
        }

        public void TestNullableUInt32Parameter( ICallContext callContext, uint? test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.HasValue.ToString() ) );
        }

        public void TestUUIDParameter( ICallContext callContext, UUID test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.ToString() ) );
        }

        public void TestNullableUUIDParameter( ICallContext callContext, UUID test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( (test != null).ToString() ) );
        }

        public void TestDateTimeParameter( ICallContext callContext, DateTime test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( test.ToString() ) );
        }

        public void TestNullableDateTimeParameter( ICallContext callContext, DateTime? test )
        {
            callContext.PortalResponse.PortalResult.GetModule("CHAOS.Portal.Core.Test").AddResult( new StringResult( ( test != null ).ToString() ) );
        }
    }
}
