using HRManager.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        [Required]
        public TypeLeave TypeOfLeave { get; set; }

        public Status StatusLeave { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        public DateOnly RequestDate { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; } 
    }
}
