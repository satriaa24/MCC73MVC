using MCC73MVC.Context;
using MCC73MVC.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories
{
    public class GeneralRepository<entity, T> : IRepositories<entity, T> where entity : class
    {
        private MyContext _context;

        public GeneralRepository(MyContext context)
        {
            _context = context;
        }

        public int Delete(T id)
        {
            var data = _context.Set<entity>().Find(id);           
            if (data == null)
            {
                return 0;
            }
            _context.Set<entity>().Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public IEnumerable<entity> Get()
        {
            return _context.Set<entity>().ToList();
        }

        public entity Get(T Key)
        {
            return _context.Set<entity>().Find(Key);
        }

        public int Insert(entity entity)
        {
            _context.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Update(entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}