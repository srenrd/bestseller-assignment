namespace Products.Api.Data.Database.Model;

public sealed class ProductEntity
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required decimal Price { get; set; }

    public required string Genre { get; set; }

    public required string Developer { get; set; }

    public required string Publisher { get; set; }

    public required DateOnly ReleaseDate { get; set; }

    public required decimal Rating { get; set; }

    public string? CoverImage { get; set; }
}
