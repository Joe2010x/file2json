namespace cwproj.Services;

public class FileReader : IFileReader

{
    private readonly string _context;

    public FileReader(string fileName) {
        _context = fileName;
    }
    public List<string> GetLines()
    {
        string? line;
        var result = new List<string>();

        using (StreamReader reader = new StreamReader (_context))

        {
            while((line = reader.ReadLine()) != null) {
                result.Add(line);
            }
        }

        return result;
    }

    public List<List<string>> GetLinesOfWords()
    {
        var lines = GetLines();

        var result = new List<List<string>>();
        lines.ForEach(l => result.Add(l.Split(';').ToList()));

        return result;
        
    }
}