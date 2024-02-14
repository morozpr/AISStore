using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int EmployeeId { get; set; }

    public int ClientId { get; set; }

    public int OrderItemsId { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual OrderItem OrderItems { get; set; } = null!;
}
