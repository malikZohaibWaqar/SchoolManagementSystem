using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_SMS
{

    public static class FormTester
    {
        public static void TestForms(params Func<Form>[] formFactories)
        {
            foreach (var formFactory in formFactories)
            {
                // Create an instance of the form
                var form = formFactory();

                // Simulate user input
                // (Code to set values for text boxes, radio buttons, etc.)

                // Simulate button click to submit the form
                // (Code to trigger the form submission)

                // Verify that data is loaded and displayed correctly in the grid
                // (Code to compare the count of rows in the grid with the count of data retrieved from the database)
            }
        }
    }


    [TestFixture]
    public class AllFormsTests
    {
        [Test]
        public void TestAllForms()
        {
            // Test MyForm
            FormTester.TestForms(() => new MyForm());

            // Test AnotherForm
            FormTester.TestForms(() => new AnotherForm());
        }
    }
}
