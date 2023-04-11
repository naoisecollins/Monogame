using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class InputManager
    {
        public delegate void InputAction(Vector3 delta);
        public event InputAction OnMove;
        // Add a new delegate and event
        public delegate void InputRotationAction(float pitchDelta, float yawDelta);
        public event InputRotationAction OnRotate;

// Add a new field for storing the previous mouse state
        private MouseState previousMouseState;    // Add a reference to the GameWindow
    private GameWindow window;

    // Update the constructor to accept a GameWindow parameter
    public InputManager(GameWindow window)
    {
        this.window = window;
    }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float speed = 3f * (float)gameTime.ElapsedGameTime.TotalSeconds; // Reduced from 5f to 3f


            if (keyboardState.IsKeyDown(Keys.W))
            {
                OnMove?.Invoke(new Vector3(0, 0, -speed));
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                OnMove?.Invoke(new Vector3(0, 0, speed));
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                OnMove?.Invoke(new Vector3(-speed, 0, 0));
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                OnMove?.Invoke(new Vector3(speed, 0, 0));
            }
            
             MouseState currentMouseState = Mouse.GetState();
               if (IsMouseWithinWindowBounds(currentMouseState))
        {
             if (previousMouseState != null)
    {
        int deltaX = currentMouseState.X - previousMouseState.X;
        int deltaY = currentMouseState.Y - previousMouseState.Y;

        float rotationSpeed = 0.002f; // Reduced from 0.005f to 0.002f
        OnRotate?.Invoke(deltaY * rotationSpeed, deltaX * rotationSpeed);
    }
    previousMouseState = currentMouseState;
}}
private bool IsMouseWithinWindowBounds(MouseState mouseState)
    {
        int x = mouseState.X;
        int y = mouseState.Y;

        return x >= 0 && x < window.ClientBounds.Width &&
               y >= 0 && y < window.ClientBounds.Height;
    }
}
        }
    
