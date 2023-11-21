using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    
    }
    //For testing only 
    public AppDbContext() { }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnStr.Get());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    public class ConnStr
    {
        public static string Get()
        {
            String url = Environment.GetEnvironmentVariable("ConnectionString");

            var uriString = url;
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }
    }
    
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Warehouse> WarehouseTable { get; set; }
    }