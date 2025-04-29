using HRManager.Enums;

namespace HRManager.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public TypeLeave TypeOfLeave { get; set; }
        public Status StatusLeave { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly RequestDate { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; } 
    }
}
