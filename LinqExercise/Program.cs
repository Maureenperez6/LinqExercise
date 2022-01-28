using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            // Print the Sum and Average of numbers

            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");
            Console.WriteLine($"Average of numbers: {numbers.Average()}\n");
            //var sum = numbers.Sum();
            // Console.WriteLine(sum);
            //var avg = numbers.Average();
            //Console.WriteLine(avg);

            //////////Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending Order");
            Console.WriteLine();
            var aOrder = numbers.OrderBy(item => item);
            foreach (var a in aOrder)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();
            Console.WriteLine("Descending Order");
            Console.WriteLine();
            var dOrder = numbers.OrderByDescending(x => x > 0);
            foreach (var x in dOrder)
            {
                Console.WriteLine(x);
            }




            //////Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6");
            Console.WriteLine();
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var s in greaterThanSix)
            {
                Console.WriteLine(s);
            }



            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Only 4");
            Console.WriteLine();
            var orderD = numbers.OrderByDescending(x => x > 0);
            //Enumerable.Range(1, 4).ToList().ForEach(Console.WriteLine);

            foreach (var num in orderD.Take(4))
            {
                Console.WriteLine(num);
            }



            //Change the value at index 4 to your age, then print the numbers in decsending order
           
            numbers.SetValue(27, 4);

            Console.WriteLine("Index 4 changed");
            var numberDes = numbers.OrderByDescending(num_d => num_d);
            foreach (var num_d in numberDes)
            {
                Console.WriteLine(num_d);
            }


            // List of employees ***Do not remove this***


            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var list = employees.Where(employee => employee.FirstName.ToLower()[0] == 'c'
            || employee.FirstName.ToLower()[0] == 's');
            Console.WriteLine();
            Console.WriteLine("Employees C or S");
            foreach ( var employee in list.OrderBy(x => x.FirstName))
            {
                Console.WriteLine(employee.FullName);
            }

            //LINQ way:
            //employees.Where(employee => employee.FirstName.ToLower().StartsWith('c')
            //|| employee.FirstName.ToLower()[0] == 's')




            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age)
                .ThenBy(x => x.FirstName);

            Console.WriteLine();
            Console.WriteLine("Over 26");
            foreach ( var employee in twentySix)
            {
                Console.WriteLine($"Name: {employee.FullName}, Age: {employee.Age}");
            }




            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine();
            var YOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Sum of YOE: {YOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average of YOE: {YOE.Average(x => x.YearsOfExperience)}");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Maureen", "Perez", 27, 10)).ToList();

            Console.WriteLine();
            Console.WriteLine("Added a new employee");
            foreach ( var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
