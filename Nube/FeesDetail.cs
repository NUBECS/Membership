//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nube
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeesDetail
    {
        public int DetailId { get; set; }
        public int FeeId { get; set; }
        public decimal MemberCode { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> AmountBF { get; set; }
        public Nullable<decimal> UnionContribution { get; set; }
        public Nullable<decimal> AmountIns { get; set; }
        public Nullable<decimal> AmtSubs { get; set; }
        public string Dept { get; set; }
        public string UpdatedStatus { get; set; }
        public Nullable<int> FeeYear { get; set; }
        public Nullable<int> FeeMonth { get; set; }
        public string Reason { get; set; }
        public bool IsUnPaid { get; set; }
        public bool IsNotMatch { get; set; }
        public Nullable<decimal> MemberId { get; set; }
        public string MemberName_Bank { get; set; }
        public string NRIC_Bank { get; set; }
        public bool IsAccept_ByNube { get; set; }
        public bool IsStruckOff { get; set; }
        public string Status { get; set; }
        public Nullable<int> TotalMonthsPaidBF { get; set; }
        public Nullable<int> TotalMonthsPaidIns { get; set; }
        public Nullable<int> TotalMonthsPaid { get; set; }
    }
}
