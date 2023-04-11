using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Up { get; set; }

        public Matrix ViewMatrix { get; private set; }
        public Matrix ProjectionMatrix { get; private set; }

        public Camera(GraphicsDevice graphicsDevice, Vector3 position, Vector3 target, Vector3 up)
        {
            Position = position;
            Target = target;
            Up = up;

            UpdateViewMatrix();
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), graphicsDevice.Viewport.AspectRatio, 0.1f, 100f);
        }

        public void UpdateViewMatrix()
        {
            ViewMatrix = Matrix.CreateLookAt(Position, Target, Up);
        }

        public void Move(Vector3 delta)
        {
            Position += delta;
            UpdateViewMatrix();
        }
    }
}
