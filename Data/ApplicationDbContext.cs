using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRManager.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> { 
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) { }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<LeaveRequest>()
			.HasOne(lr => lr.User)
			.WithMany(u => u.LeaveRequests)
			.HasForeignKey(Lr => Lr.UserId)
			.HasPrincipalKey(u=>u.Id)
			.OnDelete(DeleteBehavior.Cascade);
	}
	public DbSet<LeaveRequest> LeaveRequests { get; set; }
}