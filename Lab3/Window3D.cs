using System.Collections.Generic;
using System;

using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab3
{
    internal class Window3D : GameWindow
    {
        private Menu menu = new Menu(); // Menu <lab3>

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
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Viewport
            GL.Viewport(0, 0, Width, Height);

            // Perspective
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Logic
            KeyboardState thisKeyboard = Keyboard.GetState();
            
            // Close Application
            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            DrawAxes();

            // Swap buffers after drawing
            SwapBuffers();
        }

        public void DrawAxes()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Draw the axes
            GL.Begin(PrimitiveType.Lines);

            GL.Color3(1.0f, 1.0f, 0.2f);

            GL.LineWidth(2.0f);

            // GL.PointSize(4.0f);

            GL.Vertex3(-1.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 0.0f);

            GL.Vertex3(0.0f, -1.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);

            GL.Vertex3(0.0f, 0.0f, -1.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);

            GL.End();
        }
    }
}