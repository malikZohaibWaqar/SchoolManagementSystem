using DAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.UnitTests
{
    [TestFixture]
    public class HRRepositoryTest
    {
        [Test]
        public void EnrollAndUpdateEmployee_SuccessfulEnroll_ReturnValueGreaterThanMinusOne()
        {
            //Arrange
            var HREntity = new EmployeeEntity()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DOB = DateTime.Parse("10/06/2024 12:00:00 am"),
                Gender = "Male",
                BloodGroup = "B+",
                Religion = "Islam",
                Address = "Address",
                ContactNo = "123456789",
                EmergencyNo = "123456789",
                Qualification = "Graduate",
                Experiance = 5,
                DepartmentID = 1,
                EmployeeTypeID = 1,
                Salary = 5000,
                VehicleID = 1,
                VehicleCharges = 2000,
                ImageName = "ImageName",
            };
            var HRData = new List<EmployeeEntity>().AsQueryable(); // Database , EF DB Context
            var mockSet = new Mock<DbSet<EmployeeEntity>>();
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.GetEnumerator()).Returns(HRData.GetEnumerator());
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.Expression).Returns(HRData.Expression);
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.ElementType).Returns(HRData.ElementType);
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.Provider).Returns(HRData.Provider);

            var mockContext = new Mock<DBTransections>();
            mockContext.Setup(c => c.Employee).Returns(mockSet.Object);
            var repository = new EmployeeRepository(mockContext.Object);

            //Act

            int result = repository.EnrollAndUpdateEmployee(HREntity);

            //Assert

            Assert.That(result, Is.GreaterThan(-1));
        }
        [Test]
        public void EnrollAndUpdateEmployee_DuplicateEnroll_ShouldReturnValueMinusTwo()
        {
            //Arrange
            var HREntity = new EmployeeEntity()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                DOB = DateTime.Parse("10/06/2024 12:00:00 am"),
                Gender = "Male",
                BloodGroup = "B+",
                Religion = "Islam",
                Address = "Address",
                ContactNo = "123456789",
                EmergencyNo = "123456789",
                Qualification = "Graduate",
                Experiance = 5,
                DepartmentID = 1,
                EmployeeTypeID = 1,
                Salary = 5000,
                VehicleID = 1,
                VehicleCharges = 2000,
                ImageName = "ImageName",
            };
            var HRData = new List<EmployeeEntity>() { HREntity }.AsQueryable(); // Database , EF DB Context
            var mockSet = new Mock<DbSet<EmployeeEntity>>();
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.GetEnumerator()).Returns(HRData.GetEnumerator());
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.Expression).Returns(HRData.Expression);
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.ElementType).Returns(HRData.ElementType);
            mockSet.As<IQueryable<EmployeeEntity>>().Setup(m => m.Provider).Returns(HRData.Provider);

            var mockContext = new Mock<DBTransections>();
            mockContext.Setup(c => c.Employee).Returns(mockSet.Object);
            var repository = new EmployeeRepository(mockContext.Object);

            //Act

            int result = repository.EnrollAndUpdateEmployee(HREntity);

            //Assert

            Assert.That(result, Is.EqualTo(-2));
        }
    }
}
