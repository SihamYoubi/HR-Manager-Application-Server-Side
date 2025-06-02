using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManager.Models;
using HRManager.DTOs;
using HRManager.Enums;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LeaveRequestsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LeaveRequestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/LeaveRequests
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var leaves = await _context.LeaveRequests.Include(l => l.User).ToListAsync();
        return Ok(leaves);
    }

    // GET: api/LeaveRequests/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var leave = await _context.LeaveRequests.FindAsync(id);
        if (leave == null) return NotFound();
        return Ok(leave);
    }

    // POST: api/LeaveRequests
    [Authorize(Roles = "Employee")]
    [HttpPost]
    public async Task<IActionResult> Create(LeaveRequestDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
            return Unauthorized();

        var leaveRequest = new LeaveRequest
        {
            TypeOfLeave = dto.TypeOfLeave,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            RequestDate = DateOnly.FromDateTime(DateTime.Today),
            StatusLeave = Status.Pending,
            UserId = int.Parse(userId)
        };

        _context.LeaveRequests.Add(leaveRequest);
        await _context.SaveChangesAsync();

        return Ok(leaveRequest);
    }

    // PUT: api/LeaveRequests/5
    [Authorize(Roles = "Admin,Employee")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LeaveRequest updated)
    {
        var existing = await _context.LeaveRequests.FindAsync(id);
        if (existing == null) return NotFound();

        existing.TypeOfLeave = updated.TypeOfLeave;
        existing.StartDate = updated.StartDate;
        existing.EndDate = updated.EndDate;
        existing.StatusLeave = updated.StatusLeave;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    // DELETE: api/LeaveRequests/5
    [Authorize(Roles = "Employee")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var leave = await _context.LeaveRequests.FindAsync(id);
        if (leave == null) return NotFound();

        _context.LeaveRequests.Remove(leave);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
