namespace RubiksCube;

public class Tile
{
    public string Color { get; set; }
    public ConsoleColor ConsoleColor { get; set; }
    
    public int Height { get; set; }
    public int Width { get; set; }

    public int Id { get; set; }

    public Tile(string color, int height, int width, int id)
    {
        Color = color;
        ConsoleColor = GetColor(color);
        Height = height;
        Width = width;
        Id = id;
    }

    public void Display(int x, int y)
    {
        Console.BackgroundColor = ConsoleColor;

        for (int k = 0; k < Height; k++)
        {
            Console.SetCursorPosition(x, y + k);
            Console.Write(new string(' ', Width));
        }
        
        Console.SetCursorPosition(x + Width / 2, y + Height / 2);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(Id);
    }
    
    public ConsoleColor GetColor(string colorCode)
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