﻿using CHAOS.Serialization;
using CHAOS.Serialization.XML;

namespace Chaos.Portal.Response
{
    public interface IPortalHeader
    {
        [Serialize("Duration")]
        [SerializeXML(true)]
        uint Duration { get; }

        ReturnFormat ReturnFormat { get; set; }
    }
}