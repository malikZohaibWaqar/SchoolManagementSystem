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
    public class ExpensesRepositoryTest
    {
        [Test]
        public void AddExpenses_SuccessfulAdd_ShouldReturnValueGreaterThanMinusOne()
        {
            //Arrange 

            var _ExpensesEntity = new ExpensesEntity()
            {
                BuildingRent = 2000,
                ElectricityBill = 2000,
                GasBill = 2000,
                VehicleExpense = 2000,
                Misc = 2000,
                Description = "This is Description",
                Vehicle = 2,
                BillingMonth = DateTime.Parse("1/1/2020 10:20 AM")
            };
            var _expenseData = new List<ExpensesEntity>().AsQueryable();

            var mockSet = new Mock<DbSet<ExpensesEntity>>();
            mockSet.As<IQueryable<ExpensesEntity>>().Setup(m => m.GetEnumerator()).Returns(_expenseData.GetEnumerator());
            mockSet.As<IQueryable<ExpensesEntity>>().Setup(m => m.ElementType).Returns(_expenseData.ElementType);
            mockSet.As<IQueryable<ExpensesEntity>>().Setup(m => m.Expression).Returns(_expenseData.Expression);
            mockSet.As<IQueryable<ExpensesEntity>>().Setup(m => m.Provider).Returns(_expenseData.Provider);

            var mockContext = new Mock<DBTransections>();
            mockContext.Setup(s => s.Expenses).Returns(mockSet.Object);

            var repository = new ExpensesRepository(mockContext.Object);

            //Act
            int result = repository.AddExpenses(_ExpensesEntity);

            //Assert
            Assert.That(result, Is.GreaterThan(-1));
        }

    }
}
