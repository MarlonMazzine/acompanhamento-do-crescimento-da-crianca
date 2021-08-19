using System.Linq;

namespace WebApplication.TCC.Context.Datas
{
    public class BaseRepository<T>: IRepository<T> where T: class
    {
        private readonly TccContext _context;

        public BaseRepository(TccContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll => _context.Set<T>().AsQueryable();

        public void Update(params T[] obj)
        {
            _context.Set<T>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Delete(params T[] obj)
        {
            _context.Set<T>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public T Find(string key)
        {
            return _context.Find<T>(key);
        }

        public void Insert(params T[] obj)
        {
            _context.Set<T>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
