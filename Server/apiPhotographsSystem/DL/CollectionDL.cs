
using Entities;
using System;
using System.Collections.Immutable;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace DL
{
    public class CollectionDL : IcollectionDL
    {
        string fileDBPath = "C:/Users/PC/Desktop/apiPhotographsSystem/DL/DBcollection.json";
        //C:/Users/PC/Desktop/apiPhotographsSystem/DL/DBcollection.json
        List<Collection> collections;
        public CollectionDL()
        {
            collections = GetCollections().Result;
        }
        private async Task<List<Collection>> GetCollections()
        {
            try
            {
                // Read all lines asynchronously
                string[] lines = await File.ReadAllLinesAsync(fileDBPath);

                // Combine lines into a single string
                string jsonContent = string.Join(Environment.NewLine, lines);

                // Deserialize the JSON content into a list of Collection objects
                List<Collection> collections = JsonSerializer.Deserialize<List<Collection>>(jsonContent);
                return collections;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, invalid JSON, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        private async void postCollections(Collection collection)
        {
            for (int i = 0; i < collections.Count; i++)
            {
                if (collection.collectionSymbolization.Equals(collections[i].collectionSymbolization))
                {
                    collections[i] = collection;
                }
            }
            // Serialize the updated collection list back to JSON
            string updatedJsonContent = JsonSerializer.Serialize(collections);

            // Write the updated JSON content back to the file
            await File.WriteAllTextAsync(fileDBPath, updatedJsonContent);

        }

        public async Task<Collection> GetCollectionName(string collectionNumber)
        {
            try
            {
                // Find the collection with the specified collectionNumber
                Collection collection = collections.FirstOrDefault(data => data.collectionSymbolization == collectionNumber);

                return collection;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, invalid JSON, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }

        }

        public void SaveCollection(Collection collectionData)
        {

            string filePath = "C:/Users/PC/Desktop/apiPhotographsSystem/DL/SaveImages";
            //C:/Users/PC/Desktop/apiPhotographsSystem/DL/SaveImages
            try
            {
                postCollections(collectionData);
                collectionData.images.ForEach(image =>
                {
                    string fullFilePath = $"{filePath}/{image.collectionSymbolization}_{image.imageNumber}.txt";
                    string content = GenerateFileContent(collectionData, image.imageNumber);
                    System.IO.File.WriteAllText(fullFilePath, content);
                });
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
        private string GenerateFileContent(Collection collectionData, int i)
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine(collectionData.collectionSymbolization);
            content.AppendLine(collectionData.title);
            content.AppendLine(collectionData.images[i - 1].imageNumber.ToString());
            content.AppendLine(collectionData.images[i - 1].imagePath);

            if (!string.IsNullOrEmpty(collectionData.images[i - 1].imageBackPath))
            {
                content.AppendLine(collectionData.images[i - 1].imageBackPath);
            }

            return content.ToString();
        }
    }
}



//string jListPath = ConfigurationManager.AppSettings[@"C:\Users\user\Desktop\YadVashemProject\מוסדות.json"];//@"D:\list.txt";
//public async Task<List<Institutes>> getAllInstitutes()
//{
//    List<Institutes> institutes;
//    try
//    {
//        string path = @"C:\Users\user\Desktop\YadVashemProject\server\DL\מוסדות.json";
//        FileStream fs = new FileStream(path, FileMode.Open);
//        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Institutes>));
//        institutes = js.ReadObject(fs) as List<Institutes>;
//        Console.WriteLine(institutes);
//        fs.Close();
//    }
//    catch (Exception ex)
//    {
//        institutes = new List<Institutes>();
//        Console.WriteLine(ex.Message);
//    }
//    return institutes;
//}
//    }