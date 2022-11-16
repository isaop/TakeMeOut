using System;
using System.Collections.Generic;

namespace TakeMeOut.Database.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public float? PhoneNo { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<UserAction> UserActions { get; } = new List<UserAction>();
}
