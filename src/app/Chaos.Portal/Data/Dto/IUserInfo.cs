﻿namespace Chaos.Portal.Data.Dto
{
    using System;

    using Chaos.Portal.Cache.Couchbase;
    using Chaos.Portal.Data.Dto.Standard;

    using CHAOS.Serialization;

    public interface IUserInfo : IResult, ICacheable
    {
        [Serialize("Guid")]
        Guid Guid { get; set; }

        Guid? SessionGuid { get; set; }

        [Serialize]
        long? SystemPermissions { get; set; }
        SystemPermissons SystemPermissonsEnum { get; set; }

        [Serialize]
        string Email { get; set; }

        [Serialize]
        DateTime? SessionDateCreated { get; set; }

        [Serialize]
        DateTime? SessionDateModified { get; set; } 
    }
}