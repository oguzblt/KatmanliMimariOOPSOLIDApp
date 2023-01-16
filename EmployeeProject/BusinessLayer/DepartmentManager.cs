using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DepartmentManager
    {
        Repository<Department> departrepo = new Repository<Department>();   
        public List<Department> GetAll()
        {
            return departrepo.List();
        }
        public int DepartmentBlAdd(Department d)
        {
            return departrepo.Insert(d);
        }
        public int DepartmentBlDelete(int d)
        {
                Department depart = departrepo.Find(x => x.DepartmentId == d);
                return departrepo.Delete(depart);
        }
        public int DepartmentBlUpdate(Department d)
        {
            Department department = departrepo.Find(x => x.DepartmentId == d.DepartmentId);
            department.DepartmentName = d.DepartmentName;
            return departrepo.Update(department);
        }
    }
}
