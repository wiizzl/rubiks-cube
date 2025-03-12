namespace RubiksCube;

public class Face
{
    public static int FaceSize = 3;
    
    public Tile[,] Tiles { get; set; }
    
    public int TileHeight { get; set; }
    public int TileWidth { get; set; }

    public Face(string color, int tileHeight, int tileWidth)
    {
        TileHeight = tileHeight;
        TileWidth = tileWidth;
        
        Tiles = new Tile[FaceSize, FaceSize];

        for (int i = 0; i < FaceSize; i++)
        {
            for (int j = 0; j < FaceSize; j++)
            {
                Tiles[i, j] = new Tile(color, tileHeight, tileWidth, FaceSize * i + j + 1);
            }
        }
    }

    public void Display(int x, int y)
    {
        for (int i = 0; i < FaceSize; i++)
        {
            for (int j = 0; j < FaceSize; j++)
            {
                Tiles[i, j].Display(x + j * TileWidth, y + i * TileHeight);
            }
        }
        
        Console.ResetColor();
    }
    
    public void RotateClockwise()
    {
        // Corners
        (Tiles[0, 0], Tiles[0, 2], Tiles[2, 2], Tiles[2, 0]) = (Tiles[2, 0], Tiles[0, 0], Tiles[0, 2], Tiles[2, 2]);

        // Edges
        (Tiles[1, 0], Tiles[0, 1], Tiles[1, 2], Tiles[2, 1]) = (Tiles[2, 1], Tiles[1, 0], Tiles[0, 1], Tiles[1, 2]);
    }
}