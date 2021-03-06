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
    
    public partial class PartnersSet
    {
        public PartnersSet()
        {
            this.PartnersServices = new HashSet<PartnersServices>();
        }
    
        public int PartnerId { get; set; }
        public string RealAdress { get; set; }
        public string LawAdress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> FinacialValue { get; set; }
        public string RegNumber { get; set; }
        public string Nombramiento { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public string PartnerName { get; set; }
        public Nullable<System.DateTime> FundingTimeLimit { get; set; }
        public string OrganizationLocation { get; set; }
        public string OrganizationPostalCode { get; set; }
        public string ContractNumber { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public Nullable<decimal> Extra3 { get; set; }
        public Nullable<System.DateTime> Extra4 { get; set; }
        public string NickName { get; set; }
        public Nullable<bool> Isprovider { get; set; }
        public Nullable<bool> Iscreditor { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<PartnersServices> PartnersServices { get; set; }
    }
}
