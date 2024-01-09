using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab4
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new Window3D(800, 600))
            {
                game.Run(60.0);
            }
        }
    }
}