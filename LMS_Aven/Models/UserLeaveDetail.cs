using System;
using System.Collections.Generic;

namespace LMS_Aven.Models;

public partial class UserLeaveDetail
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? LeaveTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? TotalNumberOfdays { get; set; }

    public double? NumberofDatesUsed { get; set; }

    public int? NumofNoPayed { get; set; }

    public virtual LeaveType? LeaveType { get; set; }
}
