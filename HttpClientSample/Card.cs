
namespace HttpClientSample
{
    public class Card
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        // for converter in APIDbContext
        // public int[]? GoToNumber { get; set; }

        public List<Direction> Directions { get; set; } = new();
    }
}
