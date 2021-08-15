using System.Linq;

namespace WebApplication.TCC.Context.Datas
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll { get; }
        T Find(int key);
        void Insert(params T[] obj);
        void Update(params T[] obj);
        void Delete(params T[] obj);
    }
}
