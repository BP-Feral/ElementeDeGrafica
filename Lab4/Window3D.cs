using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab4
{
    public class Window3D : GameWindow
    {
        // https://rgbcolorpicker.com/0-1
        
        private CubeV2 cube;
        private Menu menu = new Menu(); // Menu <lab4>
        
        private bool wasRKeyPressed = false;
        private bool wasGKeyPressed = false;
        private bool wasVKeyPressed = false;
        private bool wasHKeyPressed = false;

        public Window3D(int width, int height) : base(width, height)
        {
            cube = new CubeV2();
            menu.show();
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            cube.Init();

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / Height, 0.1f, 100.0f);
            GL.LoadMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 view = Matrix4.LookAt(new Vector3(2, 2, 2), Vector3.Zero, Vector3.UnitY);
            GL.LoadMatrix(ref view);

            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.R) && !wasRKeyPressed)
            {
                cube.ChangeColorRed();
                menu.trigger(input);
                wasRKeyPressed = true;
            }
            else if (!input.IsKeyDown(Key.R))
            {
                wasRKeyPressed = false;
            }

            if (input.IsKeyDown(Key.G) && !wasGKeyPressed)
            {
                cube.ChangeColorGreen();
                menu.trigger(input);
                wasGKeyPressed = true;
            }
            else if (!input.IsKeyDown(Key.G))
            {
                wasGKeyPressed = false;
            }

            if (input.IsKeyDown(Key.V) && !wasVKeyPressed)
            {
                cube.ChangeRandomColor();
                menu.trigger(input);
                menu.random();
                wasVKeyPressed = true;
            }
            else if (!input.IsKeyDown(Key.V))
            {
                wasVKeyPressed = false;
            }

            if (input.IsKeyDown(Key.H) && !wasHKeyPressed)
            {
                menu.trigger(input);
                wasHKeyPressed = true;
            }
            else if (!input.IsKeyDown(Key.H))
            {
                wasHKeyPressed = false;
            }

            base.OnUpdateFrame(e);
        }



        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            cube.Draw();
            SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
