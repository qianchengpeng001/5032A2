//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _20S2_5032_A2_4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class clinical
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
    
        public virtual patient patient { get; set; }
        public virtual doctor doctor { get; set; }
    }
}