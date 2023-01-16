using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Main Menu \n");
                Console.WriteLine("Department       [1]");
                Console.WriteLine("Employee         [2]\n");
                Console.WriteLine("--------------------");
                Console.WriteLine("Exit             [0]");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        CrudMenu(choice);
                        break;
                    case 2:
                        CrudMenu(choice);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static void CrudMenu(int x)
        {
            Department department = new Department();
            Employee employee = new Employee();
            DepartmentManager dm = new DepartmentManager();
            EmployeeManager em = new EmployeeManager();
            DepartmentValidator dv = new DepartmentValidator();
            EmployeeValidator ev = new EmployeeValidator();
            Console.WriteLine("List       [1]");
            Console.WriteLine("Add        [2]");
            Console.WriteLine("Delete     [3]");
            Console.WriteLine("Update     [4]\n\n");
            Console.Write("Choice: ");
            int crudChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (crudChoice)
            {
                case 1:
                    if (x == 1)
                    {
                        foreach (var item in dm.GetAll())
                        {
                            Console.WriteLine("ID: "+item.DepartmentId+" - "+"Department Name: "+item.DepartmentName);
                        }
                    }
                    else if (x == 2)
                    {
                        foreach (var item in em.GetAll())
                        {
                            Console.WriteLine("ID: " + item.EmployeeId + " - " + "Employee Name: " + item.EmployeeName + " - "+ "Employee Age: " + item.EmployeeAge + " - " + "is Active: " + item.isActive+" - "+"Department: "
                                +dm.GetAll().FirstOrDefault(z => z.DepartmentId == item.DepartmentId).DepartmentName);
                        }
                    }
                    break;
                case 2:
                    if (x == 1)
                    {
                        Console.WriteLine("Department Name: ");
                        department.DepartmentName = Console.ReadLine();
                        ValidationResult result = dv.Validate(department);
                        if (result.IsValid)
                        {
                            dm.DepartmentBlAdd(department);
                            Console.WriteLine("Department added successfully.");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                Console.WriteLine(item.ErrorMessage);
                            }
                        }
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("Employee Name: ");
                        employee.EmployeeName = Console.ReadLine();
                        Console.WriteLine("Employee Age");
                        employee.EmployeeAge = int.Parse(Console.ReadLine());
                        Console.WriteLine("Employee is Active");
                        employee.isActive = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Employee Department ID: ");
                        employee.DepartmentId = int.Parse(Console.ReadLine()); 
                        ValidationResult result = ev.Validate(employee);
                        if (result.IsValid)
                        {
                            em.EmployeeBlAdd(employee);
                            Console.WriteLine("Employee added successfully.");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                Console.WriteLine(item.ErrorMessage);
                            }
                        }
                    }
                    break;
                case 3:
                    if (x == 1)
                    {
                        Console.WriteLine("Department ID: ");
                        int del = int.Parse(Console.ReadLine());
                        dm.DepartmentBlDelete(del);
                        Console.WriteLine("Depatment deleted successfully.");
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("Employee ID: ");
                        int del = int.Parse(Console.ReadLine());
                        em.EmployeeBlDelete(del);
                        Console.WriteLine("Employee deleted successfully.");
                    }
                    break;
                case 4:
                    if (x == 1)
                    {
                        Console.WriteLine("Department ID: ");
                        department.DepartmentId = int.Parse(Console.ReadLine());
                        Console.WriteLine("New Department Name: ");
                        department.DepartmentName = Console.ReadLine();
                        ValidationResult result = dv.Validate(department);
                        if (result.IsValid)
                        {
                            dm.DepartmentBlUpdate(department);
                            Console.WriteLine("Department updated successfully.");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                Console.WriteLine(item.ErrorMessage);
                            }
                        }   
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("Employee ID: ");
                        employee.EmployeeId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Employee Name: ");
                        employee.EmployeeName = Console.ReadLine();
                        Console.WriteLine("Employee Age");
                        employee.EmployeeAge = int.Parse(Console.ReadLine());
                        Console.WriteLine("Employee is Active");
                        employee.isActive = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Employee Department ID: ");
                        employee.DepartmentId = int.Parse(Console.ReadLine());
                        ValidationResult result = ev.Validate(employee);
                        if (result.IsValid)
                        {
                            em.EmployeeBlUpdate(employee);
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                Console.WriteLine(item.ErrorMessage);
                            }
                        } 
                    }
                    break;
            }
        }
    }
}