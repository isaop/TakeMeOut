using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Venue
{
    public int? IdVenue { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? ContactNumber { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BusinessAccount> BusinessAccounts { get; } = new List<BusinessAccount>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
