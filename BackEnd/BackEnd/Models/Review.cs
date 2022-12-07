using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Review
{
    public int IdReview { get; set; }

    public int? IdEvent { get; set; }

    public int? IdUser { get; set; }

    public int? IdPayment { get; set; }

    public string? Comment { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual Payment? IdPaymentNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
