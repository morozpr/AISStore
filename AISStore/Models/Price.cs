using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public int Value { get; set; }

    public DateTime DataSet { get; set; }

    public DateTime? DataUnSet { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
