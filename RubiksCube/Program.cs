namespace RubiksCube;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rubik's Cube - CTRL+C to leave");
        Console.WriteLine("F - Front, B - Back, R - Right, L - Left, U - Up, D - Down (Shift for anti-clockwise)");

        Cube cube = new Cube(3, 5);
        
        while (true)
        {
            cube.Display();
            
            // Read the key pressed, and do not print the character in the console
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
        }
    }
}