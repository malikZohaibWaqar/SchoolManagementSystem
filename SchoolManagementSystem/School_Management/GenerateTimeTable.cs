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
    public partial class GenerateTimeTable : MetroForm
    {
        #region Data Members
        private string FirstLectureStart { get; set; }
        private int LecturesPerDay { get; set; }
        private int BreakAfterLecters { get; set; }
        private string[] LectureTime { get; set; }
        private string[] WeekDays { get; set; }
        private string[] Subjects { get; set; }
        private Dictionary<string, int> LecturesPerWeekCount { get; set; }
        private Dictionary<string, Color> SubjectsColor { get; set; }
        private List<TextBox> LectureTimetextbox { get; set; }
        private List<TextBox> WeekDaystextbox { get; set; }
        private string[] LecturesBlock { get; set; }
        private int totalLectures { get; set; }
       
        #endregion

        public GenerateTimeTable()
        {
            try
            {
                InitializeComponent();
                Dictionary<string, string> TimingsList = new Dictionary<string, string>();
                TimingsList.Add("07:00", "7");
                TimingsList.Add("07:30", "7-30");
                TimingsList.Add("08:00", "8");
                TimingsList.Add("08:30", "8-30");
                TimingsList.Add("09:00", "9");

                comboBoxFirstLectureStartTime.DataSource = new BindingSource(TimingsList, null);
                comboBoxFirstLectureStartTime.DisplayMember = "Key";
                comboBoxFirstLectureStartTime.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        #region Time Table Methods

        private void AddSubjectsInScheduleColumns_Shuffled()
        {
            try
            {
                #region Adding Subjects to Schedule Column Code
                //totalLectures = (LecturesPerDay *6) - Array.FindAll(LecturesBlock, m => m.Contains("_Friday") || m.Contains("_Break")).Length;
                Random rnd = new Random();
                for (int i = 0; i < totalLectures; i++)
                {
                    int ArrayIndex = rnd.Next(0, (LecturesBlock.Length - 1));
                    // int SubjectIndex = rnd.Next(0, (Subjects.Length - 1));
                    int SubjectIndex = GetSubjectIndex();
                    TextBox txtbox;

                    if (LecturesBlock[ArrayIndex] != string.Empty && !LecturesBlock[ArrayIndex].Contains("_Friday") && !LecturesBlock[ArrayIndex].Contains("_Break"))
                    {
                        txtbox = panelShedule.Controls.Find(LecturesBlock[ArrayIndex], false)[0] as TextBox;
                        txtbox.Text = Subjects[SubjectIndex];
                        txtbox.BackColor = SubjectsColor[Subjects[SubjectIndex]];
                        LecturesBlock[ArrayIndex] = "";
                    }
                    else
                    {
                        int attempts = 0;
                        while (LecturesBlock[ArrayIndex] == string.Empty || LecturesBlock[ArrayIndex].Contains("_Friday") || LecturesBlock[ArrayIndex].Contains("_Break"))
                        {
                            ArrayIndex = rnd.Next(0, (LecturesBlock.Length - 1));
                            attempts++;
                            if (attempts > 15)
                            {
                                ArrayIndex = Array.FindIndex(LecturesBlock, m => m.Contains(':'));
                                attempts = 0;
                            }
                        }
                        txtbox = panelShedule.Controls.Find(LecturesBlock[ArrayIndex], false)[0] as TextBox;
                        txtbox.Text = Subjects[SubjectIndex];
                        txtbox.BackColor = SubjectsColor[Subjects[SubjectIndex]];
                        LecturesBlock[ArrayIndex] = "";
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void AddSubjectsInScheduleColumns_Straight()
        {
            try
            {
                #region Adding Subjects to Schedule Column Code
                Random rnd = new Random();
                int index = LecturesPerDay - 1;
                for (int i = 0; i < LecturesBlock.Length; i++)
                {
                    TextBox txtbox;
                    if (LecturesBlock[i] != string.Empty && !LecturesBlock[i].Contains("_Friday") && !LecturesBlock[i].Contains("_Break"))
                    {
                        if (index < 0)
                            index = LecturesPerDay - 1;

                        txtbox = panelShedule.Controls.Find(LecturesBlock[i], false)[0] as TextBox;
                        txtbox.Text = Subjects[index];
                        txtbox.BackColor = SubjectsColor[Subjects[index]];
                        LecturesBlock[i] = "";
                        index--;
                    }
                    else
                    {
                        if (LecturesBlock[i].Contains("_Friday"))
                            index--;
                    }
                }
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
                int BlockCount = 0;
                for (int i = 0; i < WeekDays.Length; i++)
                {
                    for (int j = 0; j < LectureTime.Length; j++)
                    {
                        x += 150;
                        //y += 43;
                        TextBox t = new TextBox();
                        t.Size = new Size(150, 43);
                        t.Font = new Font("tahoma", 12);
                        t.ForeColor = Color.White;
                        t.Location = new Point(x, y);
                        t.Multiline = true;
                        t.Name = WeekDays[i] + "_" + LectureTime[j];
                        //t.BorderStyle = BorderStyle.Fixed3D;
                        //t.Text = WeekDays[i] + "_" + LectureTime[j];
                        string LecturesBlockValue = WeekDays[i] + "_" + LectureTime[j];
                        if (i == 4 && j > (LecturesPerDay - 2)) //Friday
                        {
                           // t.BorderStyle = BorderStyle.None;
                            t.Text = "Half-Day";
                            t.ForeColor = Color.Red;
                            t.Enabled = false;
                            t.BackColor = Color.Black;
                            LecturesBlockValue = "_Friday";
                        }
                        if (j == BreakAfterLecters) //Break
                        {
                           // t.BorderStyle = BorderStyle.None;
                            t.ForeColor = Color.Red;
                            t.Text = "Break-Time";
                            t.Enabled = false;
                            t.BackColor = Color.White;
                            LecturesBlockValue = "_Break";
                        }
                        t.TextAlign = HorizontalAlignment.Center;

                        panelShedule.Controls.Add(t);
                        LecturesBlock[BlockCount] = LecturesBlockValue;
                        BlockCount++;
                    }
                    x = -150;
                    y += 43;
                }
                #endregion

            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void CreateWeekColumns()
        {
            try
            {
                #region Week Column Code
                for (int i = 0; i < WeekDays.Length; i++)
                {
                    TextBox t = new TextBox();
                    t.Size = new Size(150, 43);
                    t.Text = WeekDays[i];
                   // t.BorderStyle = BorderStyle.Fixed3D;
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
                for (int i = 0; i < LectureTime.Length; i++)
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

                for (int i = LectureTimetextbox.Count - 1; i >= 0; i--)
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
        private void InitializeTimeTableParameters()
        {
            try
            {
                #region Initialization
                FirstLectureStart = comboBoxFirstLectureStartTime.SelectedValue.ToString(); //"8-30";
                LecturesPerDay = int.Parse(txtTotalSubjects.Value.ToString()); //6;
                BreakAfterLecters = int.Parse(txtBreakAfterLectures.Value.ToString()); //3;

                int LecterDuration = int.Parse(txtLecturesDuration.Value.ToString());
                int PauseBetweenLectures = int.Parse(txtLecturesPause.Value.ToString());
                int BreakDuration = int.Parse(txtBreakDuration.Value.ToString());

                totalLectures = (6 * LecturesPerDay) - 2;// Total Days * Total Lectures - (Total Lectures - (BreakAfterLectures+1);
                LectureTime = GetLectureTimings(FirstLectureStart, LecturesPerDay, LecterDuration, PauseBetweenLectures, BreakDuration, BreakAfterLecters);
                WeekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                Subjects = new string[int.Parse(txtTotalSubjects.Value.ToString())];
                LecturesPerWeekCount = new Dictionary<string, int>();
                SubjectsColor = new Dictionary<string, Color>();

                for (int i = 0; i < int.Parse(txtTotalSubjects.Value.ToString()); i++)
                {
                    TextBox txt = groupBoxSubject.Controls.Find("txtSubject_" + i, true).FirstOrDefault() as TextBox;
                    NumericUpDown num = groupBoxSubject.Controls.Find("NumUpDwnSubject_" + i, true).FirstOrDefault() as NumericUpDown;
                    Subjects[i] = txt.Text;
                    LecturesPerWeekCount.Add(txt.Text, int.Parse(num.Value.ToString()));
                    SubjectsColor.Add(txt.Text, txt.BackColor);
                }

                LecturesBlock = new string[6 * (LecturesPerDay + 1)];
                LectureTimetextbox = new List<TextBox>();
                WeekDaystextbox = new List<TextBox>();

                #endregion
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private string[] GetLectureTimings(string FirstLectureStart, int TotalLectures, int lectureTime, int LecturePause, int BreakTime, int BreakAfterLecters)
        {
            try
            {
                int Hour = int.Parse(FirstLectureStart.Split('-')[0]);
                int minute = (FirstLectureStart.Contains('-') ? int.Parse(FirstLectureStart.Split('-')[1]) : 0);
                TimeSpan span = new TimeSpan(Hour, minute, 0);

                string[] LectureTimings = new string[TotalLectures + 1];
                for (int i = 0; i < TotalLectures + 1; i++)
                {
                    if (i != 0 && i != BreakAfterLecters && i != BreakAfterLecters + 1)
                    {
                        span = span.Add(new TimeSpan(0, LecturePause, 0));
                    }
                    if (i == BreakAfterLecters)
                    {
                        LectureTimings[i] = span.ToString(@"hh\:mm");
                        span = span.Add(new TimeSpan(0, BreakTime, 0));
                        LectureTimings[i] += "-" + span.ToString(@"hh\:mm");
                    }
                    else
                    {
                        LectureTimings[i] = span.ToString(@"hh\:mm");
                        span = span.Add(new TimeSpan(0, lectureTime, 0));
                        LectureTimings[i] += "-" + span.ToString(@"hh\:mm");
                    }
                }
                return LectureTimings;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                return new string[] { };
            }
        }
        private int GetSubjectIndex()
        {
            try
            {
                Random rnd = new Random();
                int SubjectIndex = rnd.Next(0, (Subjects.Length - 1));


                if (int.Parse(LecturesPerWeekCount[Subjects[SubjectIndex]].ToString()) > 0)
                {
                    LecturesPerWeekCount[Subjects[SubjectIndex]] = int.Parse(LecturesPerWeekCount[Subjects[SubjectIndex]].ToString()) - 1;
                    return SubjectIndex;
                }
                else
                {
                    int Subattempts = 0;
                    while (int.Parse(LecturesPerWeekCount[Subjects[SubjectIndex]].ToString()) <= 0)
                    {
                        SubjectIndex = rnd.Next(0, (Subjects.Length - 1));

                        if (Subattempts > 15)
                        {
                            var sbjt = LecturesPerWeekCount.FirstOrDefault(m => m.Value > 0).Key;
                            SubjectIndex = Array.FindIndex(Subjects, m => m.Contains(sbjt));
                            Subattempts = 0;
                        }
                        Subattempts++;
                    }
                    LecturesPerWeekCount[Subjects[SubjectIndex]] = int.Parse(LecturesPerWeekCount[Subjects[SubjectIndex]].ToString()) - 1;
                    return SubjectIndex;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                return 0;
            }
        }
        private void txtTotalSubjects_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                panelBoxSubject.Controls.Clear();
                NumericUpDown NUD = sender as NumericUpDown;
                for (int i = 0; i < NUD.Value; i++)
                {
                    Panel pnl = new Panel();
                    pnl.Dock = DockStyle.Top;
                    pnl.Height = 35;
                    pnl.Font = new Font("tahoma", 10);

                    Label lblSubject = new Label();
                    lblSubject.Text = "Subject";
                    lblSubject.AutoSize = false;
                    lblSubject.Width = 60;
                    lblSubject.Location = new Point(6, 9);

                    TextBox txt = new TextBox();
                    txt.Location = new Point(73, 5);
                    txt.Width = 145;
                    txt.Enter += txtSubject_Enter;
                    txt.Name = "txtSubject_" + i;

                    Label lblLectrPerWeek = new Label();
                    lblLectrPerWeek.Text = "Lectures in week";
                    lblLectrPerWeek.AutoSize = false;
                    lblLectrPerWeek.Width = 120;
                    lblLectrPerWeek.Location = new Point(224, 9);

                    NumericUpDown numUpDwn = new NumericUpDown();
                    numUpDwn.Location = new Point(350, 5);
                    numUpDwn.Width = 50;
                    numUpDwn.Name = "NumUpDwnSubject_" + i;

                    pnl.Controls.Add(lblSubject);
                    pnl.Controls.Add(txt);
                    pnl.Controls.Add(lblLectrPerWeek);
                    pnl.Controls.Add(numUpDwn);
                    panelBoxSubject.Controls.Add(pnl);
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void txtSubject_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                if (SubjectColorDialog.ShowDialog() == DialogResult.OK)
                {
                    while (SubjectColorDialog.Color == Color.Black || SubjectColorDialog.Color == Color.White)
                    {
                        SubjectColorDialog.ShowDialog();
                    }
                }
                txt.BackColor = SubjectColorDialog.Color;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void btnGenerateTimeTable_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Button btn = sender as Button;
                bool IsSimple = false;
                if (btn.Name == "btnSimpleTimeTable")
                    IsSimple = true;

                panelWeekDays.Controls.Clear();
                panelLectureTiming.Controls.Clear();
                panelShedule.Controls.Clear();

                if (ValidateTimeTableParameters(IsSimple))
                {
                    InitializeTimeTableParameters();
                    #region Dummy textField

                    TextBox tDummy = new TextBox();
                    tDummy.Size = new Size(150, 43);
                    //tDummy.BorderStyle = BorderStyle.Fixed3D;
                    tDummy.Font = new Font("tahoma", 12, FontStyle.Bold);
                    tDummy.Text = comboBoxClass.Text;
                    tDummy.Dock = DockStyle.Left;
                    tDummy.Multiline = true;
                    tDummy.TextAlign = HorizontalAlignment.Center;
                    tDummy.Enabled = false;
                    LectureTimetextbox.Add(tDummy);

                    #endregion
                    CreateTimeColumns();
                    CreateWeekColumns();
                    CreateScheduleColumns();
                    if (IsSimple)
                        AddSubjectsInScheduleColumns_Straight();
                    else
                        AddSubjectsInScheduleColumns_Shuffled();
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private bool ValidateTimeTableParameters(bool IsSimple)
        {
            try
            {
                if (txtTotalSubjects.Value == 0 || txtLecturesDuration.Value == 0 || txtLecturesPause.Value == 0 || txtBreakAfterLectures.Value == 0 || txtBreakDuration.Value == 0)
                {
                    Utility.showMessage("Warning", "All parameter of time table must have greater than 0 value", "warning");
                    return false;
                }
                int Count = 0;
                for (int i = 0; i < int.Parse(txtTotalSubjects.Value.ToString()); i++)
                {
                    TextBox txt = groupBoxSubject.Controls.Find("txtSubject_" + i, true).FirstOrDefault() as TextBox;
                    NumericUpDown num = groupBoxSubject.Controls.Find("NumUpDwnSubject_" + i, true).FirstOrDefault() as NumericUpDown;
                    if (txt.Text == "" || (!IsSimple && num.Value == 0))
                    {
                        Utility.showMessage("Warning", "Enlist all subjects and no of lectures per week", "warning");
                        return false;
                    }
                    Count += int.Parse(num.Value.ToString());
                }
                if (Count > ((int.Parse(txtTotalSubjects.Value.ToString()) * 6) - 2))
                {
                    Utility.showMessage("Warning", "Sum of all subject's lectures must equal to available slots in week", "warning");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                return false;
            }
        }

        #endregion

        private void TimeTable_Load(object sender, EventArgs e)
        {
            try
            {
                txtTotalSubjects.Value = 8;
                txtLecturesDuration.Value = 30;
                txtLecturesPause.Value = 5;
                txtBreakAfterLectures.Value = 4;
                txtBreakDuration.Value = 30;

                for (int i = 0; i < int.Parse(txtTotalSubjects.Value.ToString()); i++)
                {
                    TextBox txt = groupBoxSubject.Controls.Find("txtSubject_" + i, true).FirstOrDefault() as TextBox;
                    NumericUpDown num = groupBoxSubject.Controls.Find("NumUpDwnSubject_" + i, true).FirstOrDefault() as NumericUpDown;
                    txt.Text = "Sub" + i;
                }

                comboBoxClass.DataSource = new ClassRepository().GetALLClasses();
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
               // ShowResultOnFrom(ex.Message + "_exception");
            }

        }
        private void btnSaveTimeTable_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtTimeTableName.Text == "Enter Time Table Name")
                    Utility.showMessage("Warning","Enter time table name to save time table", "warning");
                else
                {
                    string TimeTable = "";
                    string LectureTimings = "";
                    foreach (TextBox txt in panelShedule.Controls)
                    {
                        TimeTable += txt.Name + "|" + txt.Text + "|" + txt.BackColor.Name + "|";
                    }
                    foreach (TextBox txt in panelWeekDays.Controls)
                    {
                        LectureTimings += txt.Text + "|";
                    }
                    TimeTableEntity TTE = new TimeTableEntity();
                    TTE.TimeTableName = txtTimeTableName.Text;
                    TTE.LectureTimings = LectureTimings;
                    TTE.TimeTable = TimeTable;
                    TTE.ClassID = int.Parse(comboBoxClass.SelectedValue.ToString());
                    TTE.ClassName = comboBoxClass.Text;
                    if (new TimeTableRepository().SaveTimeTable(TTE) > 0)
                        Utility.showMessage("Success", "Your time table has been successfully saved.Navigate to load time table to view", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSavePng_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimeTableName.Text == "Enter Time Table Name")
                    Utility.showMessage("Warning", "Enter time table name to export time table", "warning");
                else
                {
                    Bitmap bm1 = new Bitmap(panelWeekDays.Width, panelWeekDays.Height);
                    panelWeekDays.DrawToBitmap(bm1, new Rectangle(0, 0, panelWeekDays.Width, panelWeekDays.Height));

                    Bitmap bm2 = new Bitmap(panelLectureTiming.Width, panelLectureTiming.Height);
                    panelLectureTiming.DrawToBitmap(bm2, new Rectangle(0, 0, panelLectureTiming.Width, panelLectureTiming.Height));

                    Bitmap bm3 = new Bitmap(panelShedule.Width - 60, panelShedule.Height);
                    panelShedule.DrawToBitmap(bm3, new Rectangle(0, 0, panelShedule.Width, panelShedule.Height));

                    Bitmap image = Utility.MergeImages(bm1, bm2, bm3);
                    image.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + txtTimeTableName.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    Utility.showMessage("Success", "Time table exported at desktop", "success"); 
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
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
        private void txtTimeTableName_Enter(object sender, EventArgs e)
        {
            if (txtTimeTableName.Text == "Enter Time Table Name")
                txtTimeTableName.Text = "";
        }
        private void txtTimeTableName_Leave(object sender, EventArgs e)
        {
            if (txtTimeTableName.Text == "")
                txtTimeTableName.Text = "Enter Time Table Name";
        }
    }
}
