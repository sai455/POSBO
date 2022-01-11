using Microsoft.EntityFrameworkCore;
using POSBOWeb.Models;
using POSBOWeb.Services.Context.Entites;

namespace POSBOWeb.Services.Context
{
    public class PosboDBContext : DbContext
    {
        public PosboDBContext(DbContextOptions<PosboDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrinterDTO>().HasNoKey();
        }
        public DbSet<InvItemMasterEntity> InvItemMasters { get; set; }
        public DbSet<MasterPOSPrinterPrepEntity> MasterPOSPrinterPreps { get; set; }
        public DbSet<ItemPrinterEntity> ItemPrinters { get; set; }
        public DbSet<PrinterDTO> PrinterDTOs { get; set; }
    }
}