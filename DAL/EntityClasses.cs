using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    // -------------  Entities -----------------

    #region Entities

    public class SignInEntity
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class ExpensesEntity
    {
        public int ID { get; set; }
        public double BuildingRent { get; set; }
        public double ElectricityBill { get; set; }
        public double GasBill { get; set; }
        public double VehicleExpense { get; set; }
        public double Misc { get; set; }
        public string Description { get; set; }
        public int Vehicle { get; set; }
        public DateTime BillingMonth { get; set; }
    }
    public class AccessControlEntity
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string modules { get; set; }
    }
    public class StudentEntity
    {
        public int ID { get; set; }
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmergencyNo { get; set; }
        public string FatherName { get; set; }
        public string FatherContact { get; set; }
        public string MotherName { get; set; }
        public string GuardianName { get; set; }
        public string RelationWithGuardian { get; set; }
        public int Class { get; set; }
        public int FeesCatagory { get; set; }
        public int VehicleID { get; set; }
        public int VehicleCharges { get; set; }
        public bool isPassOut { get; set; }
        public string ImageName { get; set; }
    }
    public class ClassEntity
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
    }
    public class FeesCatagoryEntity
    {
        public int ID { get; set; }
        public string FeeCatagory { get; set; }
        public int Fees { get; set; }
    }
    public class FeesCollectionEntity
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public int Fine { get; set; }
        public int Fees { get; set; }
        public DateTime Date { get; set; }
    }
    public class EmployeeEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmergencyNo { get; set; }
        public string Qualification { get; set; }
        public int Experiance { get; set; }
        public int DepartmentID { get; set; }
        public int EmployeeTypeID { get; set; }
        public int Salary { get; set; }
        public int VehicleID { get; set; }
        public int VehicleCharges { get; set; }
        public string ImageName { get; set; }

    }
    public class EmployeeTypeEntity
    {
        public int ID { get; set; }
        public string EmployeeType { get; set; }
    }
    public class DepartmentEntity
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
    }
    public class SchoolInfoEntity
    {
        public int ID { get; set; }
        public string SchoolName { get; set; }
        public string LicenseKey { get; set; }
        public string ActivationKey { get; set; }
        public DateTime? PreRunDate { get; set; }
        public DateTime? DBbkDate { get; set; }
    }
    public class SalaryEntity
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime date { get; set; }
        public int Deduction { get; set; }
        public int salary { get; set; }
        public int NetPayable { get; set; }
    }
    public class DriverSalaryEntity
    {
        public int ID { get; set; }
        public int DriverID { get; set; }
        public DateTime SalaryMonth { get; set; }
        public int Deduction { get; set; }
        public int salary { get; set; }
        public int NetPayable { get; set; }
    }
    public class VehicleEntity
    {
        public int ID { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleType { get; set; }
        public int NoOfSeats { get; set; }
        public string Route { get; set; }
    }
    public class DriverEntity
    {
        public int ID { get; set; }
        public string DriverName { get; set; }
        public int VehicleID { get; set; }
        public int Salary { get; set; }
        public string Qualification { get; set; }
    }
    public class ProductCategoryEntity
    {
        public int ID { get; set; }
        public string ProductCategory { get; set; }

    }
    public class ProductEntity
    {
        public int ID { get; set; }
        public int ProductCategory { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
    public class TimeTableEntity
    {
        public int ID { get; set; }
        public string TimeTableName { get; set; }
        public string TimeTable { get; set; }
        public string LectureTimings { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
    
    
    #endregion
    
    // -------------  Repositories -----------------

    #region Repositories
    public class ExpensesRepository
    {
        private DBTransections transection { get; set; }
        public ExpensesRepository() { transection = new DBTransections(); }
        public int AddExpenses(ExpensesEntity s)
        {
            try
            {
                if (s.ID > 0)
                {
                    ExpensesEntity Expenses = new ExpensesEntity();
                    Expenses = transection.Expenses.Find(s.ID);
                    Expenses.BillingMonth = s.BillingMonth;
                    Expenses.BuildingRent = s.BuildingRent;
                    Expenses.Description = s.Description;
                    Expenses.ElectricityBill = s.ElectricityBill;
                    Expenses.GasBill = s.GasBill;
                    Expenses.Misc = s.Misc;
                    Expenses.Vehicle = s.Vehicle;
                    Expenses.VehicleExpense = s.VehicleExpense;
                }
                else
                    transection.Expenses.Add(s);

                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteExpensesByID(int ID)
        {
            try
            {
                if (transection.Expenses.Remove(transection.Expenses.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public ExpensesEntity GetExpensesByID(int? ID)
        {
            try
            {
                return transection.Expenses.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<ExpensesEntity> GetALLExpenses(DateTime date)
        {
            try
            {
                return transection.Expenses.Where(e=>e.BillingMonth.Month == date.Month && e.BillingMonth.Year == date.Year).OrderBy(m => m.ID).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class SignInRepository
    {
        private DBTransections transection { get; set; }
        public SignInRepository() { transection = new DBTransections(); }
        public SignInEntity ValidateSignIn(string userName, string password)
        {
            try
            {
                return transection.SignIn.Where(m => m.userName == userName && m.password == password).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public int AddUpdateSignIn(SignInEntity s)
        {
            try
            {
                if (s.ID > 0)
                {
                    SignInEntity SignIn = new SignInEntity();
                    SignIn = transection.SignIn.Find(s.ID);
                    SignIn.userName = s.userName;
                    SignIn.password = s.password;
                }
                else
                    transection.SignIn.Add(s);
                
                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteSignInByID(int ID)
        {
            try
            {
                if (transection.SignIn.Remove(transection.SignIn.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public SignInEntity GetSignInByID(int? ID)
        {
            try
            {
                return transection.SignIn.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<SignInEntity> GetALLSignIn()
        {
            try
            {
                return transection.SignIn.OrderBy(m => m.userName).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class AccessControlRepository
    {
        private DBTransections transection { get; set; }
        public AccessControlRepository() { transection = new DBTransections(); }
        public int AddUpdateAccessControl(AccessControlEntity ac)
        {
            try
            {

                AccessControlEntity AccessControl = new AccessControlEntity();
                AccessControl = transection.AccessControl.Where(m=>m.userID == ac.userID).SingleOrDefault();
                if (AccessControl != null)
                    AccessControl.modules = ac.modules;
                else
                    transection.AccessControl.Add(ac);

                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteAccessControl(int ID)
        {
            try
            {
                if (transection.AccessControl.Remove(transection.AccessControl.Where(m => m.userID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public AccessControlEntity GetAccessControlByID(int? ID)
        {
            try
            {
                return transection.AccessControl.Where(m => m.userID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class SchoolInfoRepository
    {
        private DBTransections transection { get; set; }
        public SchoolInfoRepository() { transection = new DBTransections(); }
        public int AddUpdateScoolInfo(SchoolInfoEntity s)
        {
            try
            {
                if (s.ID > 0)
                {
                    SchoolInfoEntity SchoolInfo = new SchoolInfoEntity();
                    SchoolInfo = transection.SchoolInfo.Find(s.ID);
                    SchoolInfo.LicenseKey = s.LicenseKey;
                }
                else
                    transection.SchoolInfo.Add(s);

                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int UpdateLicenseKey(string key)
        {
            try
            {
              SchoolInfoEntity SchoolInfo = new SchoolInfoEntity();
              SchoolInfo = transection.SchoolInfo.FirstOrDefault();
              SchoolInfo.LicenseKey = key;
              return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int UpdateActivationKey(string key)
        {
            try
            {
                SchoolInfoEntity SchoolInfo = new SchoolInfoEntity();
                SchoolInfo = transection.SchoolInfo.FirstOrDefault();
                SchoolInfo.ActivationKey = key;
                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public SchoolInfoEntity GetSschoolInfo()
        {
            try
            {
                return transection.SchoolInfo.FirstOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public int UpdatePreRunDate(DateTime date)
        {
            try
            {
                SchoolInfoEntity SchoolInfo = new SchoolInfoEntity();
                SchoolInfo = transection.SchoolInfo.FirstOrDefault();
                SchoolInfo.PreRunDate = date;
                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int UpdateDBbakupDate(DateTime date)
        {
            try
            {
                SchoolInfoEntity SchoolInfo = new SchoolInfoEntity();
                SchoolInfo = transection.SchoolInfo.FirstOrDefault();
                SchoolInfo.DBbkDate = date;
                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
    }
    public class StudentRepository
    {
        private DBTransections transection { get; set; }
        public StudentRepository() { transection = new DBTransections(); }
        public int EnrollAndUpdateStudent(StudentEntity s)
        {
            try
            {
                if (s.ID > 0)
                {
                    StudentEntity FoundStudent = new StudentEntity();
                    FoundStudent = transection.Student.Find(s.ID);
                    FoundStudent.FirstName = s.FirstName;
                    FoundStudent.LastName = s.LastName;
                    FoundStudent.DOB = s.DOB;
                    FoundStudent.BloodGroup = s.BloodGroup;
                    FoundStudent.Religion = s.Religion;
                    FoundStudent.ContactNo = s.ContactNo;
                    FoundStudent.EmergencyNo = s.EmergencyNo;
                    FoundStudent.FatherName = s.FatherName;
                    FoundStudent.FatherContact = s.FatherContact;
                    FoundStudent.MotherName = s.MotherName;
                    FoundStudent.GuardianName = s.GuardianName;
                    FoundStudent.RelationWithGuardian = s.RelationWithGuardian;
                    FoundStudent.Class = s.Class;
                    FoundStudent.FeesCatagory = s.FeesCatagory;
                    FoundStudent.ImageName = s.ImageName;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Student.Where(st => st.FirstName == s.FirstName && st.LastName == s.LastName && st.FatherName == s.FatherName && st.MotherName == s.MotherName && st.Class == s.Class).FirstOrDefault() == null)
                    {
                        transection.Student.Add(s);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteStudent(int ID)
        {
            try
            {
                if (transection.Student.Remove(transection.Student.Where(m => m.ID == ID).FirstOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteStudent(StudentEntity entity)
        {
            try
            {
                if (transection.Student.Remove(entity) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public StudentEntity GetStudentByID(int? ID)
        {
            try
            {
                return transection.Student.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<StudentEntity> GetALLStudents(int Class)
        {
            try
            {
                return transection.Student.Where(m => m.Class == Class).OrderBy(m => m.FirstName).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<StudentEntity> GetStudentsByClassID(string IDs)
        {
            try
            {
                return transection.Student.Where(m => IDs.Contains(m.Class.ToString())).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<StudentEntity> GetStudentsByFeesCategoryID(string IDs)
        {
            try
            {
                return transection.Student.Where(m => IDs.Contains(m.FeesCatagory.ToString())).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public DataTable GetStudentsByVehicleID(string IDs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select ID from tblStudent where VehicleID IN ('" + IDs + "')";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<StudentEntity> GetFilteredStudents(int Class,string Gender,int FeesCatagory)
        {
            try
            {
                if (Gender == string.Empty)
                    return transection.Student.Where(m => m.Class == Class && m.FeesCatagory == FeesCatagory).OrderBy(m => m.FirstName).ToList();
                else
                    return transection.Student.Where(m => m.Class == Class && m.FeesCatagory == FeesCatagory && m.Gender == Gender).OrderBy(m => m.FirstName).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public int PromoteStudentByClass(string className,string PromotedClass)
        {
            try
            {
                transection.Database.ExecuteSqlCommand("Update tblStudent set Class = {0} where Class = {1}", PromotedClass, className);
                return 1;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int PromoteStudentByID(string StudentIDs, string PromotedClass)
        {
            try
            {
                if (transection.Database.ExecuteSqlCommand("Update tblStudent set Class = {0} where ID IN(" + StudentIDs + ")", PromotedClass) > 0)
                    return 1;
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int PassOutStudentByID(string StudentIDs)
        {
            try
            {
                if (transection.Database.ExecuteSqlCommand("Update tblStudent set Class = 0, isPassOut = {0} where ID IN(" + StudentIDs + ")", true) > 0)
                    return 1;
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int GetMaxIDOfStudent()
        {
            try
            {
                int maxID = 1;
                if (transection.Student.FirstOrDefault() != null)
                    maxID = transection.Student.Max(m => m.ID);
                return maxID;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return 0;
            }
        }
        public int GetNumOfStudentByVehiceID(int vehicleID)
        {
            try
            {
                return transection.Student.Where(m => m.VehicleID == vehicleID).ToList().Count;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
    }
    public class ClassRepository
    {
        private DBTransections transection { get; set; }
        public ClassRepository() { transection = new DBTransections(); }
        public int AddClass(ClassEntity c)
        {
            try
            {
                if (c.ID > 0)
                {
                    ClassEntity FoundClass = new ClassEntity();
                    FoundClass = transection.Class.Find(c.ID);
                    FoundClass.ClassName = c.ClassName;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Class.Where(m => m.ClassName.ToLower() == c.ClassName.ToLower()).FirstOrDefault() == null)
                    {
                        transection.Class.Add(c);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteClassByID(int ID)
        {
            try
            {
                if (transection.Class.Remove(transection.Class.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
         }
        public ClassEntity GetClassByID(int? ID)
        {
            try
            {
                return transection.Class.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<ClassEntity> GetALLClasses(bool isGrid = false)
        {
            try
            {
                 List<ClassEntity> List = transection.Class.OrderBy(m=>m.ClassName).ToList();
                if (!isGrid)
                    List.Insert(0, new ClassEntity() { ClassName = "ALL" });

                return List;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class FeesCatagoryRepository
    {
        private DBTransections transection { get; set; }
        public FeesCatagoryRepository() { transection = new DBTransections(); }
        public int AddFeesCatagory(FeesCatagoryEntity f)
        {
            try
            {
                if (f.ID > 0)
                {
                    FeesCatagoryEntity FoundFees = new FeesCatagoryEntity();
                    FoundFees = transection.FeesCatagory.Find(f.ID);
                    FoundFees.FeeCatagory = f.FeeCatagory;
                    FoundFees.Fees = f.Fees;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.FeesCatagory.Where(m => m.FeeCatagory.ToLower() == f.FeeCatagory.ToLower()).FirstOrDefault() == null)
                    {
                        transection.FeesCatagory.Add(f);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteFeesCatagoryByID(int ID)
        {
            try
            {
                if (transection.FeesCatagory.Remove(transection.FeesCatagory.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public FeesCatagoryEntity GetFeesCatagoryByID(int? ID)
        {
            try
            {
                return transection.FeesCatagory.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<FeesCatagoryEntity> GetALLFeesCatagories(bool isGrid = false)
        {
            try
            {
                List<FeesCatagoryEntity> List = transection.FeesCatagory.OrderBy(m => m.FeeCatagory).ToList();
                if (!isGrid)
                    List.Insert(0, new FeesCatagoryEntity() { FeeCatagory = "ALL" });

                return List;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class FeesCollectionRepository
    {
        private DBTransections transection { get; set; }
        public FeesCollectionRepository() { transection = new DBTransections(); }
        public int AddFeesCollection(FeesCollectionEntity fc)
        {
            try
            {
                if (fc.ID > 0)
                {
                    FeesCollectionEntity FoundFeesCollection = new FeesCollectionEntity();
                    FoundFeesCollection = transection.FeesCollection.Find(fc.ID);
                    FoundFeesCollection.ClassID = fc.ClassID;
                    FoundFeesCollection.StudentID = fc.StudentID;
                    FoundFeesCollection.Date = fc.Date;
                    FoundFeesCollection.Fine = fc.Fine;
                    FoundFeesCollection.Fees = fc.Fees;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.FeesCollection.Where(f => f.StudentID == fc.StudentID && f.ClassID == fc.ClassID && f.Date == fc.Date).FirstOrDefault() == null)
                    {
                        transection.FeesCollection.Add(fc);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteFeesCollectionByID(int ID)
        {
            try
            {
                if (transection.FeesCollection.Remove(transection.FeesCollection.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public FeesCollectionEntity GetFeesCollectionByID(int? ID)
        {
            try
            {
                return transection.FeesCollection.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<FeesCollectionEntity> GetALLFeesCollections(int ClassID)
        {
            try
            {
                return transection.FeesCollection.Where(m=>m.ClassID == ClassID).OrderByDescending(m => m.ID).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class EmployeeRepository
    {
        private DBTransections transection { get; set; }
        public EmployeeRepository() { transection = new DBTransections(); }
        public int EnrollAndUpdateEmployee(EmployeeEntity s)
        {
            try
            {
                if (s.ID > 0)
                {
                    EmployeeEntity FoundEmployee = new EmployeeEntity();
                    FoundEmployee = transection.Employee.Find(s.ID);
                    FoundEmployee.FirstName = s.FirstName;
                    FoundEmployee.LastName = s.LastName;
                    FoundEmployee.DOB = s.DOB;
                    FoundEmployee.BloodGroup = s.BloodGroup;
                    FoundEmployee.Religion = s.Religion;
                    FoundEmployee.ContactNo = s.ContactNo;
                    FoundEmployee.EmergencyNo = s.EmergencyNo;
                    FoundEmployee.Qualification = s.Qualification;
                    FoundEmployee.Experiance = s.Experiance;
                    FoundEmployee.DepartmentID = s.DepartmentID;
                    FoundEmployee.EmployeeTypeID = s.EmployeeTypeID;
                    FoundEmployee.Salary = s.Salary;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Employee.Where(e => e.FirstName == s.FirstName && e.LastName == s.LastName && e.ContactNo == s.ContactNo && e.DepartmentID == s.DepartmentID && e.EmployeeTypeID == s.EmployeeTypeID).FirstOrDefault() == null)
                    {
                        transection.Employee.Add(s);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteEmployee(int ID)
        {
            try
            {
                if (transection.Employee.Remove(transection.Employee.Where(m => m.ID == ID).FirstOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteEmployee(EmployeeEntity entity)
        {
            try
            {
                transection.Employee.Remove(entity);
                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public EmployeeEntity GetEmployeeByID(int? ID)
        {
            try
            {
                return transection.Employee.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<EmployeeEntity> GetEmployeeByEmployeeTypeID(string IDs)
        {
            try
            {
                return transection.Employee.Where(m => IDs.Contains(m.EmployeeTypeID.ToString())).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<EmployeeEntity> GetEmployeeByDepartmentID(string IDs)
        {
            try
            {
                return transection.Employee.Where(m => IDs.Contains(m.DepartmentID.ToString())).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public DataTable GetEmployeeByVehicleID(string IDs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select ID from tblEmployee where VehicleID IN ('" + IDs + "')";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<EmployeeEntity> GetALLEmployees(int DeptID)
        {
            try
            {
                return transection.Employee.Where(m => m.DepartmentID == DeptID).OrderBy(m => m.FirstName).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<EmployeeEntity> GetFilteredEmployees(int DepartmentID, int EmployeeTypeID, string Qualification, int Experiance) 
        {
            try
            {
                List<EmployeeEntity> EmpList = transection.Employee.Where(m => m.DepartmentID == DepartmentID).ToList();
                
                if (EmployeeTypeID > 0)
                    EmpList = EmpList.Where(m => m.EmployeeTypeID == EmployeeTypeID).ToList();
                if(Qualification != "")
                    EmpList = EmpList.Where(m => m.Qualification == Qualification).ToList();
                if(Experiance > 0)
                    EmpList = EmpList.Where(m => m.Experiance == Experiance).ToList();
                
                return EmpList;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public int GetNumOfEmployeeByVehiceID(int vehicleID)
        {
            try
            {
                return transection.Employee.Where(m => m.VehicleID == vehicleID).ToList().Count;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
    }
    public class EmployeeTypeRepository
    {
        private DBTransections transection { get; set; }
        public EmployeeTypeRepository() { transection = new DBTransections(); }
        public int AddEmployeeType(EmployeeTypeEntity c)
        {
            try
            {
                if (c.ID > 0)
                {
                    EmployeeTypeEntity FoundEmployeeType = new EmployeeTypeEntity();
                    FoundEmployeeType = transection.EmployeeType.Find(c.ID);
                    FoundEmployeeType.EmployeeType = c.EmployeeType;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.EmployeeType.Where(m => m.EmployeeType.ToLower() == c.EmployeeType.ToLower()).FirstOrDefault() == null)
                    {
                        transection.EmployeeType.Add(c);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteEmployeeTypeByID(int ID)
        {
            try
            {
                if (transection.EmployeeType.Remove(transection.EmployeeType.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public EmployeeTypeEntity GetEmployeeTypeByID(int? ID)
        {
            try
            {
                return transection.EmployeeType.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<EmployeeTypeEntity> GetALLEmployeeTypes(bool isGrid = false)
        {
            try
            {
                List<EmployeeTypeEntity> List = transection.EmployeeType.OrderBy(m => m.EmployeeType).ToList();
                if (!isGrid)
                    List.Insert(0, new EmployeeTypeEntity() { EmployeeType = "ALL" });

                return List;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class DepartmentRepository
    {
        private DBTransections transection { get; set; }
        public DepartmentRepository() { transection = new DBTransections(); }
        public int AddDepartment(DepartmentEntity c)
        {
            try
            {
                if (c.ID > 0)
                {
                    DepartmentEntity FoundDepartment = new DepartmentEntity();
                    FoundDepartment = transection.Department.Find(c.ID);
                    FoundDepartment.DepartmentName = c.DepartmentName;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Department.Where(m => m.DepartmentName.ToLower() == c.DepartmentName.ToLower()).FirstOrDefault() == null)
                    {
                        transection.Department.Add(c);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteDepartmentByID(int ID)
        {
            try
            {
                if (transection.Department.Remove(transection.Department.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public DepartmentEntity GetDepartmentByID(int? ID)
        {
            try
            {
                return transection.Department.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<DepartmentEntity> GetALLDepartments(bool isGrid = false)
        {
            try
            {
                List<DepartmentEntity> List = transection.Department.OrderBy(m => m.DepartmentName).ToList();
                if (!isGrid)
                    List.Insert(0, new DepartmentEntity() { DepartmentName = "ALL" });

                return List;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class SalaryRepository
    {
        private DBTransections transection { get; set; }
        public SalaryRepository() { transection = new DBTransections(); }
        public int AddSalary(SalaryEntity c)
        {
            try
            {
                if (c.ID > 0)
                {
                    SalaryEntity FoundSalary = new SalaryEntity();
                    FoundSalary = transection.Salary.Find(c.ID);
                    FoundSalary.EmployeeID = c.EmployeeID;
                    FoundSalary.DepartmentID = c.DepartmentID;
                    FoundSalary.date = c.date;
                    FoundSalary.Deduction = c.Deduction;
                    FoundSalary.salary = c.salary;
                    FoundSalary.NetPayable = c.NetPayable;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Salary.Where(s => s.EmployeeID == c.EmployeeID && s.DepartmentID == c.DepartmentID && s.date == c.date).FirstOrDefault() == null)
                    {
                        transection.Salary.Add(c);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteSalaryByID(int ID)
        {
            try
            {
                if (transection.Salary.Remove(transection.Salary.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public SalaryEntity GetDepartmentByID(int? ID)
        {
            try
            {
                return transection.Salary.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<SalaryEntity> GetALLPaidSalaries(DateTime salaryDate,int DeptID)
        {
            try
            {
                return transection.Salary.Where(m => m.date.Month == salaryDate.Month && m.date.Year == salaryDate.Year && m.DepartmentID == DeptID).OrderByDescending(m => m.date).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public DataTable GetALLSalaries(DateTime salaryDate, int DeptID,string SalaryStatus)
        {
            try
            {
                string cmd = "";
                if (SalaryStatus == "Paid")
                    cmd = "select s.ID,s.Deduction,e.FirstName + e.LastName as Name, e.Gender,s.salary,s.NetPayable from tblEmployee e inner join tblSalary s on e.ID =s.EmployeeID where MONTH(CAST(date as datetime)) = " + salaryDate.Month + " AND YEAR(CAST(date as datetime)) = " + salaryDate.Year + " AND e.DepartmentID = " + DeptID;
                else
                    cmd = "select e.ID,e.FirstName + e.LastName as Name,e.Gender,e.Salary from tblEmployee e,tblSalary s where e.ID not in (select EmployeeID from tblSalary) AND MONTH(CAST(s.date as datetime)) = " + salaryDate.Month + " AND YEAR(CAST(s.date as datetime)) = " + salaryDate.Year + " AND e.DepartmentID = " + DeptID;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    connection.Open();
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd, connection))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class VehicleRepository
    {
        private DBTransections transection { get; set; }
        public VehicleRepository() { transection = new DBTransections(); }
        public int AddVehicle(VehicleEntity VE)
        {
            try
            {
                if (VE.ID > 0)
                {
                    VehicleEntity FoundVehicle = new VehicleEntity();
                    FoundVehicle = transection.Vehicle.Find(VE.ID);
                    FoundVehicle.VehicleNo = VE.VehicleNo;
                    FoundVehicle.VehicleType = VE.VehicleType;
                    FoundVehicle.NoOfSeats = VE.NoOfSeats;
                    FoundVehicle.Route = VE.Route;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.Vehicle.Where(m => m.VehicleNo.ToLower() == VE.VehicleNo.ToLower()).FirstOrDefault() == null)
                    {
                        transection.Vehicle.Add(VE);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteVehicleByID(string IDs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "Delete from tblVehicle where ID  IN ('" + IDs + "')";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public bool DeleteVehicleAllocation(string StudentIDs,string empIDs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = string.Empty;
                    if (StudentIDs != string.Empty)
                        query += "UPDATE tblStudent set VehicleID = 0,VehicleCharges = 0 where ID IN (" + StudentIDs + ");";

                    if (empIDs != string.Empty)
                        query += " UPDATE tblEmployee set VehicleID = 0,VehicleCharges = 0 where ID IN (" + empIDs + ");";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return false;
            }
        }
        public VehicleEntity GetVehicleByID(int? ID)
        {
            try
            {
                return transection.Vehicle.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<VehicleEntity> GetALLVehicles(bool isGrid = false,bool isNOVehicle = false)
        {
            try
            {
                List<VehicleEntity> List = transection.Vehicle.OrderBy(m => m.VehicleNo).ToList();
                if (!isGrid)
                    List.Insert(0, new VehicleEntity() { VehicleNo = "ALL" });
                if(isNOVehicle)
                    List.Insert(0, new VehicleEntity() { VehicleNo = "Not Assign" });
                return List;                
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public int GetVehicleCapacity(int ID)
        {
            try
            {
                return transection.Vehicle.Where(v=>v.ID == ID).FirstOrDefault().NoOfSeats;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
    }
    public class DriverRepository
    {
        private DBTransections transection { get; set; }
        public DriverRepository() { transection = new DBTransections(); }
        public int AddDriver(DriverEntity DE)
        {
            try
            {
                if (DE.ID > 0)
                {
                    DriverEntity FoundDriver = new DriverEntity();
                    FoundDriver = transection.Driver.Find(DE.ID);
                    FoundDriver.DriverName = DE.DriverName;
                    FoundDriver.VehicleID = DE.VehicleID;
                    FoundDriver.Qualification = DE.Qualification;
                    FoundDriver.Salary = DE.Salary;
                    return transection.SaveChanges();
                }
                else
                {
                    transection.Driver.Add(DE);
                    return transection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteDriverByID(int ID)
        {
            try
            {
                if (transection.Driver.Remove(transection.Driver.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public DriverEntity GetDriverByID(int? ID)
        {
            try
            {
                return transection.Driver.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<DriverEntity> GetALLDrivers()
        {
            try
            {
                return transection.Driver.ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public DriverEntity GetDriverByVehicleID(int vehicleID)
        {
            try
            {
                return transection.Driver.Where(m => m.VehicleID == vehicleID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class DriverSalaryRepository
    {
        private DBTransections transection { get; set; }
        public DriverSalaryRepository() { transection = new DBTransections(); }
        public int AddDriverSalary(DriverSalaryEntity DSE)
        {
            try
            {
                if (DSE.ID > 0)
                {
                    DriverSalaryEntity FoundDriverSalary = new DriverSalaryEntity();
                    FoundDriverSalary = transection.DriverSalary.Find(DSE.ID);
                    FoundDriverSalary.DriverID = DSE.DriverID;
                    FoundDriverSalary.SalaryMonth = DSE.SalaryMonth;
                    FoundDriverSalary.Deduction = DSE.Deduction;
                    FoundDriverSalary.salary = DSE.salary;
                    FoundDriverSalary.NetPayable = DSE.NetPayable;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.DriverSalary.Where(s => s.DriverID == DSE.DriverID && s.SalaryMonth == DSE.SalaryMonth).FirstOrDefault() == null)
                    {
                        transection.DriverSalary.Add(DSE);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteDriverSalaryByID(int ID)
        {
            try
            {
                if (transection.DriverSalary.Remove(transection.DriverSalary.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public DriverSalaryEntity GetDriverSalaryByID(int? ID)
        {
            try
            {
                return transection.DriverSalary.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<DriverSalaryEntity> GetALLDriverSalaries(DateTime salaryDate)
        {
            try
            {
                return transection.DriverSalary.Where(m => m.SalaryMonth.Month == salaryDate.Month && m.SalaryMonth.Year == salaryDate.Year).OrderByDescending(m => m.SalaryMonth).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class ProductCategoryRepository
    {
        private DBTransections transection { get; set; }
        public ProductCategoryRepository() { transection = new DBTransections(); }
        public int AddProductCategory(ProductCategoryEntity PC)
        {
            try
            {
                if (PC.ID > 0)
                {
                    ProductCategoryEntity FoundProductCategory = new ProductCategoryEntity();
                    FoundProductCategory = transection.ProductCategory.Find(PC.ID);
                    FoundProductCategory.ProductCategory = PC.ProductCategory;
                    return transection.SaveChanges();
                }
                else
                {
                    if (transection.ProductCategory.Where(m => m.ProductCategory.ToLower() == PC.ProductCategory.ToLower()).FirstOrDefault() == null)
                    {
                        transection.ProductCategory.Add(PC);
                        return transection.SaveChanges();
                    }
                    else
                        return -2;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteProductCategoryByID(int ID)
        {
            try
            {
                if (transection.ProductCategory.Remove(transection.ProductCategory.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public ProductCategoryEntity GetProductCategoryByID(int? ID)
        {
            try
            {
                return transection.ProductCategory.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<ProductCategoryEntity> GetALLProductCategories(bool isGrid = false)
        {
            try
            {
                List<ProductCategoryEntity> List = transection.ProductCategory.OrderBy(c=>c.ProductCategory).ToList();
                if (!isGrid)
                    List.Insert(0, new ProductCategoryEntity() { ProductCategory = "ALL" });

                return List;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class ProductRepository
    {
        private DBTransections transection { get; set; }
        public ProductRepository() { transection = new DBTransections(); }
        public int AddProduct(ProductEntity P)
        {
            try
            {
                if (P.ID > 0)
                {
                    ProductEntity FoundProduct = new ProductEntity();
                    FoundProduct = transection.Product.Find(P.ID);
                    FoundProduct.ProductCategory = P.ProductCategory;
                    FoundProduct.ProductName = P.ProductName;
                    FoundProduct.UnitPrice = P.UnitPrice;
                    FoundProduct.Quantity = P.Quantity;
                }
                else
                    transection.Product.Add(P);

                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public int DeleteProductByID(int ID)
        {
            try
            {
                if (transection.Product.Remove(transection.Product.Where(m => m.ID == ID).SingleOrDefault()) != null)
                    return transection.SaveChanges();
                else
                    return -3;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public ProductEntity GetProductByID(int? ID)
        {
            try
            {
                return transection.Product.Where(m => m.ID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public List<ProductEntity> GetALLProducts(int CatID)
        {
            try
            {
                if(CatID == 0)
                    return transection.Product.ToList();
                else
                    return transection.Product.Where(m => m.ProductCategory == CatID).ToList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    public class TimeTableRepository
    {
        private DBTransections transection { get; set; }
        public TimeTableRepository() { transection = new DBTransections(); }
        public int SaveTimeTable(TimeTableEntity TTE)
        {
            try
            {
                TimeTableEntity FoundTimeTable = new TimeTableEntity();
                FoundTimeTable = transection.TimeTable.Where(m=>m.ClassID == TTE.ClassID).FirstOrDefault();
                if (FoundTimeTable != null)
                {
                    FoundTimeTable.TimeTableName = TTE.TimeTableName;
                    FoundTimeTable.TimeTable = TTE.TimeTable;
                    FoundTimeTable.LectureTimings = TTE.LectureTimings;
                    FoundTimeTable.ClassID = TTE.ClassID;
                    FoundTimeTable.ClassName = TTE.ClassName;
                }
                else
                    transection.TimeTable.Add(TTE);

                return transection.SaveChanges();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return -1;
            }
        }
        public TimeTableEntity GetTimeTableByClassID(int? ID)
        {
            try
            {
                return transection.TimeTable.Where(m => m.ClassID == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }

    }

    #endregion

    #region Report Repository
    public static class ReportRepository
    {
        public static DataTable GetSchoolInfo()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select SchoolName as Name from tblSchoolInfo";
                    using (SqlCommand cmd = new SqlCommand(query,con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetStudentReportData(int ClassID, string gender, int feesCategory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string condition = string.Empty;
                    if (ClassID != 0)
                        condition += " s.Class = " + ClassID;
                    if (gender != string.Empty)
                        condition += (condition == string.Empty ? "Gender = '" + gender + "'" : " AND Gender = '" + gender + "'");
                    if (feesCategory != 0)
                        condition += (condition == string.Empty ? "s.FeesCatagory = " + feesCategory : " AND s.FeesCatagory = " + feesCategory);

                    if (condition != string.Empty)
                        condition = " Where " + condition;

                    string query = "select ROW_NUMBER() Over (Order by s.FirstName) As SNo,s.FirstName+' '+s.LastName as Name,* from tblStudent s " +
                    "inner join tblClass c on s.Class = c.ID " +
                    "inner join tblFeesCatagory f on s.FeesCatagory = f.ID " +
                    "inner join tblVehicle v on s.VehicleID = v.ID " +
                    condition;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetInventoryReportData(int ProductCategory)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select 0 as grandTotalProducts,0 as grandTotalPrice,0 as grandTotalQuantity, p.ProductName,p.Quantity,p.UnitPrice,pc.ProductCategory from tblProduct p,tblProductCategory pc where p.ProductCategory = pc.ID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                int grandTotalProducts = 0;
                                int grandTotalPrice = 0;
                                int grandTotalQuantity = 0;
                                for (int i = 0; i < dt.Rows.Count;i++)
                                {
                                    grandTotalProducts++;
                                    grandTotalPrice += int.Parse(dt.Rows[i]["Quantity"].ToString()) * int.Parse(dt.Rows[i]["UnitPrice"].ToString());
                                    grandTotalQuantity += int.Parse(dt.Rows[i]["Quantity"].ToString());
                                }
                                foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
                                dt.Select().ToList<DataRow>().ForEach(r => { r["grandTotalProducts"] = grandTotalProducts; r["grandTotalPrice"] = grandTotalPrice; r["grandTotalQuantity"] = grandTotalQuantity; });
                                return dt;
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetEmployeeReportData(int DeptID,string qualification,int EmpType,int expYears)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string condition = string.Empty;
                    if (DeptID != 0)
                        condition += " e.DepartmentID = " + DeptID;
                    if (EmpType != 0)
                        condition += (condition == string.Empty ? " e.EmployeeTypeID = " + EmpType : " AND e.EmployeeTypeID = " + EmpType);
                    if (qualification != string.Empty)
                        condition += (condition == string.Empty ? " e.Qualification = '" + qualification + "'" : " AND e.Qualification = '" + qualification + "'");
                    if (expYears != 0)
                        condition += (condition == string.Empty ? " e.Experiance >= " + expYears * 12 : " AND e.Experiance >= " + expYears * 12);

                    condition = (condition == string.Empty ? "" : " Where " + condition);
                    string query = "select FirstName + ' ' + LastName as Name,Gender,BloodGroup,Address,ContactNo,EmergencyNo,Qualification,Experiance,et.EmployeeType,Salary,d.DepartmentName as Department"
                                    + " from tblEmployee e JOIN tblDepartment d ON e.DepartmentID = d.ID"
                                    + " JOIN tblEmployeeType et ON e.EmployeeTypeID = et.ID" + condition + " order by Name asc";
                                    
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetTransportReportData(int VehicleID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string c1 = string.Empty;
                    string c2 = string.Empty;
                    if (VehicleID != 0)
                    {
                        c1 += "where s.VehicleID = " + VehicleID;
                        c2 += "where e.VehicleID = " + VehicleID;
                    }
                    DataTable dt = new DataTable();
                    string query = "Select s.FirstName +' '+s.LastName as PersonName,v.NoOfSeats,v.VehicleNo+' ('+v.VehicleType+')' as VehicleName,s.VehicleCharges as Charges,'Student' as Type from tblStudent s Inner Join tblVehicle v ON s.VehicleID = v.ID " + c1;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    DataTable temp = dt.Clone();
                    temp.Merge(dt);
                    dt = new DataTable();

                    query = "Select e.FirstName +' '+e.LastName as PersonName,v.NoOfSeats,v.VehicleNo+' ('+v.VehicleType+')' as VehicleName,e.VehicleCharges as Charges,'Employee' as Type from tblEmployee e Inner Join tblVehicle v ON e.VehicleID = v.ID " + c2;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    temp.Merge(dt);
                    return temp;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetRelatedInformation_Attendance(int Type,int ID,int m,int y)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    string present = "Present like '%," + ID + ",%' or Present like '" + ID + ",%' or Present like '%," + ID + "' or Present = '" + ID + "'";
                    string absent = "Absent like '%," + ID + ",%' or Absent like '" + ID + ",%' or Absent like '%," + ID + "' or Absent = '" + ID + "'";
                    string leave = "Leave like '%," + ID + ",%' or Leave like '" + ID + ",%' or Leave like '%," + ID + "' or Leave = '" + ID + "'";

                    string query = "Select (select COUNT(*) from tblAttendance where MONTH(Date) = " + m + " AND YEAR(Date) = " + y + " AND (" + present + ") AND Type = " + Type + ") as present,"
                                    + "(select COUNT(*) from tblAttendance where MONTH(Date) = " + m + " AND YEAR(Date) = " + y + " AND (" + absent + ") AND Type = " + Type + ") as absent,"
                                    + "(select COUNT(*) from tblAttendance where MONTH(Date) = " + m + " AND YEAR(Date) = " + y + " AND (" + leave + ") AND Type = " + Type + ") as leave";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetRelatedInformation_Vehicle(string Type, int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    string query = "select v.VehicleNo,v.VehicleType,av.Charges from tblAvailVehicle av Join tblVehicle v ON v.ID = av.VehicleID where av.StudID_EmpID = "+ID+" AND av.Type = '" + Type +"'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataSet GetPLSReportData(DateTime date)
        {
            try
            {
                DataSet plsDS = new DataSet();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();

                    #region dtPLS
                    
                    DataTable dt = new DataTable();
                    string query = "select SUM(Fees) as Fees,SUM(Fine) as Fine from tblFeesCollection where MONTH(Date) = " + date.Month + " AND YEAR(Date) = " + date.Year ;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    dt.TableName = "PL1";
                    plsDS.Tables.Add(dt);

                    dt = new DataTable();
                    query = "select SUM(NetPayable) as EmployeeSalary from tblSalary where MONTH(date) = " + date.Month + " AND YEAR(date) = " + date.Year;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    dt.TableName = "PL2";
                    plsDS.Tables.Add(dt);

                    dt = new DataTable();
                    query = "select SUM(NetPayable) as DriverSalary from tblDriverSalary where MONTH(SalaryMonth) = " + date.Month + " AND YEAR(SalaryMonth) = " + date.Year;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    dt.TableName = "PL3";
                    plsDS.Tables.Add(dt);

                    dt = new DataTable();
                    query = "select BuildingRent,ElectricityBill,GasBill,Misc,Description from tblExpenses where MONTH(BillingMonth) = " + date.Month + " AND YEAR(BillingMonth) = " + date.Year;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    dt.TableName = "PL4";
                    plsDS.Tables.Add(dt);

                    dt = new DataTable();
                    query = "select Vehicle,VehicleExpense,Description,convert(varchar, BillingMonth, 107) as BillingMonth from tblExpenses where MONTH(BillingMonth) = " + date.Month + " AND YEAR(BillingMonth) = " + date.Year;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                    dt.TableName = "dtExpenseVehicle";
                    plsDS.Tables.Add(dt);

                    #endregion
                }
                return plsDS;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    #endregion

    #region GRID Repository
    public static class GridRepository
    {
        public static DataTable GetData_Student(int ClassID,string gender,int feesCategory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string condition = string.Empty;
                    if (ClassID != 0)
                        condition += " s.Class = " + ClassID;
                    if (gender != string.Empty)
                        condition += (condition == string.Empty ? "Gender = '" + gender + "'" : " AND Gender = '" + gender + "'");
                    if (feesCategory != 0)
                        condition += (condition == string.Empty ? "s.FeesCatagory = " + feesCategory : " AND s.FeesCatagory = " + feesCategory);

                    if (condition != string.Empty)
                        condition = " Where " + condition;

                    string query = "select s.FirstName+' '+s.LastName as Name,* from tblStudent s " +
                    "inner join tblClass c on s.Class = c.ID " +
                    "inner join tblFeesCatagory f on s.FeesCatagory = f.ID " +
                    "left join tblVehicle v on s.VehicleID = v.ID " +
                    condition;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_Salary(DateTime date, int deptID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string deptCheck = (deptID == 0 ? "" : " AND s.DepartmentID = " + deptID);
                    string query = "select s.ID,s.DepartmentID,s.EmployeeID,e.FirstName +' '+e.LastName as Name,d.DepartmentName as Department,s.date,s.salary,s.Deduction,s.NetPayable from tblSalary s JOIN tblEmployee e ON s.EmployeeID = e.ID JOIN tblDepartment d on d.ID = s.DepartmentID"
                        + " where MONTH(s.date) = " + date.Month + " AND YEAR(s.date) = " + date.Year + deptCheck + "  order by Name asc";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_Employee(int deptID,int EmpID,string qualification,int exp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string condition = string.Empty;
                    if (deptID != 0)
                        condition += " e.DepartmentID = " + deptID;
                    if (EmpID != 0)
                        condition += (condition == string.Empty ? " e.EmployeeTypeID = " + EmpID : " AND e.EmployeeTypeID = " + EmpID);
                    if (qualification != string.Empty)
                        condition += (condition == string.Empty ? " e.Qualification = '" + qualification + "'" : " AND e.Qualification = '" + qualification + "'");
                    if (exp != 0)
                        condition += (condition == string.Empty ? " e.Experiance >= " + exp * 12 : " AND e.Experiance >= " + exp * 12);

                    condition = (condition == string.Empty ? "" : " Where " + condition);
                    string query = "select e.FirstName+' '+e.LastName as Name,* from tblEmployee e " +
                           "inner join tblDepartment d on e.DepartmentID = d.ID "+
                            "inner join tblEmployeeType et on e.EmployeeTypeID = et.ID "+
                            "left join tblVehicle v on e.VehicleID = v.ID "+ condition + " order by FirstName asc";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_Driver()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select d.ID,d.DriverName,v.VehicleNo,d.VehicleID,d.Salary,d.Qualification from tblDriver d JOIN tblVehicle v ON d.VehicleID = v.ID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_DriverSalary(DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = "select ds.ID,ds.DriverID,ds.SalaryMonth,d.DriverName,ds.Deduction,ds.Salary,ds.NetPayable from tblDriverSalary ds JOIN tblDriver d ON ds.DriverID = d.ID where MONTH(ds.SalaryMonth) = " + date.Month + " AND YEAR(ds.SalaryMonth) = " + date.Year + " order by d.DriverName asc";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_AvailTransport(int vehID,string Type)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string query = string.Empty;
                    if(Type == "Student")
                        query = "select v.ID,v.StudID_EmpID,s.FirstName +' '+s.LastName as Name,v.VehicleID,v.Charges,v.Class_Dept,v.Type from tblAvailVehicle v JOIN tblStudent s ON v.StudID_EmpID = s.ID where v.VehicleID = "+vehID+" AND v.Type = '"+Type+"' Order by s.FirstName asc";
                    else
                        query = "select v.ID,v.StudID_EmpID,e.FirstName +' '+e.LastName as Name,v.VehicleID,v.Charges,v.Class_Dept,v.Type from tblAvailVehicle v JOIN tblEmployee e ON v.StudID_EmpID = e.ID where v.VehicleID = " + vehID + " AND v.Type = '" + Type + "' Order by e.FirstName asc";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
        public static DataTable GetData_FeesCollection(int classID,DateTime date)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString()))
                {
                    con.Open();
                    string condition = string.Empty;
                    if (classID != 0)
                        condition += " AND f.ClassID = " + classID;
                    string query = string.Empty;
                    query = "select f.ID,f.StudentID,f.ClassID,s.FirstName +' '+s.LastName as Name,f.Fine,f.Fees from tblFeesCollection f Join tblStudent s on f.StudentID = s.ID where Month(f.Date) = " + date.Month + " and YEAR(f.Date) = " + date.Year + condition + " Order by s.FirstName asc";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return null;
            }
        }
    }
    #endregion

    #region Software Maintainance Repository

    public static class SoftwareMaintainance
    {
        public static bool CreateDBBackup()
        {
            try
            {
                var fileName = System.Windows.Forms.Application.StartupPath + "Data\\SMS_bk_" + DateTime.Now.ToString("MMMM yyyy") + ".bak";
                var sqlConStrBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConStr"].ToString());

                using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    var query = "BACKUP DATABASE SMS TO DISK='"+fileName+"'";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                return false;
            }
        }       
    }

    #endregion
}
