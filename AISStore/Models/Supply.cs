using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class Supply
{
    public int SupplyId { get; set; }

    public int ProviderId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Provider Provider { get; set; } = null!;

    public virtual ICollection<SupplySupplyItem> SupplySupplyItems { get; set; } = new List<SupplySupplyItem>();
}
