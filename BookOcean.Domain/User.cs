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
    
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CityId { get; set; }
    }
}
