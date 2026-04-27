using Microsoft.EntityFrameworkCore;

namespace WhatsAppSenderApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // هذا السطر بحكي للنظام إنه عندنا جدول اسمه Customers رح نبنيه بناءً على كلاس Customer
        public DbSet<Customer> Customers { get; set; }
    }
}