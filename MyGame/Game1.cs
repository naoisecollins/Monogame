using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Graphics;

namespace MyGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BasicEffect basicEffect;

        Triangle triangle;
        Cube cube;

        Camera camera;
        InputManager inputManager;

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

            camera = new Camera(GraphicsDevice, new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up);
            basicEffect.View = camera.ViewMatrix;
            basicEffect.Projection = camera.ProjectionMatrix;

            triangle = new Triangle(GraphicsDevice);
            cube = new Cube(GraphicsDevice);

            inputManager = new InputManager();
            inputManager.OnMove += camera.Move;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            inputManager.Update(gameTime);

            basicEffect.View = camera.ViewMatrix;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            triangle.Draw(GraphicsDevice, basicEffect);
            cube.Draw(GraphicsDevice, basicEffect);

            base.Draw(gameTime);
        }
    }
}