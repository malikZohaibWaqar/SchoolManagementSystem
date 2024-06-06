using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Splash : Form
    {
        int timeTick = 0;
        private DialogResult dialogResult { get; set; }
        public Splash()
        {
            InitializeComponent();
            txtPanel1.BackColor = Color.FromArgb(50, 255, 255, 255);
            txtpanel2.BackColor = Color.FromArgb(50, 255, 255, 255);
            txtPanel3.BackColor = Color.FromArgb(50, 255, 255, 255);
            txtpanel4.BackColor = Color.FromArgb(50, 255, 255, 255);


            lblCompanyName.ForeColor = Color.White;
            lblVersion.ForeColor = Color.White;
            lblSchool.ForeColor = Color.White;
            lblInfo.ForeColor = Color.White;
            lblAction.ForeColor = Color.White;
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            lblAction.Text = "initializing system... Don't shutdown or unplug your system";
        }
        private void Splash_Shown(object sender, EventArgs e)
        {
            timer.Start();
            
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (new DAL.SchoolInfoRepository().GetSschoolInfo().PreRunDate != null)
                {
                    DateTime preRun = (DateTime)new DAL.SchoolInfoRepository().GetSschoolInfo().PreRunDate;
                    if (DateTime.Compare(DateTime.Now, preRun) < 0)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            Utility.showMessage("System Failure", "Your Clock is behind.Can't initiate system because your computer's date time is incorrect", "error");
                            dialogResult = System.Windows.Forms.DialogResult.Abort;
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (new DAL.SchoolInfoRepository().UpdatePreRunDate(DateTime.Now) > 0)
                                dialogResult = System.Windows.Forms.DialogResult.OK;
                            else
                                Utility.showMessage("System Failure", "System can't initiate.Check error logs or contact service provider", "error");
                        });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (new DAL.SchoolInfoRepository().UpdatePreRunDate(DateTime.Now) > 0)
                            dialogResult = System.Windows.Forms.DialogResult.OK;
                        else
                            Utility.showMessage("System Failure", "System can't initiate.Check error logs or contact service provider", "error");
                    });
                }

                this.Invoke((MethodInvoker)delegate { lblAction.Text = "Creating system restore point"; });
                System.Threading.Thread.Sleep(3000);

                if (dialogResult != System.Windows.Forms.DialogResult.Abort)
                {
                    if (new DAL.SchoolInfoRepository().GetSschoolInfo().DBbkDate != null)
                    {
                        DateTime dbBkDate = (DateTime)new DAL.SchoolInfoRepository().GetSschoolInfo().DBbkDate;

                        if (DateTime.Compare(DateTime.Now, dbBkDate) > 30)
                            CreateDBBackupAndUpdateDate();
                        else
                        this.dialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        CreateDBBackupAndUpdateDate();
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                backgroundWorker.CancelAsync();
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblAction.Text = "Launching system ...";
            timer.Start();
        }
        private void CreateDBBackupAndUpdateDate()
        {
            if (DAL.SoftwareMaintainance.CreateDBBackup())
                this.Invoke((MethodInvoker)delegate
                {
                    new DAL.SchoolInfoRepository().UpdateDBbakupDate(DateTime.Now);
                    dialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Invoke((MethodInvoker)delegate { lblAction.Text = "System restore point created"; });
                    System.Threading.Thread.Sleep(3000);
                });
            else
                this.Invoke((MethodInvoker)delegate { Utility.showMessage("System Failure", "System can't create restore point.Check error logs or contact service provider", "error"); });
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timeTick++;
            if (timeTick == 5)
            {
                timer.Stop();
                backgroundWorker.RunWorkerAsync();
            }
            if (timeTick == 10)
            {
                timer.Stop();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
