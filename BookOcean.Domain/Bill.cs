//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookOcean.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public int InvoiceNumber { get; set; }
        public System.DateTime Date { get; set; }
        public long SetID { get; set; }
        public string SelectedBook { get; set; }
    }
}