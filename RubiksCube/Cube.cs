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
        
        Top.Display(3 * TileWidth, 3);
        Bottom.Display(3 * TileWidth, 6 * TileHeight + 3);
        Front.Display(3 * TileWidth, 3 * TileHeight + 3);
        Back.Display(9 * TileWidth, 3 * TileHeight + 3);
        Left.Display(0, 3 * TileHeight + 3);
        Right.Display(6 * TileWidth, 3 * TileHeight + 3);
    }
    
    public void F()
    {
        Front.RotateClockwise();
    }
    
    public void B()
    {
        Back.RotateClockwise();
    }

    public void R()
    {
        Right.RotateClockwise();
    }

    public void L()
    {
        Left.RotateClockwise();
    }

    public void U()
    {
        Top.RotateClockwise();
    }

    public void D()
    {
        Bottom.RotateClockwise();
    }
    
    public void FPrime() { F(); F(); F(); }
    public void BPrime() { B(); B(); B(); }
    public void RPrime() { R(); R(); R(); }
    public void LPrime() { L(); L(); L(); }
    public void UPrime() { U(); U(); U(); }
    public void DPrime() { D(); D(); D(); }
}