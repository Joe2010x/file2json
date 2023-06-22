namespace cwproj.Services;

public interface IFileReader
{
     List<string> GetLines();

     List<List<string>> GetLinesOfWords();
    
}