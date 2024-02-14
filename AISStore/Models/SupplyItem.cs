using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class SupplyItem
{
    public int SupplyItemId { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<SupplySupplyItem> SupplySupplyItems { get; set; } = new List<SupplySupplyItem>();
}
