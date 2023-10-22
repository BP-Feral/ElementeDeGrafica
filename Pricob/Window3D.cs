using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Pricob
{
    internal class Window3D : GameWindow
    {
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.LightBlue);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);


            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Setare Viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // Setare Perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 256);
            GL.LoadMatrix(ref perspective);

            // Setare Camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Cod Logica
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMosue = Mouse.GetState();

            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }

            if (thisKeyboard[Key.H])
            {
                displayHelp();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Cod Render

            SwapBuffers();
        }

        private void displayHelp()
        {
            Console.WriteLine("            MENIU");
            Console.WriteLine("ESC - Parasire aplicatie");
            Console.WriteLine("H - Meniu de ajutor");
        }
    }
}