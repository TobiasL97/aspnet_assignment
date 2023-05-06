namespace aspnet_assignment.ViewModels
{
    public class GridItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }

        public string ProductImageUrl { get; set; } = null!;
    }
}
