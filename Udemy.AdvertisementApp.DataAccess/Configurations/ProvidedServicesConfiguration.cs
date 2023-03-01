using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.DataAccess.Configurations
{
    public class ProvidedServicesConfiguration : IEntityTypeConfiguration<ProvidedServices>
    {
        public void Configure(EntityTypeBuilder<ProvidedServices> builder)
        {
            builder.Property(x=>x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x=>x.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
