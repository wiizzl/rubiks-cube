﻿namespace RubiksCube;

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
    
    private List<string> moveHistory = [];

    public Cube(int tileHeight, int tileWidth)
    {
        TileHeight = tileHeight;
        TileWidth = tileWidth;

        Reset();
    }
    
    public void Reset()
    {
        Top = new Face("W", TileHeight, TileWidth);
        Bottom = new Face("Y", TileHeight, TileWidth);
        Front = new Face("R", TileHeight, TileWidth);
        Back = new Face("O", TileHeight, TileWidth);
        Left = new Face("G", TileHeight, TileWidth);
        Right = new Face("B", TileHeight, TileWidth);
    }

    public void Display(int delay)
    {
        Console.CursorVisible = false;
        
        Top.Display(3 * TileWidth, 3);
        Bottom.Display(3 * TileWidth, 6 * TileHeight + 3);
        Front.Display(3 * TileWidth, 3 * TileHeight + 3);
        Back.Display(9 * TileWidth, 3 * TileHeight + 3);
        Left.Display(0, 3 * TileHeight + 3);
        Right.Display(6 * TileWidth, 3 * TileHeight + 3);
        
        Thread.Sleep(delay);
    }
    
    
    public void Shuffle(int numberOfMoves)
    {
        List<string> moves = new List<string>
        {
            "F", "FPrime", "B", "BPrime", "R", "RPrime", "L", "LPrime", "U", "UPrime", "D", "DPrime"
        };

        for (int i = 0; i < numberOfMoves; i++)
        {
            string move = moves[new Random().Next(moves.Count)];
            moveHistory.Add(move);
            
            switch (move)
            {
                case "F": F(); break;
                case "FPrime": FPrime(); break;
                case "B": B(); break;
                case "BPrime": BPrime(); break;
                case "R": R(); break;
                case "RPrime": RPrime(); break;
                case "L": L(); break;
                case "LPrime": LPrime(); break;
                case "U": U(); break;
                case "UPrime": UPrime(); break;
                case "D": D(); break;
                case "DPrime": DPrime(); break;
            }
            
            double t = (double)i / (numberOfMoves - 1);
            double easeInOut = 0.5 * (1 - Math.Cos(Math.PI * t));
            int delay = (int)(300 * easeInOut);

            Display(delay);
        }
    }

    public void Unshuffle()
    {
        int numberOfMoves = moveHistory.Count;
        for (int i = 0; i < numberOfMoves; i++)
        {
            string move = moveHistory[moveHistory.Count - 1];
            moveHistory.RemoveAt(moveHistory.Count - 1);

            switch (move)
            {
                case "F": FPrime(); break;
                case "FPrime": F(); break;
                case "BPrime": B(); break;
                case "B": BPrime(); break;
                case "R": RPrime(); break;
                case "RPrime": R(); break;
                case "L": LPrime(); break;
                case "LPrime": L(); break;
                case "U": UPrime(); break;
                case "UPrime": U(); break;
                case "D": DPrime(); break;
                case "DPrime": D(); break;
            }

            double t = (double)i / (numberOfMoves - 1);
            double easeInOut = 0.5 * (1 - Math.Cos(Math.PI * t));
            int delay = (int)(300 * easeInOut);

            Display(delay);
        }
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