using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
            : base()
        {
            OnCreated();
        }
        public TestDbContext(DbContextOptions<TestDbContext> options) :
            base(options)
        {
            OnCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Demo;Integrated Security=True;Persist Security Info=True");
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }
        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);
        partial void OnCreated();
    }
}
