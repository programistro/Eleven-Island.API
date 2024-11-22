using System.ComponentModel.DataAnnotations;

namespace ElevenIsland.Core;

public class Product
{
    [Key]
    public Guid idProduct { get; set; }
    public int Id { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public List<Image> Images { get; set; }
    public List<Attribute> Attributes { get; set; }
    
    public int CategoryId { get; set; }
}

public class Image
{
    [Key]
    public Guid Id { get; set; }
    
    public string Src { get; set; }
}

public class Attribute
{
    [Key]
    public Guid Id { get; set; }
    
    public int ProductAttributeId { get; set; }
    public List<AttributeValue> AttributeValues { get; set; }
}

public class AttributeValue
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public int? Quantity { get; set; }
}
