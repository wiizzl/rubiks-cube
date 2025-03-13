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
        
        (Top.Tiles[2, 0], Top.Tiles[2, 1], Top.Tiles[2, 2], Right.Tiles[0, 0], Right.Tiles[1, 0], Right.Tiles[2, 0], Bottom.Tiles[0, 2], Bottom.Tiles[0, 1], Bottom.Tiles[0, 0], Left.Tiles[2, 2], Left.Tiles[1, 2], Left.Tiles[0, 2]) = 
        (Left.Tiles[2, 2], Left.Tiles[1, 2], Left.Tiles[0, 2], Top.Tiles[2, 0], Top.Tiles[2, 1], Top.Tiles[2, 2], Right.Tiles[0, 0], Right.Tiles[1, 0], Right.Tiles[2, 0], Bottom.Tiles[0, 2], Bottom.Tiles[0, 1], Bottom.Tiles[0, 0]);
    }

    public void B()
    {
        Back.RotateClockwise();
        
        (Top.Tiles[0, 2], Top.Tiles[0, 1], Top.Tiles[0, 0], Left.Tiles[0, 0], Left.Tiles[1, 0], Left.Tiles[2, 0], Bottom.Tiles[2, 0], Bottom.Tiles[2, 1], Bottom.Tiles[2, 2], Right.Tiles[2, 2], Right.Tiles[1, 2], Right.Tiles[0, 2]) = 
        (Right.Tiles[2, 2], Right.Tiles[1, 2], Right.Tiles[0, 2], Top.Tiles[0, 2], Top.Tiles[0, 1], Top.Tiles[0, 0], Left.Tiles[0, 0], Left.Tiles[1, 0], Left.Tiles[2, 0], Bottom.Tiles[2, 0], Bottom.Tiles[2, 1], Bottom.Tiles[2, 2]);
    }

    public void R()
    {
        Right.RotateClockwise();
        
        (Top.Tiles[0, 2], Top.Tiles[1, 2], Top.Tiles[2, 2], Front.Tiles[0, 2], Front.Tiles[1, 2], Front.Tiles[2, 2], Bottom.Tiles[0, 2], Bottom.Tiles[1, 2], Bottom.Tiles[2, 2], Back.Tiles[2, 0], Back.Tiles[1, 0], Back.Tiles[0, 0]) = 
        (Back.Tiles[2, 0], Back.Tiles[1, 0], Back.Tiles[0, 0], Top.Tiles[0, 2], Top.Tiles[1, 2], Top.Tiles[2, 2], Front.Tiles[0, 2], Front.Tiles[1, 2], Front.Tiles[2, 2], Bottom.Tiles[0, 2], Bottom.Tiles[1, 2], Bottom.Tiles[2, 2]);
    }

    public void L()
    {
        Left.RotateClockwise();
        
        (Top.Tiles[0, 0], Top.Tiles[1, 0], Top.Tiles[2, 0], Back.Tiles[2, 2], Back.Tiles[1, 2], Back.Tiles[0, 2], Bottom.Tiles[0, 0], Bottom.Tiles[1, 0], Bottom.Tiles[2, 0], Front.Tiles[0, 0], Front.Tiles[1, 0], Front.Tiles[2, 0]) = 
        (Front.Tiles[0, 0], Front.Tiles[1, 0], Front.Tiles[2, 0], Top.Tiles[0, 0], Top.Tiles[1, 0], Top.Tiles[2, 0], Back.Tiles[2, 2], Back.Tiles[1, 2], Back.Tiles[0, 2], Bottom.Tiles[0, 0], Bottom.Tiles[1, 0], Bottom.Tiles[2, 0]);
    }

    public void U()
    {
        Top.RotateClockwise();
        
        (Front.Tiles[0, 0], Front.Tiles[0, 1], Front.Tiles[0, 2], Right.Tiles[0, 0], Right.Tiles[0, 1], Right.Tiles[0, 2], Back.Tiles[0, 0], Back.Tiles[0, 1], Back.Tiles[0, 2], Left.Tiles[0, 0], Left.Tiles[0, 1], Left.Tiles[0, 2]) = 
        (Left.Tiles[0, 0], Left.Tiles[0, 1], Left.Tiles[0, 2], Front.Tiles[0, 0], Front.Tiles[0, 1], Front.Tiles[0, 2], Right.Tiles[0, 0], Right.Tiles[0, 1], Right.Tiles[0, 2], Back.Tiles[0, 0], Back.Tiles[0, 1], Back.Tiles[0, 2]);
    }

    public void D()
    {
        Bottom.RotateClockwise();
        (Front.Tiles[2, 0], Front.Tiles[2, 1], Front.Tiles[2, 2], Left.Tiles[2, 0], Left.Tiles[2, 1], Left.Tiles[2, 2], Back.Tiles[2, 0], Back.Tiles[2, 1], Back.Tiles[2, 2], Right.Tiles[2, 0], Right.Tiles[2, 1], Right.Tiles[2, 2]) = 
        (Right.Tiles[2, 0], Right.Tiles[2, 1], Right.Tiles[2, 2], Front.Tiles[2, 0], Front.Tiles[2, 1], Front.Tiles[2, 2], Left.Tiles[2, 0], Left.Tiles[2, 1], Left.Tiles[2, 2], Back.Tiles[2, 0], Back.Tiles[2, 1], Back.Tiles[2, 2]);
    }
    
    public void FPrime() { F(); F(); F(); }
    public void BPrime() { B(); B(); B(); }
    public void RPrime() { R(); R(); R(); }
    public void LPrime() { L(); L(); L(); }
    public void UPrime() { U(); U(); U(); }
    public void DPrime() { D(); D(); D(); }
}