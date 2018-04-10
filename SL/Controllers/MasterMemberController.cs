﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SL.Cross;

namespace SL.Controllers
{
    public class MasterMemberController : Controller
    {
        DAL.nubebfsEntities db = new DAL.nubebfsEntities();
        // GET: MasterMember
        public ActionResult Index()
        {
            return View();
        }

        [NubeCrossSiteAttribute]
        public JsonResult Insert(MASTERMEMBERWITHOTHER wm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(wm.MEMBER_NAME))
                {
                    return Json(new { isSaved = false, ErrMsg = "Member Name is Empty" }, JsonRequestBehavior.AllowGet);
                }
                else if (string.IsNullOrWhiteSpace(wm.ICNO_NEW))
                {
                    return Json(new { isSaved = false, ErrMsg = "ICNO is Empty" }, JsonRequestBehavior.AllowGet);
                }
                else if (wm.BANK_CODE == 0 || string.IsNullOrWhiteSpace(wm.BANK_CODE.ToString()))
                {
                    return Json(new { isSaved = false, ErrMsg = "Bank is Empty" }, JsonRequestBehavior.AllowGet);
                }
                else if (wm.BANKBRANCH_CODE == 0 || string.IsNullOrWhiteSpace(wm.BANKBRANCH_CODE.ToString()))
                {
                    return Json(new { isSaved = false, ErrMsg = "Branch is Empty" }, JsonRequestBehavior.AllowGet);
                }
                else if (wm.Salary == 0 || string.IsNullOrWhiteSpace(wm.Salary.ToString()))
                {
                    return Json(new { isSaved = false, ErrMsg = "Salary is Empty" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    int i = 0;
                    var mn = db.MASTERNAMESETUPs.FirstOrDefault();
                    decimal age = 0;
                    if (wm.DATEOFBIRTH != null)
                    {
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(wm.DATEOFBIRTH);
                        age = Convert.ToInt32(ts.Days) / 365;
                    }

                    DAL.MemberInsertBranch mm = new DAL.MemberInsertBranch();

                    mm.MEMBERTYPE_CODE = wm.MEMBERTYPE_CODE;
                    mm.MEMBER_ID = 0;
                    mm.MEMBER_TITLE = wm.MEMBER_TITLE;
                    mm.MEMBER_NAME = wm.MEMBER_NAME;
                    mm.DATEOFBIRTH = wm.DATEOFBIRTH;
                    mm.AGE_IN_YEARS = age;
                    mm.SEX = wm.SEX;
                    mm.REJOINED = wm.REJOINED;
                    mm.RACE_CODE = wm.RACE_CODE;
                    mm.ICNO_NEW = wm.ICNO_NEW;
                    mm.ICNO_OLD = wm.ICNO_OLD;
                    mm.DATEOFJOINING = DateTime.Today;

                    mm.BANK_CODE = wm.BANK_CODE;
                    mm.BRANCH_CODE = wm.BANKBRANCH_CODE;
                    mm.DATEOFEMPLOYMENT = wm.DATEOFEMPLOYMENT;
                    mm.Salary = wm.Salary;
                    mm.LEVY = "N/A";
                    mm.TDF = "N/A";
                    mm.LEVY_AMOUNT = 0;
                    mm.TDF_AMOUNT = 0;
                    //mm.LevyPaymentDate = DateTime.Now;
                    //mm.Tdf_PaymentDate = DateTime.Now;

                    if (mn != null)
                    {
                        if (wm.REJOINED == 1)
                        {
                            mm.ENTRANCEFEE = mn.EnterenceFees + mn.RejoinAmount;
                        }
                        else
                        {
                            mm.ENTRANCEFEE = mn.EnterenceFees;
                        }

                        mm.MONTHLYBF = mn.BF;
                        mm.ACCBF = mn.BF;
                        mm.CURRENT_YTDBF = mn.BF;

                        decimal dSalary = Convert.ToDecimal(wm.Salary);
                        if (dSalary > 0)
                        {
                            decimal dAmount = ((dSalary * Convert.ToDecimal(mn.Subscription)) / 100);
                            decimal dSubscription = dAmount - Convert.ToDecimal(mn.BF + mn.Insurance);

                            mm.MONTHLYSUBSCRIPTION = dSubscription;
                            mm.ACCSUBSCRIPTION = dSubscription;
                            mm.CURRENT_YTDSUBSCRIPTION = dSubscription;
                        }
                    }

                    mm.ACCBENEFIT = 0;
                    mm.TOTALMONTHSPAID = 1;
                    mm.ADDRESS1 = wm.ADDRESS1;
                    mm.ADDRESS2 = wm.ADDRESS2;
                    mm.ADDRESS3 = wm.ADDRESS3;
                    mm.PHONE = wm.PHONE;
                    mm.MOBILE = wm.MOBILE;
                    mm.EMAIL = wm.EMAIL;
                    mm.CITY_CODE = wm.CITY_CODE;
                    mm.ZIPCODE = wm.ZIPCODE;
                    mm.STATE_CODE = wm.STATE_CODE;
                    mm.COUNTRY = wm.COUNTRY;
                    mm.UpdatedBy = 1;
                    mm.UpdatedOn = DateTime.Now;
                    mm.IsApproved = 0;
                    mm.Occupation = wm.Occupation;
                   
                    db.MemberInsertBranches.Add(mm);
                    db.SaveChanges();                    

                    return Json(new
                    {
                        isSaved = true,
                        MEMBER_CODE = mm.MEMBER_CODE,
                        URL = wm.URL
                    }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new { isSaved = false, ErrMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public partial class MASTERMEMBERWITHOTHER
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
            public Nullable<decimal> BANKBRANCH_CODE { get; set; }
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
            public string Occupation { get; set; }
            public string N_ICNO_NEW { get; set; }
            public string N_NAME { get; set; }
            public string N_SEX { get; set; }
            public Nullable<decimal> N_AGE { get; set; }
            public Nullable<decimal> N_RELATION_CODE { get; set; }
            public string N_ADDRESS1 { get; set; }
            public string N_ADDRESS2 { get; set; }
            public Nullable<decimal> N_CITY_CODE { get; set; }
            public Nullable<decimal> N_STATE_CODE { get; set; }
            public string N_COUNTRY { get; set; }
            public string G_ICNO_NEW { get; set; }
            public string G_NAME { get; set; }
            public string G_SEX { get; set; }
            public Nullable<decimal> G_AGE { get; set; }
            public Nullable<decimal> G_RELATION_CODE { get; set; }
            public string G_ADDRESS1 { get; set; }
            public string G_ADDRESS2 { get; set; }
            public Nullable<decimal> G_CITY_CODE { get; set; }
            public Nullable<decimal> G_STATE_CODE { get; set; }
            public string G_COUNTRY { get; set; }
            public string URL { get; set; }
        }
    }
}