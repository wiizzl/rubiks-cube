namespace RubiksCube;

public class Tile
{
    public string Color { get; set; }
    public ConsoleColor ConsoleColor { get; set; }
    
    public int TileHeight { get; set; }
    public int TileWidth { get; set; }

    public Tile(string color, ConsoleColor consoleColor, int tileHeight, int tileWidth)
    {
        Color = color;
        ConsoleColor = consoleColor;
        TileHeight = tileHeight;
        TileWidth = tileWidth;
    }

    public void Display(int x, int y)
    {
        Console.BackgroundColor = ConsoleColor;

        for (int k = 0; k < TileHeight; k++)
        {
            Console.SetCursorPosition(x + 2, y + k + 3);
            Console.Write(new string(' ', TileWidth));
        }
    }
    
    public static ConsoleColor GetColor(string colorCode)
    {
        return colorCode switch
        {
            "W" => ConsoleColor.White,
            "R" => ConsoleColor.Red,
            "Y" => ConsoleColor.Yellow,
            "G" => ConsoleColor.Green,
            "B" => ConsoleColor.Blue,
            "O" => ConsoleColor.DarkYellow,
            _ => ConsoleColor.Black
        };
    }
}