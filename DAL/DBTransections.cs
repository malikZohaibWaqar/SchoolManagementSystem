using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    class DBTransections : DbContext
    {
        public DBTransections() : 
            base("name=ConStr"){}
        
        public virtual DbSet<SchoolInfoEntity> SchoolInfo { get; set; }
        public virtual DbSet<ExpensesEntity> Expenses { get; set; }
        public virtual DbSet<SignInEntity> SignIn { get; set; }
        public virtual DbSet<AccessControlEntity> AccessControl { get; set; }
        public virtual DbSet<ErrorLogger> ErrorLogger { get; set; }
        public virtual DbSet<StudentEntity> Student { get; set; }
        public virtual DbSet<ClassEntity> Class { get; set; }
        public virtual DbSet<FeesCatagoryEntity> FeesCatagory { get; set; }
        public virtual DbSet<FeesCollectionEntity> FeesCollection { get; set; }
        public virtual DbSet<EmployeeEntity> Employee { get; set; }
        public virtual DbSet<EmployeeTypeEntity> EmployeeType { get; set; }
        public virtual DbSet<DepartmentEntity> Department { get; set; }
        public virtual DbSet<SalaryEntity> Salary { get; set; }
        public virtual DbSet<VehicleEntity> Vehicle { get; set; }
        public virtual DbSet<DriverEntity> Driver { get; set; }
        public virtual DbSet<DriverSalaryEntity> DriverSalary { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategory { get; set; }
        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<TimeTableEntity> TimeTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<SchoolInfoEntity>().ToTable("tblSchoolInfo");
                modelBuilder.Entity<ExpensesEntity>().ToTable("tblExpenses");
                modelBuilder.Entity<AccessControlEntity>().ToTable("tblAccessControl");
                modelBuilder.Entity<SignInEntity>().ToTable("tblSignIn");
                modelBuilder.Entity<ErrorLogger>().ToTable("tblError");
                modelBuilder.Entity<StudentEntity>().ToTable("tblStudent");
                modelBuilder.Entity<ClassEntity>().ToTable("tblClass");
                modelBuilder.Entity<FeesCatagoryEntity>().ToTable("tblFeesCatagory");
                modelBuilder.Entity<FeesCollectionEntity>().ToTable("tblFeesCollection");
                modelBuilder.Entity<EmployeeEntity>().ToTable("tblEmployee");
                modelBuilder.Entity<EmployeeTypeEntity>().ToTable("tblEmployeeType");
                modelBuilder.Entity<DepartmentEntity>().ToTable("tblDepartment");
                modelBuilder.Entity<SalaryEntity>().ToTable("tblSalary");
                modelBuilder.Entity<VehicleEntity>().ToTable("tblVehicle");
                modelBuilder.Entity<DriverEntity>().ToTable("tblDriver");
                modelBuilder.Entity<DriverSalaryEntity>().ToTable("tblDriverSalary");
                modelBuilder.Entity<ProductCategoryEntity>().ToTable("tblProductCategory");
                modelBuilder.Entity<ProductEntity>().ToTable("tblProduct");
                modelBuilder.Entity<TimeTableEntity>().ToTable("tblTimeTable");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
            }
        }
    }
}
