//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataHandler
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceTypes
    {
        public ServiceTypes()
        {
            this.ServicesSet = new HashSet<ServicesSet>();
        }
    
        public int ServiceTypeID { get; set; }
        public string ServiceType { get; set; }
    
        public virtual ICollection<ServicesSet> ServicesSet { get; set; }
    }
}
