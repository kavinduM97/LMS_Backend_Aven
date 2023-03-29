using System;
using System.Collections.Generic;

namespace LMS_Aven.Models;

public partial class LeaveDetail
{
    public string DetailsId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? LeaveTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? LeaveSession { get; set; }

    public string? LeaveStatus { get; set; }

    public string? Reason { get; set; }

    public DateTime? RequestedDate { get; set; }

    public DateTime? CheckedDate { get; set; }

    public double? NoOfDays { get; set; }

    public bool? IsNopayed { get; set; }

    public virtual LeaveType? LeaveType { get; set; }
}
