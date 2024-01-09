using OpenTK.Input;
using System;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab2
{
    class Menu
    {
        public void trigger(KeyboardState thisKeyboard)
        {
            if (thisKeyboard[Key.H])
            {
                show();
            }
        }

        public void show()
        {
            Console.Clear();
            Console.WriteLine("            MENU");
            Console.WriteLine("ESC - Quit the application");
            Console.WriteLine("H - Show this menu");
            Console.WriteLine("\n");
            Console.WriteLine(" -- Cube Movement --");
            Console.WriteLine("W - towards");
            Console.WriteLine("S - backwards");
            Console.WriteLine("A - left");
            Console.WriteLine("D - right");
            Console.WriteLine("Q - down");
            Console.WriteLine("E - up");
            Console.WriteLine("\n");
            Console.WriteLine("R - Reset Cube's position");
            Console.WriteLine("G - Generate a new cube in the center");
            Console.WriteLine("\n");
            Console.WriteLine("Change line 14 in Window3D to allow more cubes to render");
        }
    }
}
