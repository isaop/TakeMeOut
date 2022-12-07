using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Payment
{
    public int IdPayment { get; set; }

    public int? IdUser { get; set; }

    public int? Amount { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
