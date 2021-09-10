using EmployeePayrollUsingThreading;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollUsingThreadingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckThreading_WhenAddingEmployeeToPayroll()
        {
            EmployeeThreadOperations employeePayrollOperations = new EmployeeThreadOperations();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll_WithoutThread();
            DateTime stopDateTime = DateTime.Now;
            TimeSpan v1 = (stopDateTime - startDateTime);
            Console.WriteLine("Duration without thread: " + v1);

            DateTime startDateTimeThread = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll_WithThread();
            DateTime stopDateTimeThread = DateTime.Now;
            TimeSpan v2 = (stopDateTimeThread - startDateTimeThread);
            Console.WriteLine("Duration with thread: " + v2);

            Assert.AreNotEqual(v1, v2);
        }
    }
}
