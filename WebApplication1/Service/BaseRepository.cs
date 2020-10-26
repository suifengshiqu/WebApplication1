using FastCoding.Framework.Injections;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BaseRepository : FastCoding.Framework.Repositoties.BaseRepository<TestDbContext>, ISelfInjection
    {
    }
}
