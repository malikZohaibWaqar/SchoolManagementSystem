using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace SchoolManagementSystem
{
    public static class Utility
    {
        
        private static string modules { get; set; }
        public static  DataTable ToDataTable<T>(List<T> items)
        {
            try
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return new DataTable();
            }
        }
        public static string GenerateUniqueNameForImage()
        {
            try
            {
                Random rnd = new Random();
                DateTime dt = DateTime.Now;
                return dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond + "_" + rnd.Next(1, 200) + "_" + rnd.Next(300, 500) + "_" + rnd.Next(600, 800) + "_" + rnd.Next(900, 1100);
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return string.Empty;
            }
        }
        public static Bitmap MergeImages(Image firstImage, Image secondImage, Image thirdImage)
        {
            int outputImageWidth = secondImage.Width + thirdImage.Width;

            int outputImageHeight = firstImage.Height + secondImage.Height;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height + 1), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(thirdImage, new Rectangle(new Point(secondImage.Width, firstImage.Height + 1), thirdImage.Size),
                    new Rectangle(new Point(), thirdImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }
        public static void showMessage(string header,string message,string type)
        {
            new Component.messageBox(header, message, type).ShowDialog();
        }
        public static bool initializeModules(bool isGuest = false)
        {
            if (!isGuest)
            {
                DAL.AccessControlEntity ACE = new DAL.AccessControlRepository().GetAccessControlByID(Properties.Settings.Default.UserID);
                if (ACE != null)
                {
                    modules = ACE.modules;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                modules = System.Configuration.ConfigurationManager.AppSettings["guestUser"].ToString();
                return true;
            }

        }
        public static bool verifyAccess(string moduleName,bool intimateUser = true)
        {
            if (modules != null && modules.Contains(moduleName))
                return true;
            else
            {
                if (intimateUser)
                    showMessage("Access denied", "You may not have the appropriate permissions to access this module", "warning");

                return false;
            }
        }
    }
}
