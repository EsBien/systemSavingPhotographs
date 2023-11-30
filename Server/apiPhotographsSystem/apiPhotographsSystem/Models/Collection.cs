namespace apiPhotographsSystem.Models
{
    public class Collection
    {
        public Collection(string itemId, string collectionSymbolization, string title)
        {
            this.itemId = itemId;
            this.collectionSymbolization = collectionSymbolization;
            this.title = title;
            images = new List<Image>();

        }
        public string? itemId { get; set; }
        public string? collectionSymbolization { get; set; }
        public string? title { get; set; }
        public List<Image> images { get; set; }
    }
}
