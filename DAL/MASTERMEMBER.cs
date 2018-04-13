//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MASTERMEMBER
    {
        public decimal MEMBER_CODE { get; set; }
        public string MEMBER_NAME { get; set; }
        public Nullable<decimal> MEMBER_ID { get; set; }
        public string MEMBER_TITLE { get; set; }
        public string MEMBER_INITIAL { get; set; }
        public Nullable<decimal> BF_NO { get; set; }
        public string ICNO_OLD { get; set; }
        public string ICNO_NEW { get; set; }
        public Nullable<decimal> BANK_CODE { get; set; }
        public Nullable<decimal> BRANCH_CODE { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public Nullable<decimal> CITY_CODE { get; set; }
        public Nullable<decimal> STATE_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string ZIPCODE { get; set; }
        public string PHONE { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> DATEOFJOINING { get; set; }
        public Nullable<System.DateTime> DATEOFBIRTH { get; set; }
        public Nullable<decimal> AGE_IN_YEARS { get; set; }
        public Nullable<System.DateTime> DATEOFEMPLOYMENT { get; set; }
        public Nullable<decimal> MEMBERTYPE_CODE { get; set; }
        public string SEX { get; set; }
        public Nullable<decimal> RACE_CODE { get; set; }
        public Nullable<decimal> REJOINED { get; set; }
        public string PROPOSEDBY { get; set; }
        public Nullable<decimal> PROPOSED_MEMBERID { get; set; }
        public string SECONDEDBY { get; set; }
        public Nullable<decimal> SECONDED_MEMBERID { get; set; }
        public string CONFIRMEDAT { get; set; }
        public Nullable<System.DateTime> HELDON { get; set; }
        public Nullable<decimal> STATUS_CODE { get; set; }
        public Nullable<decimal> PREVIOUS_STATUSCODE { get; set; }
        public string LEVY { get; set; }
        public Nullable<decimal> TOTALMONTHSPAID { get; set; }
        public Nullable<decimal> ENTRANCEFEE { get; set; }
        public Nullable<decimal> HQFEE { get; set; }
        public Nullable<decimal> MONTHLYBF { get; set; }
        public Nullable<decimal> MONTHLYSUBSCRIPTION { get; set; }
        public Nullable<decimal> ACCBF { get; set; }
        public Nullable<decimal> ACCSUBSCRIPTION { get; set; }
        public Nullable<decimal> ACCBENEFIT { get; set; }
        public Nullable<decimal> CURRENT_YTDBF { get; set; }
        public Nullable<decimal> CURRENT_YTDSUBSCRIPTION { get; set; }
        public Nullable<decimal> RESIGNED { get; set; }
        public string PAYMENT_MODE { get; set; }
        public Nullable<decimal> USER_CODE { get; set; }
        public Nullable<System.DateTime> ENTRY_DATE { get; set; }
        public string ENTRY_TIME { get; set; }
        public Nullable<decimal> REGISTRATION_FEE { get; set; }
        public Nullable<System.DateTime> LASTPAYMENT_DATE { get; set; }
        public Nullable<decimal> BLACKLISTED { get; set; }
        public string BLACKLISTREASON { get; set; }
        public string DATEOFBIRTH_S { get; set; }
        public string DATEOFEMPLOYMENT_S { get; set; }
        public Nullable<decimal> STRUCKOFF { get; set; }
        public string STRUCKOFF_REMARKS { get; set; }
        public Nullable<System.DateTime> STRUCKOFF_DATE { get; set; }
        public Nullable<System.DateTime> WAIVERDATE { get; set; }
        public string WAIVERREASON { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<double> BatchAmt { get; set; }
        public Nullable<decimal> LEVY_AMOUNT { get; set; }
        public string TDF { get; set; }
        public Nullable<decimal> TDF_AMOUNT { get; set; }
        public Nullable<System.DateTime> LevyPaymentDate { get; set; }
        public Nullable<System.DateTime> Tdf_PaymentDate { get; set; }
        public string MemberName_ByBank { get; set; }
        public string NRIC_ByBank { get; set; }
        public Nullable<decimal> BankCode_ByBank { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public bool IsCancel { get; set; }
        public bool IsBranchRegister { get; set; }
        public int TotalPaid { get; set; }
        public bool AI_Insurance { get; set; }
        public string AI_MemberNo { get; set; }
        public bool GE_Insurance { get; set; }
        public string GE_ContractNo { get; set; }
        public Nullable<int> BranchMemberCode { get; set; }
    }
}
