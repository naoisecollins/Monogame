using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Graphics
{
    public class Cube
    {
        private VertexBuffer cubeVertexBuffer;
        private IndexBuffer cubeIndexBuffer;

        public Cube(GraphicsDevice graphicsDevice)
        {
            VertexPositionColor[] cubeVertices = CreateCubeVertices();
            cubeVertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), cubeVertices.Length, BufferUsage.WriteOnly);
            cubeVertexBuffer.SetData(cubeVertices);

            short[] cubeIndices = CreateCubeIndices();
            cubeIndexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits, cubeIndices.Length, BufferUsage.WriteOnly);
            cubeIndexBuffer.SetData(cubeIndices);
        }

        public void Draw(GraphicsDevice graphicsDevice, BasicEffect basicEffect)
{
    graphicsDevice.SetVertexBuffer(cubeVertexBuffer);
    graphicsDevice.Indices = cubeIndexBuffer;
    basicEffect.CurrentTechnique.Passes[0].Apply();

    // Update this line to use the new method
    graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 12);
}


        private VertexPositionColor[] CreateCubeVertices()
            {
            Vector3[] cubeVertices = new Vector3[]
            {
                // Top face
                new Vector3(-1, 1, -1),
                new Vector3(1, 1, -1),
                new Vector3(1, 1, 1),
                new Vector3(-1, 1, 1),

                // Bottom face
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, -1, 1),
                new Vector3(-1, -1, 1),

                // Left face
                new Vector3(-1, -1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(-1, 1, 1),
                new Vector3(-1, 1, -1),

                // Right face
                new Vector3(1, -1, -1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
                new Vector3(1, 1, -1),

                // Front face
                new Vector3(-1, -1, -1),
                                new Vector3(1, -1, -1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, -1),

                // Back face
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
                new Vector3(-1, 1, 1),
            };

            Color[] faceColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan,
                Color.Magenta,
            };

            VertexPositionColor[] vertices = new VertexPositionColor[6 * 6];
            for (int i = 0, face = 0; face < 6; face++)
            {
                for (int j = 0; j < 4; j++, i++)
                {
                    vertices[i] = new VertexPositionColor(cubeVertices[i], faceColors[face]);
                }
            }

            return vertices;
        }

        private short[] CreateCubeIndices()
         {
            short[] indices = new short[]
            {
                0, 1, 2, 0, 2, 3, // Top face
                4, 5, 6, 4, 6, 7, // Bottom face
                8, 9, 10, 8, 10, 11, // Left face
                12, 13, 14, 12, 14, 15, // Right face
                16, 17, 18, 16, 18, 19, // Front face
                20, 21, 22, 20, 22, 23, // Back face
            };

            return indices;
        }
    }
}