using Microsoft.EntityFrameworkCore;
using Context.EntityConfigurations;
using DTO.Models;
using Common.Helpers;

namespace Context
{
    public class FlyttomContext : DbContext
    {
        public virtual DbSet<AppSettings> AppSettings { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AuthToken> AuthTokens { get; set; }
        public virtual DbSet<Makes> Makes { get; set; }
        public virtual DbSet<VehicleModels> VehicleModel { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleImage> VehicleImage { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<sys_drop_down_mf> sys_drop_down_mf { get; set; }
        public virtual DbSet<sys_drop_down_value> sys_drop_down_value { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<VehiclePart> VehiclePart { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettingHelper.GetDefaultConnection());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AuthTokenConfiguration());
            modelBuilder.ApplyConfiguration(new MakesConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelsConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleImageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new DropDownMfConfiguration());
            modelBuilder.ApplyConfiguration(new DropDownValueConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclePartConfiguration());
        }
    }
}