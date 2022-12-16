using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class User
{
    public int? IdUser { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<UserAction> UserActions { get; } = new List<UserAction>();
}
