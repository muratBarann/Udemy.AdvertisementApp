using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.DataAccess.Configurations;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.DataAccess.Contexts
{
    public class AdvertisementContext : DbContext
    {

        
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {

        }

        //Tüm tablolar yani Entitilerimiz tanımlandı.   
        DbSet<Advertisement> Advertisements { get; set; }
        DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
        DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }
        DbSet<AppRole> AppRoles { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppUserRole> AppUsersRoles { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        DbSet<ProvidedServices> ProvidedServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServicesConfiguration());
            
        }



    }
}
