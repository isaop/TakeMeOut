using System;
using System.Collections.Generic;

namespace TakeMeOutBE.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
