using OpenTK.Input;
using System;

namespace Pricob
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
            Console.WriteLine("            MENIU");
            Console.WriteLine("ESC - Parasire aplicatie");
            Console.WriteLine("H - Meniu de ajutor");
            Console.WriteLine("\n");
            Console.WriteLine("W - Muta cubul in fata");
            Console.WriteLine("A - Muta cubul la stanga");
            Console.WriteLine("S - Muta cubul in spate");
            Console.WriteLine("D - Muta cubul la dreapta");
            Console.WriteLine("Q - Muta cubul in jos");
            Console.WriteLine("E - Muta cubul in sus");
            Console.WriteLine("\n");
            Console.WriteLine("R - Reseteaza pozitia cubului");
            Console.WriteLine("G - Generate a new cube at 0.0.0");
            Console.WriteLine("\n");
            Console.WriteLine("Modifica Linia 14 in Window3D pentru a afisa mai multe blocuri");
        }
    }
}
