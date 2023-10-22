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
        // Valori Cub laboratorul 2
        private float cubeSize = 2.0f;
        private Vector3 cubePosition = Vector3.Zero;
        
        private MouseState prevMouseState;

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

            prevMouseState = Mouse.GetState();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Setare Viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // Setare Perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
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

            // Miscare cub cu mouse Laboratorul 2
            int deltaX = thisMosue.X - prevMouseState.X;
            int deltaY = thisMosue.Y - prevMouseState.Y;

            cubePosition.X += deltaX * 0.1f;
            cubePosition.Y -= deltaY * 0.1f;

            prevMouseState = thisMosue;

            // Miscare cub cu tastatura Laboratorul 2
            float moveSpeed = 1.0f;
            if (thisKeyboard[Key.W])
            {
                cubePosition.Z -= moveSpeed;
            }

            if (thisKeyboard[Key.S])
            {
                cubePosition.Z += moveSpeed;
            }

            if (thisKeyboard[Key.A])
            {
                cubePosition.X -= moveSpeed;
            }

            if (thisKeyboard[Key.D])
            {
                cubePosition.X += moveSpeed;
            }

            if (thisKeyboard[Key.Q])
            {
                cubePosition.Y -= moveSpeed;
            }

            if (thisKeyboard[Key.E])
            {
                cubePosition.Y += moveSpeed;
            }

            if (thisKeyboard[Key.R])
            {
                cubePosition = Vector3.Zero;
            }

            // Meniu ajutor
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

            ///
            /// Cod Render
            ///
            
            // Render Cube laboratorul 2
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Translate(cubePosition);
            RenderCube();
            GL.PopMatrix();

            SwapBuffers();
        }

        private void RenderCube()
        {
            GL.Begin(PrimitiveType.Quads);


            GL.Color3(Color.Silver);
            GL.Vertex3(-cubeSize, -cubeSize, -cubeSize);
            GL.Vertex3(-cubeSize, cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, -cubeSize, -cubeSize);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-cubeSize, -cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, -cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, -cubeSize, cubeSize);
            GL.Vertex3(-cubeSize, -cubeSize, cubeSize);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-cubeSize, -cubeSize, -cubeSize);
            GL.Vertex3(-cubeSize, -cubeSize, cubeSize);
            GL.Vertex3(-cubeSize, cubeSize, cubeSize);
            GL.Vertex3(-cubeSize, cubeSize, -cubeSize);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-cubeSize, -cubeSize, cubeSize);
            GL.Vertex3(cubeSize, -cubeSize, cubeSize);
            GL.Vertex3(cubeSize, cubeSize, cubeSize);
            GL.Vertex3(-cubeSize, cubeSize, cubeSize);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-cubeSize, cubeSize, -cubeSize);
            GL.Vertex3(-cubeSize, cubeSize, cubeSize);
            GL.Vertex3(cubeSize, cubeSize, cubeSize);
            GL.Vertex3(cubeSize, cubeSize, -cubeSize);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(cubeSize, -cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, cubeSize, -cubeSize);
            GL.Vertex3(cubeSize, cubeSize, cubeSize);
            GL.Vertex3(cubeSize, -cubeSize, cubeSize);


            GL.End();
        }


        private void displayHelp()
        {
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


        }
    }
}