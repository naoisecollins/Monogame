using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BasicEffect basicEffect;
        Vector3 cameraPosition;
        Matrix viewMatrix;
        Matrix projectionMatrix;

        VertexBuffer vertexBuffer;
        VertexBuffer cubeVertexBuffer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            base.Initialize();

            basicEffect = new BasicEffect(GraphicsDevice);
            cameraPosition = new Vector3(0, 0, 10);
            viewMatrix = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            VertexPositionColor[] triangleVertices = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Blue);

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), triangleVertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(triangleVertices);

            VertexPositionColor[] cubeVertices = CreateCube();
            cubeVertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), cubeVertices.Length, BufferUsage.WriteOnly);
            cubeVertexBuffer.SetData(cubeVertices);
        }

        private VertexPositionColor[] CreateCube()
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

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyboardState = Keyboard.GetState();

            float speed = 5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                cameraPosition.Z -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                cameraPosition.Z += speed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                cameraPosition.X -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                cameraPosition.X += speed;
            }

            viewMatrix = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            basicEffect.View = viewMatrix;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);

            GraphicsDevice.SetVertexBuffer(cubeVertexBuffer);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, CreateCube(), 0, 24, CubeIndices(), 0, 12);

            base.Draw(gameTime);
        }

        private short[] CubeIndices()
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

