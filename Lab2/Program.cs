using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab2
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (Window3D game_window = new Window3D())
            {
                game_window.Run(32.0, 0.0);
            }
        }
    }
}
