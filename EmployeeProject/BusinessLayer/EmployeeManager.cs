using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeManager
    {

        Repository<Employee> emprepo = new Repository<Employee>();
        public List<Employee> GetAll()
        {
            return emprepo.List();
        }
        public int EmployeeBlAdd(Employee e)
        {
            return emprepo.Insert(e);
        }
        public int EmployeeBlDelete(int e)
        {
            Employee emp = emprepo.Find(x => x.EmployeeId == e);
            return emprepo.Delete(emp);
        }
        public int EmployeeBlUpdate(Employee e)
        {
            Employee employee = emprepo.Find(x => x.EmployeeId == e.EmployeeId);
            employee.EmployeeName = e.EmployeeName;
            employee.EmployeeAge = e.EmployeeAge;
            employee.isActive = e.isActive;
            employee.DepartmentId = e.DepartmentId;
            return emprepo.Update(employee);
        }
    }
}
