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
    
    public partial class ToursSet
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int PartnersServiceId { get; set; }
        public Nullable<decimal> NetPrice { get; set; }
        public Nullable<decimal> Brutprice { get; set; }
        public Nullable<decimal> OfferPrice { get; set; }
        public Nullable<System.DateTime> OfferSpan { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<System.DateTime> BrutPriceSpan { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> DepartTime { get; set; }
        public Nullable<System.DateTime> ArriveTime { get; set; }
        public string Route { get; set; }
        public string DepartPlace { get; set; }
        public string ArrivePlace { get; set; }
        public string ConfortClass { get; set; }
        public string Number { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public Nullable<bool> Isguided { get; set; }
        public string Transport1 { get; set; }
        public string Transport2 { get; set; }
        public Nullable<int> TouristCount { get; set; }
    
        public virtual PartnersServices PartnersServices { get; set; }
    }
}
