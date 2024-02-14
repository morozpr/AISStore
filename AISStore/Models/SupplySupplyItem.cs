using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class SupplySupplyItem
{
    public int SupplyItemsId { get; set; }

    public int SupplyId { get; set; }

    public int SupplyItemId { get; set; }

    public virtual Supply Supply { get; set; } = null!;

    public virtual SupplyItem SupplyItem { get; set; } = null!;
}
