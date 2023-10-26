using System.Collections.Generic;
using System;

using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;


namespace Pricob
{
    internal class Window3D : GameWindow
    {
        // switch render from 1 to multiple
        private bool multiple = false;

        private bool generated = false;

        private Menu menu = new Menu(); // Menu <lab3>
        private List<Cube> cubes = new List<Cube>(1)
        {
            new Cube()
        };
 
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

            menu.show();

            loadCubes();
        }

        private void loadCubes()
        {
            if (multiple)
            {
                for (int i = 0; i < 40; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        for (int k = 0; k < 40; k++)
                        {
                            cubes.Add(new Cube(i * 20, j * 20, k * 20));
                        }
                    }
                }
            } else
            {
                cubes.Add(new Cube());
            }
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Viewport
            GL.Viewport(0, 0, Width, Height);

            // Perspective
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 1, 2000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            // Camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Logic
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMosue = Mouse.GetState();
            // Close Application
            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }

            if (thisKeyboard[Key.G] && generated == false)
            {
                generated = true;
                cubes.Add(new Cube());
            }
            if (!thisKeyboard[Key.G])
            {
                generated = false;
            }

            // Update Cube position <lab3>
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].updatePos(thisMosue, thisKeyboard); // WASD, QE, R, mouse_x, mouse_y
            }

            // Display Info in console <lab3>
            menu.trigger(thisKeyboard);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Render Cube <lab3>
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].render();
            }
            SwapBuffers();
        }
    }
}