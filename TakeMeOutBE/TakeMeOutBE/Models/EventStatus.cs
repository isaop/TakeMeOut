using System;
using System.Collections.Generic;

namespace TakeMeOutBE.Models;

public partial class EventStatus
{
    public int IdEventStatus { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
