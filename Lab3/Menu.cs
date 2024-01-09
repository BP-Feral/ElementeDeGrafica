using OpenTK.Input;
using System;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab3
{
    class Menu
    {
        int current_lab;
        public void trigger(KeyboardState thisKeyboard)
        {
            if (thisKeyboard[Key.H])
            {
                show();
            }
        }

        public void setLab(int lab)
        {
            this.current_lab = lab;
        }
        public void show()
        {
            Console.Clear();
            Console.WriteLine("            MENU");
            Console.WriteLine("ESC - Quit the application");
            Console.WriteLine("H - Show this menu");
            Console.WriteLine("\n");
        }
    }
}
