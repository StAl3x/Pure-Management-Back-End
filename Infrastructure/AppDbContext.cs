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
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Company)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.Company.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Warehouse>()
            .Property(w => w.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Warehouse>()
            .HasOne(w => w.Company)
            .WithMany(c => c.Warehouses)
            .HasForeignKey(w => w.CompanyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        

        modelBuilder.Entity<Company>()
            .Property (c => c.Id)
            .ValueGeneratedOnAdd(); 

    }

    public class ConnStr
    {
        public static string Get()
        {
            var uriString = Environment.GetEnvironmentVariable("ConnectionString") ?? throw new ArgumentNullException("Connection String : is null");
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
        public DbSet<User> UserTable { get; set; }
        public DbSet<Company> CompanyTable { get; set; }
    }