using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nube.MasterSetup
{
    /// <summary>
    /// Interaction logic for frmDataAuditing.xaml
    /// </summary>
    public partial class frmDataAuditing : MetroWindow
    {
        nubebfsEntity db = new nubebfsEntity();
        public frmDataAuditing()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frmHomeMaster frm = new frmHomeMaster();
            this.Close();
            frm.ShowDialog();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt = dtpDate.SelectedDate.Value;
                dt = new DateTime(dt.Year, dt.Month, 1);
                DateTime dtFromDate = dt.AddMonths(-1);
                DateTime dtToDate = dt.AddDays(-1);

                var lstStatus = (from x in db.MasterMemberStatus where x.FeeYear == dt.Year && x.FeeMonth == dt.Month select x).ToList();
                var lstPreStatus = (from x in db.MasterMemberStatus where x.FeeYear == dtFromDate.Year && x.FeeMonth == dtFromDate.Month select x).ToList();

                var Resign = (from x in lstStatus where x.RESIGNED == 1 select x).ToList();
                var PreResign = (from x in lstPreStatus where x.RESIGNED == 1 select x).ToList();

                if (Resign.Count != PreResign.Count)
                {
                    var rg = (from x in db.RESIGNATIONs where x.RESIGNATION_DATE >= dtFromDate && x.RESIGNATION_DATE <= dtToDate select x).ToList();
                    if ((rg.Count + PreResign.Count) != Resign.Count)
                    {

                    }
                }

                var Active = (from x in lstStatus where x.STATUS_CODE == 1 select x).ToList();
                var PreActive = (from x in lstPreStatus where x.STATUS_CODE == 1 select x).ToList();

                if (Active.Count != PreActive.Count)
                {
                    var lstMember = (from x in db.MASTERMEMBERs where x.DATEOFJOINING >= dtFromDate && x.DATEOFJOINING <= dtToDate select x).ToList();

                    int iTotalActive = PreActive.Count + lstMember.Count;
                    if (iTotalActive == Active.Count)
                    {

                    }
                }





                //var lstmm = from mm in lstMember
                //            join st in lstStatus on mm.MEMBER_CODE equals st.MEMBER_CODE into Stat
                //            from StatusData in Stat.DefaultIfEmpty()
                //            where new { lstStatus.}
                //            select new { code = mm.MEMBER_CODE, Member = mm, Status = StatusData };


                //foreach (var mm in lstMember)
                //{
                //    var lstActive = (from x in db.MasterMemberStatus where x.FeeYear == dt.Year && x.FeeMonth == dt.Month && x.STATUS_CODE == 1 select x).ToList();
                //    var lstDefaulter = (from x in db.MasterMemberStatus where x.FeeYear == dt.Year && x.FeeMonth == dt.Month && x.STATUS_CODE == 2 select x).ToList();
                //    var lstSturkoff = (from x in db.MasterMemberStatus where x.FeeYear == dt.Year && x.FeeMonth == dt.Month && x.STATUS_CODE == 3 select x).ToList();
                //    var lstResigned = (from x in db.MasterMemberStatus where x.FeeYear == dt.Year && x.FeeMonth == dt.Month && x.RESIGNED == 1 select x).ToList();

                //using (SqlConnection con = new SqlConnection(AppLib.connStr))
                //{
                //    DataTable dtMember = new DataTable();
                //    progressBar1.Value = i;
                //    System.Windows.Forms.Application.DoEvents();
                //    SqlCommand cmd = new SqlCommand("SPCOMMPARITION", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add(new SqlParameter("@DATE", ));
                //    cmd.Parameters.Add(new SqlParameter("@MEMBERCODE", ));
                //    cmd.Parameters.Add(new SqlParameter("@STATUS", ));
                //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //    cmd.Parameters.Add(new SqlParameter("@STATUS", ));
                //    adp.Fill(dtMember);
                //}

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
