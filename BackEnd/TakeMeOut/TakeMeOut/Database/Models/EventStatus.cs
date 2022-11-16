using System;
using System.Collections.Generic;

namespace TakeMeOut.Database.Models;

public partial class EventStatus
{
    public int IdEstat { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
