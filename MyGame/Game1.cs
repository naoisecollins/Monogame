using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Graphics;

namespace MyGame
{
    public class Game1 : Game
    {
        // Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BasicEffect basicEffect;
        private Triangle triangle;
        private Cube cube;
        private Camera camera;
        private InputManager inputManager;

        // Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
        }

        // Methods
        protected override void Initialize()
        {
            base.Initialize();

            // Initialize basic effect
            basicEffect = new BasicEffect(GraphicsDevice);

            // Initialize camera
            camera = new Camera(GraphicsDevice, new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up);
            basicEffect.View = camera.ViewMatrix;
            basicEffect.Projection = camera.ProjectionMatrix;

            // Initialize objects
            triangle = new Triangle(GraphicsDevice);
            cube = new Cube(GraphicsDevice);

            // Initialize input manager
            inputManager = new InputManager(Window);
            inputManager.OnMove += camera.Move;
            inputManager.OnRotate += camera.Rotate;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Mouse.SetPosition(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update input manager
            inputManager.Update(gameTime);

            // Update basic effect
            basicEffect.View = camera.ViewMatrix;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Set states
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            // Draw objects
            triangle.Draw(GraphicsDevice, basicEffect);
            cube.Draw(GraphicsDevice, basicEffect);

            base.Draw(gameTime);
        }
    }
}
