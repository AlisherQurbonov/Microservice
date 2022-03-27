using System.ComponentModel.DataAnnotations;

namespace platformservice.Dtos;

public class PlatformCreateDto
{
    public int Id { get; set; }    

    
    [Required]
    public string Name { get; set; }

    [Required]

    public string Publisher { get; set; }

    [Required]

    public string Cost { get; set; }

}