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
                Tiles[i, j] = new Tile(color, Tile.GetColor(color), tileHeight, tileWidth);
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
        Tile[,] newTiles = new Tile[FaceSize, FaceSize];
        
        for (int i = 0; i < FaceSize; i++)
        {
            for (int j = 0; j < FaceSize; j++)
            {
                newTiles[j, FaceSize - 1 - i] = Tiles[i, j];
            }
        }
        
        Tiles = newTiles;
    }
}