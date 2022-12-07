using System;
using System.Collections.Generic;

namespace TakeMeOutBE.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdUser { get; set; }

    public int? IdEvent { get; set; }

    public int? Quantity { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
