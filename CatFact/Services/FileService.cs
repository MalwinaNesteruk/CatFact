using CatFact.Services.Interfaces;

namespace CatFact.Services
{
    public class FileService : IFileService
    {
        public void AddTextToFile(string line)
        {
            var filePath = "infoAboutCats.txt";
            using (StreamWriter file = File.AppendText(filePath))
            {
                file.WriteLine(line);
            }
        }
    }
}
