﻿using CHAOS.Serialization;
using CHAOS.Serialization.XML;

namespace CHAOS.Portal.DTO
{
    public interface IPortalResult
    {
        [Serialize("Duration")]
        [SerializeXML(true)]
        long Duration { get; }

        IModuleResult GetModule( string modulename );
    }
}