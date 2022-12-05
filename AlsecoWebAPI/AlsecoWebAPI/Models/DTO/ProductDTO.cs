namespace AlsecoWebAPI.Models.DTO;

public class ProductDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Category { get; set; }

    public int Precio { get; set; }

    public int Stock { get; set; }

    public string Image { get; set; } = null!;

}