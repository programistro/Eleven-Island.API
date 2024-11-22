using System.ComponentModel.DataAnnotations;

namespace ElevenIsland.Core.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public List<Image> Images { get; set; }
    public List<Attribute> Attributes { get; set; }
    
    public int CategoryId { get; set; }
}