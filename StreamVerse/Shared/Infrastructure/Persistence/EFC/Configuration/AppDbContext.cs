using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using StreamVerse.CRM.Domain.Model.Aggregate;
using StreamVerse.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace StreamVerse.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
      
      //=================================================================================================
      //===================================== 1. BOUNDED CONTEXT ================================
      /*
       *  public int Id { get; set; }
    public Guid UserId { get; set; }  // Guid único, autogenerado
    public string FirstName { get; set; } = null!; // Entre 4 y 40 caracteres
    public string LastName { get; set; } = null!; // Entre 4 y 40 caracteres
    public EUserStatus Status { get; set; } // Restringido por EUserStatus
    public ESubscriptionChannelType? SubscriptionChannelType { get; set; } // No obligatorio
    public DateTime? JoinedAt { get; set; } // No obligatorio
    public DateTime? SubscriptionApprovedAt { get; set; } // No obligatorio
    public DateTime? CancellationReportedAt { get; set; } // No obligatorio
       */
      
      builder.Entity<User>().HasKey(u => u.Id);
      builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<User>().Property(u => u.UserId).IsRequired().HasMaxLength(36); // Guid único, autogenerado
      builder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(40); // Entre 4 y 40 caracteres
      builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(40); // Entre 4 y 40 caracteres
      builder.Entity<User>().Property(u => u.Status).IsRequired(); // Restringido por EUserStatus
      builder.Entity<User>().Property(u => u.SubscriptionChannelType).IsRequired(false); // No obligatorio
      builder.Entity<User>().Property(u => u.JoinedAt).IsRequired(false); // No obligatorio
      builder.Entity<User>().Property(u => u.SubscriptionApprovedAt).IsRequired(false); // No obligatorio
      builder.Entity<User>().Property(u => u.CancellationReportedAt).IsRequired(false); // No obligatorio
      
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}