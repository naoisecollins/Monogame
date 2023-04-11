using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class InputManager
    {
        public delegate void InputAction(Vector3 delta);
        public event InputAction OnMove;

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float speed = 5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

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
        }
    }
}
