//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chaos.Portal.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientSettings
    {
        public ClientSettings()
        {
            this.UserSettings = new HashSet<UserSettings>();
        }
    
        public System.Guid GUID { get; set; }
        public string Name { get; set; }
        public string Settings { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual ICollection<UserSettings> UserSettings { get; set; }
    }
}