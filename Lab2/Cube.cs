using OpenTK;
using OpenTK.Input;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab2
{
    class Cube
    {
        private float cubeSize = 2.0f;
        private Vector3 cubePosition = Vector3.Zero;
        private float moveSpeed = 1.0f;
        private MouseState prevMouseState;

        public Cube() => prevMouseState = Mouse.GetState();
        public Cube(int x, int y, int z) => cubePosition = new Vector3(x, y, z);
        public void updatePos(MouseState thisMouse, KeyboardState thisKeyboard)
        {
            float deltaX = thisMouse.X - prevMouseState.X;
            float deltaY = thisMouse.Y - prevMouseState.Y;

            cubePosition.X += deltaX * 0.1f;
            cubePosition.Y -= deltaY * 0.1f;

            prevMouseState = thisMouse;

            // Handle Inputs
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
        }

        // Force a new position
        public void setPos(Vector3 pos)
        {
            cubePosition = pos;
        }

        // Return position
        public Vector3 getPos()
        {
            return cubePosition;
        }

        // Assemble the cube faces
        public void draw()
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

        // Draw the Cube on screen
        public void render()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();

            //
            GL.Translate(getPos());
            draw();
            //

            GL.PopMatrix();
        }
    }
}
