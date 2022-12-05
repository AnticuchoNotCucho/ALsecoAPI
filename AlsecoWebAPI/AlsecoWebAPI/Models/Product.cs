using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlsecoWebAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Category { get; set; }

    public int Precio { get; set; }

    public int Stock { get; set; }

    public string Image { get; set; } = null!;
    public virtual Category CategoryNavigation { get; set; } = null!;
}
