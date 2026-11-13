using System.ComponentModel.DataAnnotations;

namespace Products.Api.Data.Network.Model;

public sealed class CreateProductModel
{
    [Required(ErrorMessage = "Title is required.")]
    public required string Title { get; init; }

    [Required(ErrorMessage = "Description is required.")]
    public required string Description { get; init; }

    [Range(typeof(decimal), "0.000001", "999999999.999999", ParseLimitsInInvariantCulture = true)]
    public required decimal Price { get; init; }

    [Required(ErrorMessage = "Genre is required.")]
    public required string Genre { get; init; }

    [Required(ErrorMessage = "Developer is required.")]
    public required string Developer { get; init; }

    [Required(ErrorMessage = "Publisher is required.")]
    public required string Publisher { get; init; }

    public required DateOnly ReleaseDate { get; init; }

    [Range(typeof(decimal), "0", "100", ParseLimitsInInvariantCulture = true)]
    public required decimal Rating { get; init; }

    public string? CoverImage { get; init; }
}
