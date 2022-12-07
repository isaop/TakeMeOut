using System;
using System.Collections.Generic;

namespace TakeMeOutBE.Models;

public partial class Event
{
    public int? IdEvent { get; set; }

    public string? EventName { get; set; }

    public int IdVenue { get; set; }

    public int? IdEventStatus { get; set; }

    public TimeSpan? Time { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public int? IdUser { get; set; }

    public int? IdBa { get; set; }

    public int IdCategory { get; set; }

    public virtual BusinessAccount? IdBaNavigation { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual EventStatus? IdEventStatusNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual Venue IdVenueNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<UserAction> UserActions { get; } = new List<UserAction>();
}
