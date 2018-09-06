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
    
    public partial class AirTicketsSet
    {
        public int AirTicketId { get; set; }
        public string TicketName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int PartnerServiceId { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Brutprice { get; set; }
        public decimal OfferPrice { get; set; }
        public System.DateTime OfferSpan { get; set; }
        public System.DateTime OutDate { get; set; }
        public System.DateTime BrutPriceSpan { get; set; }
        public decimal Code { get; set; }
        public System.DateTime DepartTime { get; set; }
        public System.DateTime ArriveTime { get; set; }
        public string Route { get; set; }
        public string DepartPlace { get; set; }
        public string ArrivePlace { get; set; }
        public string ConfortClass { get; set; }
        public decimal Number { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
    
        public virtual PartnersServices PartnersServices { get; set; }
    }
}
