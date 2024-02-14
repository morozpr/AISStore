using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public string Position { get; set; } = null!;

    public bool IsOnStock { get; set; }

    public int ItemTypeId { get; set; }

    public string Description { get; set; } = null!;

    public int SupplyItemsId { get; set; }

    public virtual ItemType ItemType { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
