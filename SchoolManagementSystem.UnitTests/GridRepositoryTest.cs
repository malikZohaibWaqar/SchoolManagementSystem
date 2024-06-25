using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.UnitTests
{
    [TestFixture]
    public class GridRepositoryTest
    {
        [Test]
        public void GetData_Student_ShoudReturnDataTable()
        {
            //Arrange 
            int classID = 0, feesCategory = 0; string gender = "male";

            //Act
            DataTable result = GridRepository.GetData_Student(classID, gender, feesCategory);

            //Act
            Assert.That(result != null);
        }

        [Test]
        public void GetData_Salary_ShoudReturnDataTable()
        {
            //Arrange 
            DateTime date = DateTime.Now;
            int deptID = 0;
            
            DataTable _expectedDataTable = new DataTable();
            _expectedDataTable.Columns.Add("ID", typeof(int));
            _expectedDataTable.Columns.Add("DepartmentID", typeof(int));
            _expectedDataTable.Columns.Add("EmployeeID", typeof(int));
            _expectedDataTable.Columns.Add("Name", typeof(string));
            _expectedDataTable.Columns.Add("Department", typeof(string));
            _expectedDataTable.Columns.Add("date", typeof(DateTime));
            _expectedDataTable.Columns.Add("salary", typeof(int));
            _expectedDataTable.Columns.Add("Deduction", typeof(int));
            _expectedDataTable.Columns.Add("NetPayable", typeof(int));


            //Act
            DataTable _actualDataTable = GridRepository.GetData_Salary(date, deptID);

            //Act
            Assert.That(_actualDataTable != null);
            Assert.That(_expectedDataTable.Columns.Count == _actualDataTable.Columns.Count);

        }
    }
}
