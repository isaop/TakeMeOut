using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class BusinessAccount
{
    public int IdBusinessAccount { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? ContactNumber { get; set; }

    public int? IdVenue { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual Venue? IdVenueNavigation { get; set; }
}
