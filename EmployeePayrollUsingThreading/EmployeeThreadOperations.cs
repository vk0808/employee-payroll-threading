using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollUsingThreading
{
    public class EmployeeThreadOperations
    {
        static PerformanceCounter myCounter;

        // Object instantiation
        EmployeeRepo repo = new EmployeeRepo();

        // Method to return Employee data model
        public EmployeeModel EmployeeData()
        {
            EmployeeModel employee = new EmployeeModel();
            //Add record
            employee.Name = "Sukumar";
            employee.Department = "FullStack";
            employee.PhoneNumber = "1234567890";
            employee.Address = "13-Andhra Pradesh";
            employee.Gender = 'M';
            employee.BasicPay = 10000.00M;
            employee.Deduction = 1500.00M;
            employee.Start = Convert.ToDateTime("2021-09-14");
            return employee;
        }

        // Method to add employee without threading
        public void AddEmployeeToPayroll_WithoutThread()
        {
            Console.WriteLine("Employee is being added");
            EmployeeModel employee = EmployeeData();
            employee.Name = "Alex";
            if (repo.AddEmployee(employee))
            {
                Console.WriteLine("Employee is added");
            }
            else
            {
                Console.WriteLine("Employee is not added");
            }
        }

        // Method to add employee with threading
        public void AddEmployeeToPayroll_WithThread()
        {

            if (!PerformanceCounterCategory.Exists("Processor"))
            {
                Console.WriteLine("Object Processor does not exist!");
                return;
            }
            if (!PerformanceCounterCategory.CounterExists(@"% Processor Time", "Thread"))
            {
                Console.WriteLine(@"Counter % Processor Time does not exist!");
                return;
            }

            myCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
            Console.WriteLine(@"Before inserting, %Processor Time, _Total= " + myCounter.NextValue().ToString());
            Task thread = new Task(() =>
            {
                Console.WriteLine("Employee is being added");
                EmployeeModel employee = EmployeeData();
                employee.Name = "Smith";
                if (repo.AddEmployee(employee))
                {
                    Console.WriteLine("Employee is added");
                }
                else
                {
                    Console.WriteLine("Employee is not added");
                }
            });
            thread.Start();
            Thread.Sleep(1000);
            Console.WriteLine(@"Current value of Processor, %Processor Time, _Total= " + myCounter.NextValue().ToString());
        }
    }
}
