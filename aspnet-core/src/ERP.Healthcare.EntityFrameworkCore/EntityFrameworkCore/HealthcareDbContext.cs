using Microsoft.EntityFrameworkCore;
using ERP.Healthcare.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using ERP.Healthcare.Doctors;

namespace ERP.Healthcare.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See HealthcareMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class HealthcareDbContext : AbpDbContext<HealthcareDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State>  States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<DoctorMembership> DoctorMemberships{ get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<DoctorShift> DoctorShifts { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<DoctorTitle> DoctorTitles { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside HealthcareDbContextModelCreatingExtensions.ConfigureHealthcare
         */

        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the HealthcareEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureHealthcare method */

            builder.ConfigureHealthcare();
        }
    }
}
