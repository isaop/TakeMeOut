using System;
using System.Collections.Generic;

namespace TakeMeOut.Database.Models;

public partial class BusinessAccount
{
    public int IdBa { get; set; }

    public string? Password { get; set; }  

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public float? ContactNo { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? IdVenue { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual Venue? IdVenueNavigation { get; set; }
}
