using System.Linq;

namespace GigueService.Controllers
{
    public interface IRepo
    {
        IQueryable<T> Query<T>() where T : class;
    }
}