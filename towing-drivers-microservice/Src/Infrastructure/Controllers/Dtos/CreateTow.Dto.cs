using System.ComponentModel.DataAnnotations;

namespace Tow.Infrastructure
{
    public record  CreateTowDto(
        [Required]
        [StringLength(20, MinimumLength = 3)]
        string Brand,
        [Required]
        [StringLength(20, MinimumLength = 3)]
        string Model,
        [Required]
        [StringLength(20, MinimumLength = 3)]
        string Color,
        [Required]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}$")]
        string LicensePlate,
        [Required]
        int Year,
        [Required]
        [RegularExpression(@"^(Small|Medium|Large)$", ErrorMessage = "SizeType must be 'Small', 'Medium', or 'Large'")]
        string SizeType,
        [Required]
        [RegularExpression(@"^(Active|Inactive)$", ErrorMessage = "Status must be 'Active' or 'Inactive'")]
        string Status);
}
