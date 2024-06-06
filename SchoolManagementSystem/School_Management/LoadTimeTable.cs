using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.School_Management
{
    public partial class LoadTimeTable : MetroForm
    {
        private string[] WeekDays { get; set; }
        private string[] LectureTime { get; set; }
        public LoadTimeTable()
        {
            try
            {
                InitializeComponent();
                comboBoxClass.DataSource = new ClassRepository().GetALLClasses();
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ID";
                comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;
                LoadTimeTableFromDB();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimeTableFromDB();
        }
        private void LoadTimeTableFromDB()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                WeekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                TimeTableEntity TTE = new TimeTableRepository().GetTimeTableByClassID(int.Parse(comboBoxClass.SelectedValue.ToString()));
                if (TTE != null)
                {
                    LectureTime = TTE.LectureTimings.Split('|');
                    CreateWeekColumns();
                    CreateTimeColumns();
                    CreateScheduleColumns();
                    //Utility.showMessage("Success", "Time Table loaded successfully", "success");
                }
                else
                {
                    panelLectureTiming.Controls.Clear();
                    panelWeekDays.Controls.Clear();
                    panelShedule.Controls.Clear();
                    Utility.showMessage("Error", "Time Table not saved for current class", "error");
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }

        private void CreateWeekColumns()
        {
            try
            {
                #region Week Column Code
                List<TextBox> WeekDaystextbox = new List<TextBox>();
                for (int i = 0; i < WeekDays.Length; i++)
                {
                    TextBox t = new TextBox();
                    t.Size = new Size(150, 43);
                    t.Text = WeekDays[i];
                  //  t.BorderStyle = BorderStyle.Fixed3D;
                    t.Font = new Font("tahoma", 12, FontStyle.Bold);
                    t.Dock = DockStyle.Top;
                    t.Multiline = true;
                    t.Enabled = false;
                    t.TextAlign = HorizontalAlignment.Center;
                    WeekDaystextbox.Add(t);
                }

                for (int i = WeekDaystextbox.Count - 1; i >= 0; i--)
                {
                    panelLectureTiming.Controls.Add(WeekDaystextbox[i]);
                }
                #endregion
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void CreateTimeColumns()
        {
            try
            {
                #region Time Column Code
                List<TextBox> LectureTimetextbox = new List<TextBox>();
                for (int i = 0; i < LectureTime.Length - 1; i++)
                {
                    TextBox t = new TextBox();
                    t.Size = new Size(150, 43);
                    t.Text = LectureTime[i];
                   // t.BorderStyle = BorderStyle.Fixed3D;
                    t.Font = new Font("tahoma", 12, FontStyle.Bold);
                    t.Dock = DockStyle.Left;
                    t.Multiline = true;
                    t.TextAlign = HorizontalAlignment.Center;
                    t.Enabled = false;
                    LectureTimetextbox.Add(t);
                }

                for (int i = 0; i < LectureTimetextbox.Count; i++)
                {
                    panelWeekDays.Controls.Add(LectureTimetextbox[i]);
                }
                panelTimeTable.Width = 150 * (LectureTimetextbox.Count) + 2;
                panelWeekDays.Width = 150 * (LectureTimetextbox.Count);
                panelShedule.Width = LectureTimetextbox.Count > 8 ? (150 * (LectureTimetextbox.Count - 1) + 60) : 150 * (LectureTimetextbox.Count - 1);
                #endregion
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void CreateScheduleColumns()
        {
            try
            {
                #region Schedule Column Code
                int x = -150;
                int y = 0;
                List<TextBox> TxtBoxTimeTable = new List<TextBox>();
                int currentIndex = 0;
                int previousIndex = 0;
                string[] TimeTable = new TimeTableRepository().GetTimeTableByClassID(int.Parse(comboBoxClass.SelectedValue.ToString())).TimeTable.Split('|');
                for (int i = 0; i < TimeTable.Length - 1; i += 3)
                {
                    x += 150;
                    TextBox t = new TextBox();
                    t.Size = new Size(150, 43);
                    t.Font = new Font("tahoma", 12);

                    t.ForeColor = Color.White;
                    t.Multiline = true;
                    t.Name = TimeTable[i];
                    //t.BorderStyle = BorderStyle.Fixed3D;
                    t.Text = TimeTable[i + 1] + Environment.NewLine + TimeTable[i];
                    //t.BackColor = (TimeTable[i + 2].ToString().All(char.IsLetter) ? Color.FromName(TimeTable[i + 2]) : ColorTranslator.FromHtml(TimeTable[i + 2]));
                    t.BackColor = (TimeTable[i + 2].ToString().All(char.IsLetter) ? Color.FromName(TimeTable[i + 2]) : Color.FromArgb(int.Parse(TimeTable[i + 2].Replace("#", ""), System.Globalization.NumberStyles.AllowHexSpecifier)));
                    currentIndex = Array.IndexOf(WeekDays, TimeTable[i].Split('_')[0]);
                    y = 43 * (Array.IndexOf(WeekDays, TimeTable[i].Split('_')[0]));
                    if (currentIndex > previousIndex)
                    {
                        x = 0;
                        previousIndex = currentIndex;
                    }
                    t.Location = new Point(x, y);
                    t.Enabled = false;
                    TxtBoxTimeTable.Add(t);
                }
                for (int i = 0; i < TxtBoxTimeTable.Count; i++)
                {
                    panelShedule.Controls.Add(TxtBoxTimeTable[i]);
                }
                #endregion
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void btnSavePng_Click(object sender, EventArgs e)
        {
            Bitmap bm1 = new Bitmap(panelWeekDays.Width, panelWeekDays.Height);
            panelWeekDays.DrawToBitmap(bm1, new Rectangle(0, 0, panelWeekDays.Width, panelWeekDays.Height));

            Bitmap bm2 = new Bitmap(panelLectureTiming.Width, panelLectureTiming.Height);
            panelLectureTiming.DrawToBitmap(bm2, new Rectangle(0, 0, panelLectureTiming.Width, panelLectureTiming.Height));

            Bitmap bm3 = new Bitmap(panelShedule.Width - 60, panelShedule.Height);
            panelShedule.DrawToBitmap(bm3, new Rectangle(0, 0, panelShedule.Width, panelShedule.Height));

            Bitmap image = Utility.MergeImages(bm1, bm2, bm3);
            image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + comboBoxClass.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
            Utility.showMessage("Success", "Time table exported at desktop", "success");

        }
        private void btnPrintTimeTable_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += (send, args) =>
            {

                Bitmap bm1 = new Bitmap(panelWeekDays.Width, panelWeekDays.Height);
                panelWeekDays.DrawToBitmap(bm1, new Rectangle(0, 0, panelWeekDays.Width, panelWeekDays.Height));

                Bitmap bm2 = new Bitmap(panelLectureTiming.Width, panelLectureTiming.Height);
                panelLectureTiming.DrawToBitmap(bm2, new Rectangle(0, 0, panelLectureTiming.Width, panelLectureTiming.Height));

                Bitmap bm3 = new Bitmap(panelShedule.Width - 60, panelShedule.Height);
                panelShedule.DrawToBitmap(bm3, new Rectangle(0, 0, panelShedule.Width, panelShedule.Height));

                Bitmap i = Utility.MergeImages(bm1, bm2, bm3);
                Rectangle m = args.MarginBounds;

                if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                {
                    m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                }
                args.Graphics.DrawImage(i, m);
            };
            doc.Print();
        }
    }
}
