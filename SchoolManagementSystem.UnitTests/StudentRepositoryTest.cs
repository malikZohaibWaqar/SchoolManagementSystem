using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Data.Entity;

namespace SchoolManagementSystem.UnitTests
{
    [TestFixture]
    public class StudentRepositoryTest
    {
        [Test]
        public void EnrollAndUpdateStudent_successfulEnroll_shouldReturnGreaterThanMinusOne()
        {
            // Arrange
            var studentEntity = new StudentEntity  //create an object of Student Entity to pass in EnrollAndUpdate Function of StudentRepository
            {
                RollNo = "1000",
                FirstName = "FirstName",
                LastName = "LastName",
                DOB = System.DateTime.Parse("10/06/2024 12:00:00 am"),
                Gender = "Male",
                BloodGroup = "B+",
                Religion = "Religion",
                Address = "Address",
                ContactNo = "123456789",
                EmergencyNo = "123456789",
                FatherName = "FatherName",
                FatherContact = "123456789",
                MotherName = "MotherName",
                GuardianName = "GuardianName",
                RelationWithGuardian = "RelationWithGuardian",
                Class = 1,
                FeesCatagory = 1,
                VehicleID = 1,
                VehicleCharges = 2000,
                isPassOut = false,
                ImageName = "ImageName"
            };
            var studentsData = new List<StudentEntity>().AsQueryable(); // Create a list that will tell Mock setup about the records in EF. As we are testing new record so this should be empty 
           
            var mockSet = new Mock<DbSet<StudentEntity>>();
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.Provider).Returns(studentsData.Provider);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.Expression).Returns(studentsData.Expression);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.ElementType).Returns(studentsData.ElementType);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.GetEnumerator()).Returns(studentsData.GetEnumerator());

            var mockContext = new Mock<DBTransections>();
            mockContext.Setup(c => c.Student).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);

            // Act
            var result = repository.EnrollAndUpdateStudent(studentEntity);

            // Assert
            Assert.That(result, Is.GreaterThan(-1)); // Expecting 1 as SaveChanges() returns the number of objects written to the underlying database.
        }
         [Test]
        public void EnrollAndUpdateStudent_ExistingCheck_shouldReturnMinusTwo()
        {
            // Arrange
            var studentEntity = new StudentEntity  //create an object of Student Entity to pass in EnrollAndUpdate Function of StudentRepository
            {
                RollNo = "1000",
                FirstName = "FirstName",
                LastName = "LastName",
                DOB = System.DateTime.Parse("10/06/2024 12:00:00 am"),
                Gender = "Male",
                BloodGroup = "B+",
                Religion = "Religion",
                Address = "Address",
                ContactNo = "123456789",
                EmergencyNo = "123456789",
                FatherName = "FatherName",
                FatherContact = "123456789",
                MotherName = "MotherName",
                GuardianName = "GuardianName",
                RelationWithGuardian = "RelationWithGuardian",
                Class = 1,
                FeesCatagory = 1,
                VehicleID = 1,
                VehicleCharges = 2000,
                isPassOut = false,
                ImageName = "ImageName"
            };

            var studentsData = new List<StudentEntity> { studentEntity }.AsQueryable(); // This shows that database already have record that we need to add in database

            var mockSet = new Mock<DbSet<StudentEntity>>();
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.Provider).Returns(studentsData.Provider);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.Expression).Returns(studentsData.Expression);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.ElementType).Returns(studentsData.ElementType);
            mockSet.As<IQueryable<StudentEntity>>().Setup(m => m.GetEnumerator()).Returns(studentsData.GetEnumerator());

            var mockContext = new Mock<DBTransections>();
            mockContext.Setup(c => c.Student).Returns(mockSet.Object);

            var repository = new StudentRepository(mockContext.Object);

            // Act
            var result = repository.EnrollAndUpdateStudent(studentEntity);

            // Assert
            Assert.That(result, Is.EqualTo(-2)); // Expecting 1 as SaveChanges() returns the number of objects written to the underlying database.
        }
    }
}
