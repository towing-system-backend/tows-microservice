using System.ComponentModel.DataAnnotations;

namespace Tow.Infrastructure
{
    public record FindTowByIdDto(

        [Required]
        string Id
    );
}
