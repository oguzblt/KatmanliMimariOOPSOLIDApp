using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _objects;
        public Repository()
        {
            _objects = context.Set<T>();
        }
        public int Delete(T p)
        {
            _objects.Remove(p);
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objects.FirstOrDefault(where);
        }

        public T GetById(int id)
        {
            return _objects.Find(id);
        }

        public int Insert(T p)
        {
            _objects.Add(p);
            return context.SaveChanges();
        }

        public List<T> List()
        {
            return _objects.ToList();
        }

        public int Update(T p)
        {
            return context.SaveChanges();
        }
    }
}
