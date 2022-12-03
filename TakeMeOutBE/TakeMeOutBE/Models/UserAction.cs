using System;
using System.Collections.Generic;

namespace TakeMeOutBE.Models;

public partial class UserAction
{
    public int IdUserAction { get; set; }

    public string? ActionName { get; set; }

    public string? Description { get; set; }

    public int? IdEvent { get; set; }

    public int? IdUser { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
