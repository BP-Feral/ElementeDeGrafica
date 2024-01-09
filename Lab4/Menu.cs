using OpenTK.Input;
using System;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab4
{
    class Menu
    {
        public void trigger(KeyboardState thisKeyboard)
        {
            if (thisKeyboard[Key.H])
            {
                show();
            }

            if (thisKeyboard[Key.G])
            {
                show();
                Console.WriteLine("Color changed to Green");
            }

            if (thisKeyboard[Key.R])
            {
                show();
                Console.WriteLine("Color changed to Red");
            }
        }


        public void show()
        {
            Console.Clear();
            Console.WriteLine("            MENU");
            Console.WriteLine("ESC - Quit the application");
            Console.WriteLine("H - Show this menu");
            Console.WriteLine("\n");
            Console.WriteLine("R - Change to color Red");
            Console.WriteLine("G - Change to color Green");
            Console.WriteLine("V - Change to a random color");
            Console.WriteLine("\n");
        }
        public void random()
        {
            Console.Clear();
            Console.WriteLine("            MENU");
            Console.WriteLine("ESC - Quit the application");
            Console.WriteLine("H - Show this menu");
            Console.WriteLine("\n");
            Console.WriteLine("R - Change to color Red");
            Console.WriteLine("G - Change to color Green");
            Console.WriteLine("V - Change to a random color");
            Console.WriteLine("\n");
            Console.WriteLine("Changed to a random color");
            Console.WriteLine("( ... sometimes it hits the same color so please press again ... )");
        }
    }
}
