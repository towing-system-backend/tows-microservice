using System.ComponentModel.DataAnnotations;

namespace Tow.Infrastructure
{
    public record UpdateTowDto(

        [Required]
        string Id,
        [StringLength(20, MinimumLength = 3)]
        string? Brand,
        [StringLength(20, MinimumLength = 3)]
        string? Model,
        [StringLength(20, MinimumLength = 3)]
        string? Color,
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}$")]
        string? LicensePlate,
        [StringLength(40, MinimumLength = 3)]
        string? Location,
        int? Year,
        [RegularExpression(@"^(Small|Medium|Large)$", ErrorMessage = "SizeType must be 'Small', 'Medium', or 'Large'")]
        string? SizeType,
        [RegularExpression(@"^(Active|Inactive)$", ErrorMessage = "Status must be 'Active' or 'Inactive'")]
        string? Status
    );
}
