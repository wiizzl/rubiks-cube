namespace RubiksCube;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rubik's Cube - CTRL+C to leave");
        Console.WriteLine("F - Front, B - Back, R - Right, L - Left, U - Up, D - Down (Shift for anti-clockwise, N to reset, M to shuffle)");

        Cube cube = new Cube(3, 5);
        
        while (true)
        {
            cube.Display();
            
            // Read the key pressed, and do not print the character in the console
            ConsoleKeyInfo readKey = Console.ReadKey(true);
             
            bool shiftPressed = readKey.Modifiers.HasFlag(ConsoleModifiers.Shift);
            
            switch (readKey.Key)
            {
                case ConsoleKey.F: 
                    cube.Delay(500);
                    if (shiftPressed) cube.FPrime(); else cube.F();
                    break;
                case ConsoleKey.B: 
                    cube.Delay(500);
                    if (shiftPressed) cube.BPrime(); else cube.B();
                    break;
                case ConsoleKey.R:
                    cube.Delay(500);
                    if (shiftPressed) cube.RPrime(); else cube.R();
                    break;
                case ConsoleKey.L:
                    cube.Delay(500);
                    if (shiftPressed) cube.LPrime(); else cube.L();
                    break;
                case ConsoleKey.U:
                    cube.Delay(500);
                    if (shiftPressed) cube.UPrime(); else cube.U();
                    break;
                case ConsoleKey.D:
                    cube.Delay(500);
                    if (shiftPressed) cube.DPrime(); else cube.D();
                    break;
                case ConsoleKey.N:
                    cube.Delay(500);
                    cube.Reset();
                    break;
                case ConsoleKey.M:
                    cube.Delay(500);
                    cube.Shuffle(new Random().Next(5));
                    break;
            }
        }
    }
}