namespace apiPhotographsSystem.Models
{
    public class Image
    {
        public string collectionSymbolization { get; set; }
        public string imagePath { get; set; }
        public string imageBackPath { get; set; }
        public int imageNumber { get; set; }
        public Image(string collectionSymbolization, string imagePath, string imageBackPath,int imageNumber)
        {
            this.collectionSymbolization = collectionSymbolization;
            this.imagePath = imagePath;
            this.imageBackPath = imageBackPath;
            this.imageNumber = imageNumber;
            
        }

    }
}
