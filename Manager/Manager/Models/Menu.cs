namespace Manager.Models
{
    public class Menu
    {
        [Key]
        public Guid MenuId { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public Guid Parent { get; set; }
    }
}
