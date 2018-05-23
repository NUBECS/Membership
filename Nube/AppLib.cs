using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Nube
{
    public struct DateTimeSpan
    {
        private readonly int years;
        private readonly int months;
        private readonly int days;
        private readonly int hours;
        private readonly int minutes;
        private readonly int seconds;
        private readonly int milliseconds;

        public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
        {
            this.years = years;
            this.months = months;
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        public int Years { get { return years; } }
        public int Months { get { return months; } }
        public int Days { get { return days; } }
        public int Hours { get { return hours; } }
        public int Minutes { get { return minutes; } }
        public int Seconds { get { return seconds; } }
        public int Milliseconds { get { return milliseconds; } }

        enum Phase { Years, Months, Days, Done }

        public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                var sub = date1;
                date1 = date2;
                date2 = sub;
            }

            DateTime current = date1;
            int years = 0;
            int months = 0;
            int days = 0;

            Phase phase = Phase.Years;
            DateTimeSpan span = new DateTimeSpan();
            int officialDay = current.Day;

            while (phase != Phase.Done)
            {
                switch (phase)
                {
                    case Phase.Years:
                        if (current.AddYears(years + 1) > date2)
                        {
                            phase = Phase.Months;
                            current = current.AddYears(years);
                        }
                        else
                        {
                            years++;
                        }
                        break;
                    case Phase.Months:
                        if (current.AddMonths(months + 1) > date2)
                        {
                            phase = Phase.Days;
                            current = current.AddMonths(months);
                            if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
                                current = current.AddDays(officialDay - current.Day);
                        }
                        else
                        {
                            months++;
                        }
                        break;
                    case Phase.Days:
                        if (current.AddDays(days + 1) > date2)
                        {
                            current = current.AddDays(days);
                            var timespan = date2 - current;
                            span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                            phase = Phase.Done;
                        }
                        else
                        {
                            days++;
                        }
                        break;
                }
            }

            return span;
        }
    }
    public static class AppLib
    {
        public enum MemberStatus { Active=1, Defaulter=2, StruckOff=3, Resigned=4};
        public static string sProjectName = "";
        public static int iUserCode = 0;
        public static Boolean bIsSuperAdmin = false;
        public static string sAccFundName = "";
        public static string AppName = "";
        public static string DBBFS = "nubebfs";
        public static string DBStatus = "nubestatus";
        public static string SLURL = "http://membership.nube.org.my/";
        public static int iFundId = 0;
        //public static NubeAccountReport frmNubeAccountReport = new NubeAccountReport();
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["NUBEBFS"].ConnectionString;
        public static string connstatus = System.Configuration.ConfigurationManager.ConnectionStrings["NUBESTATUS"].ConnectionString;
        public static List<UserPrevilage> lstUsreRights = new List<UserPrevilage>();
        public static List<TVMASTERMEMBER> lstTVMasterMember = new List<TVMASTERMEMBER>();
        public static List<ViewMasterMember> lstMstMember = new List<ViewMasterMember>();        

        public static DataTable dtMemberQuery = new DataTable();        
        public static DataTable dtAnnualStatement = new DataTable();
        public static nubebfsEntity db = new nubebfsEntity();
        
        public static int MonthDiff(DateTime dt1,DateTime dt2)
        {
            dt1 = new DateTime(dt1.Year, dt1.Month, 1);
            dt2 = new DateTime(dt2.Year, dt2.Month, 1);
            var dateSpan = DateTimeSpan.CompareDates(dt1, dt2);
            return (dateSpan.Years*12)+ dateSpan.Months;
        }
        public static void CheckIsNumeric(TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9.9]+");
                e.Handled = regex.IsMatch(e.Text);
                //int result;
                //if (!(int.TryParse(e.Text, out result) || e.Text == "."))
                //{
                //    e.Handled = true;
                //}
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public static void EventHistory(string FormName = "", int Event = 0, string OldData = "", string NewData = "", string TblName = "", string Remarks = "")
        {
            try
            {
                EventHistory eh = new EventHistory();
                eh.UserId = AppLib.iUserCode;
                eh.FormName = FormName;
                eh.Event = Event;
                eh.UpdatedOn = DateTime.Now;
                eh.BeforeData = OldData;
                eh.ModifiedData = NewData;
                eh.TableName = TblName;
                eh.Remarks = Remarks;

                db.EventHistories.Add(eh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public static DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();

            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;

            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
