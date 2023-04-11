using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Graphics
{
    public class Triangle
    {
        // Fields
        private VertexBuffer vertexBuffer;

        // Constructor
        public Triangle(GraphicsDevice graphicsDevice)
        {
            VertexPositionColor[] triangleVertices = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(0, 1, -1.1f), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(-1, -1, -1.1f), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(1, -1, -1.1f), Color.Blue);

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), triangleVertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(triangleVertices);
        }

        // Methods
        public void Draw(GraphicsDevice graphicsDevice, BasicEffect basicEffect)
        {
            graphicsDevice.SetVertexBuffer(vertexBuffer);

            // Enable vertex colors for the triangle
            basicEffect.VertexColorEnabled = true;

            // Apply the basic effect
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            }
        }
    }
}
