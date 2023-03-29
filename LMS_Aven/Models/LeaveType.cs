using System;
using System.Collections.Generic;

namespace LMS_Aven.Models;

public partial class LeaveType
{
    public string LeaveTypeId { get; set; } = null!;

    public string? LeaveType1 { get; set; }

    public string? AboutLeave { get; set; }

    public virtual ICollection<LeaveDetail> LeaveDetails { get; } = new List<LeaveDetail>();

    public virtual ICollection<UserLeaveDetail> UserLeaveDetails { get; } = new List<UserLeaveDetail>();
}
