using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRManager.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> { 
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) { }
	public DbSet<LeaveRequest> LeaveRequests { get; set; }
}