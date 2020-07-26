using ERP.Healthcare.Doctors;
using ERP.Healthcare.Patients;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ERP.Healthcare.EntityFrameworkCore
{
    public static class HealthcareDbContextModelCreatingExtensions
    {
        public static void ConfigureHealthcare(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */
            
            builder.Entity<State>()
                .HasOne<Country>(p => p.Country)
                .WithMany(p=> p.States)
                .IsRequired();

            builder.Entity<City>()
                .HasOne(p => p.State)
                .WithMany(p => p.Cities)
                .IsRequired();

            builder.Entity<Address>()
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .IsRequired();
            
            builder.Entity<Doctor>()
                .HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(s => s.AddressId)
                .IsRequired();

            builder.Entity<Doctor>()
                .HasOne(p => p.DoctorSpecialty)
                .WithMany()
                .HasForeignKey(s => s.DoctorSpecialtyId)
                .IsRequired();

            builder.Entity<Doctor>()
                .HasOne(p => p.DoctorTitle)
                .WithMany()
                .HasForeignKey(s => s.DoctorTitleId)
                .IsRequired();

            builder.Entity<Membership>()
               .HasOne(p => p.Address)
               .WithMany()
               .IsRequired();

            builder.Entity<DoctorMembership>()
                .HasOne(p => p.Membership)
                .WithMany(p => p.DoctorMemberships);

            builder.Entity<DoctorMembership>()
                .HasOne(p => p.Doctor)
                .WithMany(p => p.DoctorMemberships)
                .IsRequired();

            builder.Entity<DoctorMembership>()
               .HasOne(p => p.DoctorShift)
               .WithMany()
               .IsRequired();

            builder.Entity<DoctorService>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .IsRequired();

            builder.Entity<Country>(b =>
            {
                b.ToTable("Countries", "General");
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(100);
                b.Property(x => x.Code).IsRequired().HasMaxLength(100);
            });

            builder.Entity<State>(b =>
            {
                b.ToTable("States", "General");
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<City>(b =>
            {
                b.ToTable("Cities", "General");
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(100); 
            });

            builder.Entity<Address>(b =>
            {
                b.ToTable("Addresses", "General");
                b.ConfigureByConvention();
                b.Property(x => x.StreetName).IsRequired().HasMaxLength(100);
                b.Property(x => x.DistrictName).IsRequired().HasMaxLength(100);
                b.Property(x => x.BuildNumber).IsRequired();
                b.Property(x => x.ApartmentNumber).IsRequired();
                b.Property(x => x.Postalcode).IsRequired();
            });

            builder.Entity<Doctor>(b =>
            {
                b.ToTable("Doctors", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(x => x.Gender).IsRequired();
                b.Property(x => x.Description).IsRequired().HasMaxLength(100);
                b.Property(x => x.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<DoctorService>(b =>
            {
                b.ToTable("DoctorServices", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(100);
                b.Property(p => p.Price).IsRequired();
            });

            builder.Entity<DoctorMembership>(b =>
            {
                b.ToTable("DoctorMemberships", nameof(Doctor));
                b.ConfigureByConvention();
            });

            builder.Entity<Membership>(b =>
            {
                b.ToTable("Memberships", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<DoctorShift>(b =>
            {
                b.ToTable("DoctorShifts", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(p => p.Day).IsRequired();
                b.Property(p => p.From).IsRequired();
                b.Property(p => p.To).IsRequired();
            });

            builder.Entity<DoctorSpecialty>(b =>
            {
                b.ToTable("DoctorSpecialties", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<DoctorTitle>(b =>
            {
                b.ToTable("DoctorTitles", nameof(Doctor));
                b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Patient>(b =>
            {
                b.ToTable("Patient", nameof(Patient));
                b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(PatientConsts.MaxNameLength);
                b.Property(p => p.ShortDescription).IsRequired().HasMaxLength(PatientConsts.MaxShortDescriptionLength);
                b.HasIndex(p => p.Name);
            });
        }
    }
}