using System.ComponentModel.DataAnnotations;

namespace ElevenIsland.Core;

public class FrontLogo
{
    [Key]
    public Guid Id { get; set; }
    
    public string? PcLogo { get; set; }
    
    public string? MobileLogo { get; set; }
}