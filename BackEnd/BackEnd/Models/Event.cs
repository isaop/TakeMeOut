using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Event
{
    public int? IdEvent { get; set; }

    public string? EventName { get; set; }

    public int IdVenue { get; set; }

    public string? Description { get; set; }

    public int IdBusinessAccount { get; set; }

    public string? startHour { get; set; }

    public string? endHour { get; set; }

    public string? startDate { get; set; }

    public string? endDate { get; set; }

    public int IdCategory { get; set; }

    public virtual BusinessAccount IdBusinessAccountNavigation { get; set; } = null!;

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Venue IdVenueNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<UserAction> UserActions { get; } = new List<UserAction>();
}
