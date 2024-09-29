

namespace TheWildOasis.Models
{
  public class Cabin
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int RegularPrice { get; set; }
    public int Discount { get; set; }
    public string? Description { get; set; }
    public string Image { get; set; } = string.Empty;
  }
}