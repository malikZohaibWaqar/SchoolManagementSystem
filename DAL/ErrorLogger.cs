using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAL
{
    class ErrorLogger
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string MethodName { get; set; }
        public string Exception { get; set; }
        public string Detail { get; set; }
        public string Time { get; set; }
    }
    public class ErrrorLoggerRepository
    {
        private DBTransections transection { get; set; }
        public ErrrorLoggerRepository() { transection = new DBTransections(); }

        public void WriteToErrorLogger(Exception ex)
        {
            try
            {

                string[] monthNames = (new System.Globalization.CultureInfo("en-US")).DateTimeFormat.MonthNames;

                StackTrace st = new StackTrace(ex);
                ErrorLogger ErrorLogger = new ErrorLogger();
                var frame = st.GetFrame(0);
                ErrorLogger.FileName = frame.GetMethod().DeclaringType.ToString();
                ErrorLogger.MethodName = frame.GetMethod().Name;
                ErrorLogger.Exception = ex.Message;
                ErrorLogger.Detail = ex.ToString();
                ErrorLogger.Time = DateTime.Now.Day + " " + monthNames[DateTime.Now.Month - 1] + "," + DateTime.Now.Year + " at " + DateTime.Now.Hour + ": " + DateTime.Now.Minute;

                transection.ErrorLogger.Add(ErrorLogger);
                transection.SaveChanges();
            }
            catch (Exception exp)
            {
            }
        }
    }
}
