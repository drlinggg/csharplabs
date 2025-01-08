using Parsers.Models;
using Receivers.Models;

namespace Programs;

public class Program
{
    public static void Main(string[] args)
    {
        var fileManager = new FileManager();
        var parser = new ArgsParser(fileManager);
        parser.Parse(args);

        while (true)
        {
            string? input = Console.ReadLine();
            if (input is not null)
                parser.Parse(input.Split(' '));
        }
    }
}
