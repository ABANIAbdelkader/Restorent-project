using System;
using System.Collections.Generic;

namespace projectStore.Models;

public partial class Card
{
    public int Id { get; set; }

    public string? Userid { get; set; }

    public int? ProductId { get; set; }

    public int? Countity { get; set; }

    public virtual Product? Product { get; set; }
}
