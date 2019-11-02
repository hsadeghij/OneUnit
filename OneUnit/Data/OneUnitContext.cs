using OneUnit.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneUnit.Areas.QC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.Transit.Data.Entities;
using OneUnit.Areas.Transit.ViewModels;

namespace OneUnit.Data
{
    public class OneUnitContext : IdentityDbContext<StoreUser>
    {
        public OneUnitContext(DbContextOptions<OneUnitContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        #region ***QC Area***
        public DbSet<Areas.QC.Data.Entities.ProcessName> ProcessNames { get; set; }
        public DbSet<ControlParameter> ControlParameters { get; set; }
        public DbSet<DegreeOfImportance> DegreeOfImportances { get; set; }
        public DbSet<SampleValue> SampleValues { get; set; }

        public DbSet<SamplingLocation> SamplingLocations { get; set; }

        public DbSet<TestValue> TestValues { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<QualityDesign> QualityDesigns { get; set; }
        public DbSet<ProcessType> ProcessTypes { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Minute> Minutes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<QualityControl> QualityControls { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ColumnNumber> ColumnNumbers { get; set; }
        public DbSet<QParameterStatus> QParameterStatuss { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<HasT> HasTs { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<TypeOfCorn> TypeOfCorns { get; set; }
        public DbSet<PauseTime> PauseTimes { get; set; }

        #endregion ***QC Area***
        #region ***Transit Area***
        public DbSet<Person> Persons { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<CurrentState> CurrentStates { get; set; }
        public DbSet<TransitInfo> TransitInfos { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPlan> ProjectPlans { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TraceWorker> TraceWorkers { get; set; }
        public DbSet<TransitType> TransitTypes { get; set; }
        public virtual DbSet<EnableWorkerViewModel> EnableWorkerViewModels { get; set; }
        
        public virtual DbSet<ProjectPlanInCurrentDateViewModel> ProjectPlanInCurrentDateViewModels { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<ControlParameter>()
              .HasOne(s => s.RAction)
              .WithMany(t => t.ControlParameterRActions)
              .HasForeignKey(e => e.RActionId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ControlParameter>()
           .HasOne(s => s.ProcessName)
           .WithMany(t => t.ControlParameters)
           .HasForeignKey(e => e.ProcessNameId)
           .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<QualityDesign>()
            //.HasOne(s => s.DateForQualityDesign)
            //.WithMany(t => t.QualityDesigns)
            //.HasForeignKey(e => e.DateForQualityDesignId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<QualityDesign>()
            //.HasOne(s => s.SamplingLocation)
            //.WithMany(t => t.QualityDesigns)
            //.HasForeignKey(e => e.SamplingLocationId)
            //.OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<QualityDesign>()
            //.HasOne(s => s.Sampler)
            //.WithMany(t => t.QualityDesignSampler)
            //.HasForeignKey(e => e.SamplerId)
            //.OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<QualityDesign>()
            // .HasOne(s => s.Tester)
            // .WithMany(t => t.QualityDesignTester)
            // .HasForeignKey(e => e.TesterId)
            // .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<QualityDesign>()
            // .HasOne(s => s.ControllerUser)
            // .WithMany(t => t.QualityDesignControllerUser)
            // .HasForeignKey(e => e.ControllerUserId)
            // .OnDelete(DeleteBehavior.Restrict);

            #region For Authorization

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<StoreUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StoreUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            #endregion
        }


    }
}
