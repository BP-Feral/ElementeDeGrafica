using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

///
///     github.com/BP-Feral
///     EGC - 2023
///

namespace Lab4
{
    public class CubeV2
    {
        private int vertexBufferObject;
        private int indexBufferObject;


        private int side_color = 10;

        // private int currentFace = 0;

        private Vector3[] cubeVertices =
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // 0
            new Vector3(0.5f, -0.5f, -0.5f),  // 1
            new Vector3(0.5f, 0.5f, -0.5f),   // 2
            new Vector3(-0.5f, 0.5f, -0.5f),  // 3
            new Vector3(-0.5f, -0.5f, 0.5f),  // 4
            new Vector3(0.5f, -0.5f, 0.5f),   // 5
            new Vector3(0.5f, 0.5f, 0.5f),    // 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // 7
        };

        private int[] cubeIndices =
        {
            0, 1, 2, 2, 3, 0, // Front face (vertices 0, 1, 2 and 2, 3, 0)
            5, 4, 7, 7, 6, 5, // Back face (vertices 5, 4, 7 and 7, 6, 5)
            3, 2, 6, 6, 7, 3, // Top face (vertices 3, 2, 6 and 6, 7, 3)
            1, 0, 4, 4, 5, 1, // Bottom face (vertices 1, 0, 4 and 4, 5, 1)
            0, 3, 7, 7, 4, 0, // Left face (vertices 0, 3, 7 and 7, 4, 0)
            1, 5, 6, 6, 2, 1 // Right face (vertices 1, 5, 6 and 6, 2, 1)
        };

        private Vector4[] triangleColors =
        {
            // https://rgbcolorpicker.com/0-1

            // Red
            new Vector4(0.788f, 0.212f, 0.212f, 1.0f),   // Front - triangle 1)
            new Vector4(0.651f, 0.184f, 0.145f, 1.0f),    // Front - triangle 2
            
            // Yellow
            new Vector4(0.749f, 0.851f, 0.192f, 1.0f),   // Left - triangle 1)
            new Vector4(0.855f, 0.941f, 0.376f, 1.0f),   // Left - triangle 2)

            // Blue
            new Vector4(0.227f, 0.129f, 0.62f, 1.0f),   // Top - triangle 1)
            new Vector4(0.302f, 0.2f, 0.722f, 1.0f),   // Top - triangle 2)

            // Purple
            new Vector4(0.596f, 0.318f, 0.769f, 1.0f),   // Bottom? - triangle 1)
            new Vector4(0.435f, 0.184f, 0.588f, 1.0f),   // Bottom? - triangle 2)

            // Green
            new Vector4(0.102f, 0.741f, 0.176f, 1.0f),   // Back? - triangle 2)
            new Vector4(0.216f, 0.549f, 0.255f, 1.0f),   // Back? - triangle 1)

            // Cyan
            new Vector4(0.239f, 0.655f, 0.678f, 1.0f),   // Right - triangle 1)
            new Vector4(0.188f, 0.51f, 0.529f, 1.0f),    // Right - triangle 2)
        };

        public CubeV2()
        {
            //
        }

        public void Init()
        {
            GL.GenBuffers(1, out vertexBufferObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(cubeVertices.Length * Vector3.SizeInBytes), cubeVertices, BufferUsageHint.StaticDraw);

            GL.GenBuffers(1, out indexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(cubeIndices.Length * sizeof(int)), cubeIndices, BufferUsageHint.StaticDraw);
        }

        public void ChangeRandomColor()
        {
            Random rand = new Random();
            int[] possibleNumbers = { 0, 2, 4, 6, 8, 10 };
            int index = rand.Next(possibleNumbers.Length);
            side_color = possibleNumbers[index];

            triangleColors[10] = triangleColors[side_color];
            triangleColors[11] = triangleColors[side_color + 1];
        }


        public void ChangeColorRed()
        {
            triangleColors[10] = new Vector4(0.788f, 0.212f, 0.212f, 1.0f);  // Red
            triangleColors[11] = new Vector4(0.651f, 0.184f, 0.145f, 1.0f);  // Red
        }

        public void ChangeColorGreen()
        {
            triangleColors[10] = new Vector4(0.102f, 0.741f, 0.176f, 1.0f); // Green
            triangleColors[11] = new Vector4(0.216f, 0.549f, 0.255f, 1.0f); // Green
        }

        public void Draw()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferObject);

            for (int i = 0; i < cubeIndices.Length / 3; i++)
            {
                GL.Color4(triangleColors[i]);

                GL.DrawElements(PrimitiveType.Triangles, 3, DrawElementsType.UnsignedInt, i * 3 * sizeof(int));
            }
        }
    }
}
