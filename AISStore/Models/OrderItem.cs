using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class OrderItem
{
    public int OrderItemsId { get; set; }

    public int ItemId { get; set; }

    public int Amount { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
