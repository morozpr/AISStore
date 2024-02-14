using System;
using System.Collections.Generic;

namespace AISStore.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
