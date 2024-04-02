namespace Invoice_Management_Api.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options):base(Options)
        {
            
        }
        public DbSet<Branch> Branches {  get; set; }
        public DbSet<Cashier> Cashiers {  get; set; }
        public DbSet<City> Cities {  get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders {  get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails {  get; set; }
    }
}
