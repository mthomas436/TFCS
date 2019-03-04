using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TFCS.API.DomainModels.Entities
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<SurveyOptionType> SurveyOptionTypes { get; set; }
        public virtual DbSet<SurveyOption> SurveyOptions { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }
        public virtual DbSet<SurveyType> SurveyTypes { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<CompanySurveyCatItem> CompanySurveyCatItems { get; set; }
        public virtual DbSet<StandardMenuItem> StandardMenuItems { get; set; }
        public virtual DbSet<SurveyMenuItem> SurveyMenuItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OI2KT74;Initial Catalog=TFCSTest;Integrated Security=True");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                     .WithMany(r => r.UserRoles)
                     .HasForeignKey(ur => ur.RoleId)
                     .IsRequired();

                userRole.HasOne(ur => ur.User)
                     .WithMany(r => r.UserRoles)
                     .HasForeignKey(ur => ur.UserId)
                     .IsRequired();

            });
 
                

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasOne(c => c.Company)
                .WithMany(s => s.Surveys);

                entity.HasOne(d => d.SurveyTypes)
                .WithMany(x => x.Surveys);
            });  

                         

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.HasOne(s => s.Survey)
                .WithMany(q => q.SurveyQuestions);
            });

            modelBuilder.Entity<SurveyOption>(entity =>
            {
                entity.HasOne(s => s.SurveyOptionType);
                //.WithMany(g => g.SurveyOption);

                entity.HasOne(s => s.SurveyQuestion)
                .WithMany(q => q.SurveyOptions);
            });   


            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.Property(e => e.DateEntered)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SurveyOption)
                    .WithMany(p => p.SurveyResponse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(d => d.OptionId);


                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyResponse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(d => d.SurveyId);
            });                
     
        }
    }
}
