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
    
    public partial class MemberStatusLog
    {
        public int Id { get; set; }
        public int MEMBER_CODE { get; set; }
        public string MEMBER_NAME { get; set; }
        public Nullable<int> MEMBER_ID { get; set; }
        public Nullable<int> MEMBERTYPE_CODE { get; set; }
        public string MEMBERTYPE_NAME { get; set; }
        public string SEX { get; set; }
        public string SEX_MF { get; set; }
        public string ICNO_OLD { get; set; }
        public string ICNO_NEW { get; set; }
        public Nullable<System.DateTime> DATEOFBIRTH { get; set; }
        public Nullable<int> BANK_CODE { get; set; }
        public string BANKUSER_CODE { get; set; }
        public Nullable<int> BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public Nullable<int> NUBEBRANCH_CODE { get; set; }
        public string NUBEBRANCH_NAME { get; set; }
        public string RACE { get; set; }
        public Nullable<System.DateTime> DATEOFJOINING { get; set; }
        public string Levy { get; set; }
        public string TDF { get; set; }
        public Nullable<int> CITY_CODE { get; set; }
        public string CITY_NAME { get; set; }
        public Nullable<int> STATE_CODE { get; set; }
        public string STATE_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public Nullable<bool> REJOINED { get; set; }
        public Nullable<bool> RESIGNED { get; set; }
        public Nullable<int> TOTALMONTHSPAID { get; set; }
        public Nullable<int> TOTALMOTHSDUE { get; set; }
        public Nullable<System.DateTime> LASTPAYMENT_DATE { get; set; }
        public string MEMBERSTATUS { get; set; }
        public Nullable<int> MEMBERSTATUSCODE { get; set; }
        public Nullable<System.DateTime> RESIGNATION_DATE { get; set; }
        public Nullable<System.DateTime> VOUCHER_DATE { get; set; }
        public string NRIC_BYBANK { get; set; }
        public string MEMBERNAME_BYBANK { get; set; }
        public Nullable<int> BANKCODE_BYBANK { get; set; }
    }
}
