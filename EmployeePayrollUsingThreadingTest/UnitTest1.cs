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
        }
    }
}
