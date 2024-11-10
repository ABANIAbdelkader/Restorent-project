using System;
using System.Collections.Generic;

namespace projectStore.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CatId { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual Catigory? Cat { get; set; }
}
