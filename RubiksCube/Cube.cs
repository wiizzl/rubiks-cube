namespace RubiksCube;

public class Cube
{
    public Face Top { get; set; }
    public Face Bottom { get; set; }
    public Face Front { get; set; }
    public Face Back { get; set; }
    public Face Left { get; set; }
    public Face Right { get; set; }
    
    public int TileHeight { get; set; }
    public int TileWidth { get; set; }

    public Cube(int tileHeight, int tileWidth)
    {
        Top = new Face("W", tileHeight, tileWidth);
        Bottom = new Face("Y", tileHeight, tileWidth);
        Front = new Face("R", tileHeight, tileWidth);
        Back = new Face("O", tileHeight, tileWidth);
        Left = new Face("G", tileHeight, tileWidth);
        Right = new Face("B", tileHeight, tileWidth);
        
        TileHeight = tileHeight;
        TileWidth = tileWidth;
    }

    public void Display()
    {
        Console.CursorVisible = false;
        
        Top.Display(3 * TileWidth, 0);
        Bottom.Display(0, 3 * TileHeight);
        Front.Display(3 * TileWidth, 3 * TileHeight);
        Back.Display(6 * TileWidth, 3 * TileHeight);
        Left.Display(9 * TileWidth, 3 * TileHeight);
        Right.Display(3 * TileWidth, 6 * TileHeight);
    }
    
    public void F()
    {
        // Rotate the front face clockwise
        Front.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] topRow = new Tile[Face.FaceSize];
        Tile[] bottomRow = new Tile[Face.FaceSize];
        Tile[] leftCol = new Tile[Face.FaceSize];
        Tile[] rightCol = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            topRow[i] = Top.Tiles[Face.FaceSize - 1, i];
            bottomRow[i] = Bottom.Tiles[0, i];
            leftCol[i] = Left.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1];
            rightCol[i] = Right.Tiles[i, 0];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Top.Tiles[Face.FaceSize - 1, i] = leftCol[i];
            Bottom.Tiles[0, i] = rightCol[i];
            Left.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1] = bottomRow[i];
            Right.Tiles[i, 0] = topRow[i];
        }
    }
    
    public void B()
    {
        // Rotate the back face clockwise
        Back.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] topRow = new Tile[Face.FaceSize];
        Tile[] bottomRow = new Tile[Face.FaceSize];
        Tile[] leftCol = new Tile[Face.FaceSize];
        Tile[] rightCol = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            topRow[i] = Top.Tiles[0, Face.FaceSize - 1 - i];
            bottomRow[i] = Bottom.Tiles[Face.FaceSize - 1, Face.FaceSize - 1 - i];
            leftCol[i] = Left.Tiles[i, 0];
            rightCol[i] = Right.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Top.Tiles[0, Face.FaceSize - 1 - i] = rightCol[i];
            Bottom.Tiles[Face.FaceSize - 1, Face.FaceSize - 1 - i] = leftCol[i];
            Left.Tiles[i, 0] = topRow[i];
            Right.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1] = bottomRow[i];
        }
    }

    public void R()
    {
        // Rotate the right face clockwise
        Right.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] topCol = new Tile[Face.FaceSize];
        Tile[] bottomCol = new Tile[Face.FaceSize];
        Tile[] frontCol = new Tile[Face.FaceSize];
        Tile[] backCol = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            topCol[i] = Top.Tiles[i, Face.FaceSize - 1];
            bottomCol[i] = Bottom.Tiles[i, Face.FaceSize - 1];
            frontCol[i] = Front.Tiles[i, Face.FaceSize - 1];
            backCol[i] = Back.Tiles[Face.FaceSize - 1 - i, 0];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Top.Tiles[i, Face.FaceSize - 1] = frontCol[i];
            Bottom.Tiles[i, Face.FaceSize - 1] = backCol[i];
            Front.Tiles[i, Face.FaceSize - 1] = bottomCol[i];
            Back.Tiles[Face.FaceSize - 1 - i, 0] = topCol[i];
        }
    }

    public void L()
    {
        // Rotate the left face clockwise
        Left.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] topCol = new Tile[Face.FaceSize];
        Tile[] bottomCol = new Tile[Face.FaceSize];
        Tile[] frontCol = new Tile[Face.FaceSize];
        Tile[] backCol = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            topCol[i] = Top.Tiles[i, 0];
            bottomCol[i] = Bottom.Tiles[i, 0];
            frontCol[i] = Front.Tiles[i, 0];
            backCol[i] = Back.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Top.Tiles[i, 0] = backCol[i];
            Bottom.Tiles[i, 0] = frontCol[i];
            Front.Tiles[i, 0] = topCol[i];
            Back.Tiles[Face.FaceSize - 1 - i, Face.FaceSize - 1] = bottomCol[i];
        }
    }

    public void U()
    {
        // Rotate the top face clockwise
        Top.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] frontRow = new Tile[Face.FaceSize];
        Tile[] backRow = new Tile[Face.FaceSize];
        Tile[] leftRow = new Tile[Face.FaceSize];
        Tile[] rightRow = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            frontRow[i] = Front.Tiles[0, i];
            backRow[i] = Back.Tiles[0, i];
            leftRow[i] = Left.Tiles[0, i];
            rightRow[i] = Right.Tiles[0, i];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Front.Tiles[0, i] = rightRow[i];
            Back.Tiles[0, i] = leftRow[i];
            Left.Tiles[0, i] = frontRow[i];
            Right.Tiles[0, i] = backRow[i];
        }
    }

    public void D()
    {
        // Rotate the bottom face clockwise
        Bottom.RotateClockwise();

        // Rotate the adjacent faces
        Tile[] frontRow = new Tile[Face.FaceSize];
        Tile[] backRow = new Tile[Face.FaceSize];
        Tile[] leftRow = new Tile[Face.FaceSize];
        Tile[] rightRow = new Tile[Face.FaceSize];

        for (int i = 0; i < Face.FaceSize; i++)
        {
            frontRow[i] = Front.Tiles[Face.FaceSize - 1, i];
            backRow[i] = Back.Tiles[Face.FaceSize - 1, i];
            leftRow[i] = Left.Tiles[Face.FaceSize - 1, i];
            rightRow[i] = Right.Tiles[Face.FaceSize - 1, i];
        }

        for (int i = 0; i < Face.FaceSize; i++)
        {
            Front.Tiles[Face.FaceSize - 1, i] = leftRow[i];
            Back.Tiles[Face.FaceSize - 1, i] = rightRow[i];
            Left.Tiles[Face.FaceSize - 1, i] = backRow[i];
            Right.Tiles[Face.FaceSize - 1, i] = frontRow[i];
        }
    }
    
    public void FPrime() { F(); F(); F(); }
    public void BPrime() { B(); B(); B(); }
    public void RPrime() { R(); R(); R(); }
    public void LPrime() { L(); L(); L(); }
    public void UPrime() { U(); U(); U(); }
    public void DPrime() { D(); D(); D(); }
}