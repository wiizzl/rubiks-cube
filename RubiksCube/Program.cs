namespace RubiksCube;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Jeu du Rubik's Cube - CTRL+C pour quitter");
        Console.WriteLine("F - Avant, B - Derrière, R - Droite, L - Gauche, U - Haut, D - Bas (Shift pour l'anti-horraire)");

        Cube cube = new Cube(3, 5);
        
        do
        {
            cube.Display();
            
            ConsoleKeyInfo readKey = Console.ReadKey(true);
            
            bool shiftPressed = readKey.Modifiers == ConsoleModifiers.Shift;
            
            switch (readKey.Key)
            {
                case ConsoleKey.F: 
                    if (shiftPressed) cube.FPrime(); else cube.F();
                    break;
                case ConsoleKey.B: 
                    if (shiftPressed) cube.BPrime(); else cube.B();
                    break;
                case ConsoleKey.R: 
                    if (shiftPressed) cube.RPrime(); else cube.R();
                    break;
                case ConsoleKey.L: 
                    if (shiftPressed) cube.LPrime(); else cube.L();
                    break;
                case ConsoleKey.U: 
                    if (shiftPressed) cube.UPrime(); else cube.U();
                    break;
                case ConsoleKey.D: 
                    if (shiftPressed) cube.DPrime(); else cube.D();
                    break;
            } 
        } while (true);
    }
}