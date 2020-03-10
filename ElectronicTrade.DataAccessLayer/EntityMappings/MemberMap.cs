using ElectronicTrade.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.DataAccessLayer.EntityMappings
{
    class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            this.ToTable("Members", "ETrade");

            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Id).HasColumnOrder(0);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.Name).HasColumnOrder(1);
            this.Property(x => x.Name).IsRequired();
            this.Property(x => x.Name).HasMaxLength(25);

            this.Property(x => x.Surname).HasColumnName("Surname");
            this.Property(x => x.Surname).HasColumnOrder(2);
            this.Property(x => x.Surname).IsRequired();
            this.Property(x => x.Surname).HasMaxLength(25);

            this.Property(x => x.Email).HasColumnName("Email");
            this.Property(x => x.Email).HasColumnOrder(3);
            this.Property(x => x.Email).IsRequired();
            this.Property(x => x.Email).HasMaxLength(25);

            this.Property(x => x.Biography).HasColumnName("Biography");
            this.Property(x => x.Biography).HasColumnOrder(4);
            this.Property(x => x.Biography).IsOptional();
            this.Property(x => x.Biography).HasMaxLength(200);

            this.Property(x => x.ProfileImageName).HasColumnName("ProfileImageName");
            this.Property(x => x.ProfileImageName).HasColumnOrder(5);
            this.Property(x => x.ProfileImageName).IsRequired();
            this.Property(x => x.ProfileImageName).HasMaxLength(75);

            this.Property(x => x.UserBy).HasColumnName("UserBy");
            this.Property(x => x.UserBy).HasColumnOrder(6);
            this.Property(x => x.UserBy).IsRequired();
            this.Property(x => x.UserBy).HasMaxLength(25);

            this.Property(x => x.MemberType).HasColumnName("MemberType");
            this.Property(x => x.MemberType).HasColumnOrder(7);
            //this.Property(x => x.MemberType).IsRequired();

            this.Property(x => x.AddedDate).HasColumnName("AddedDate");
            this.Property(x => x.AddedDate).HasColumnOrder(8);
            this.Property(x => x.AddedDate).IsRequired();

            this.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(x => x.ModifiedDate).HasColumnOrder(9);
            this.Property(x => x.ModifiedDate).IsOptional();

            this.Property(x => x.Password).HasColumnName("Password");
            this.Property(x => x.Password).HasColumnOrder(10);
            this.Property(x => x.Password).IsRequired();
            this.Property(x => x.Password).HasMaxLength(400);

            this.Property(x => x.Username).HasColumnName("Username");
            this.Property(x => x.Username).HasColumnOrder(11);
            this.Property(x => x.Username).IsRequired();
            this.Property(x => x.Username).HasMaxLength(25);

            this.Property(x => x.ActivateGuid).HasColumnName("ActivateGuid");
            this.Property(x => x.ActivateGuid).HasColumnOrder(12);

            this.Property(x => x.AccountStatus).HasColumnName("AccountStatus");
            this.Property(x => x.AccountStatus).HasColumnOrder(13);

            this.Property(x => x.IdentificationNumber).HasColumnName("IdentificationNumber");
            this.Property(x => x.IdentificationNumber).HasColumnOrder(14);
            this.Property(x => x.IdentificationNumber).IsOptional();
            this.Property(x => x.IdentificationNumber).HasMaxLength(30);

        }
    }
}
