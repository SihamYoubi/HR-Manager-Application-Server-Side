using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRManager.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> { 
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) {}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<LeaveRequest>()
			.HasOne(lr => lr.User)
			.WithMany(u => u.LeaveRequests)
			.HasForeignKey(lr => lr.UserId)
			.HasPrincipalKey(u => u.Id)
			.OnDelete(DeleteBehavior.Cascade);
		modelBuilder.Entity<LeaveRequest>()
			.Property(lr => lr.TypeOfLeave)
			.HasConversion<string>();
		modelBuilder.Entity<LeaveRequest>()
			.Property(lr => lr.StatusLeave)
			.HasConversion<string>();
	}
	public DbSet<LeaveRequest> LeaveRequests { get; set; }
}