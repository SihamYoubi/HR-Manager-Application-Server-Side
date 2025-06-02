using HRManager.Enums;

namespace HRManager.DTOs
{
    public class LeaveRequestDto
    {
        public TypeLeave TypeOfLeave { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
