using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    public class Camera
    {
        // Fields
        private float pitch;
        private float yaw;
        private Matrix rotationMatrix;

        // Properties
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Up { get; set; }
        public Matrix ViewMatrix { get; private set; }
        public Matrix ProjectionMatrix { get; private set; }

        // Constructor
        public Camera(GraphicsDevice graphicsDevice, Vector3 position, Vector3 target, Vector3 up)
        {
            Position = position;
            Target = target;
            Up = up;

            UpdateViewMatrix();
            UpdateProjectionMatrix(graphicsDevice);
            UpdateRotationMatrix();
        }

        // Methods
        public void Move(Vector3 delta)
        {
            Vector3 transformedDelta = Vector3.Transform(delta, rotationMatrix);
            Position += transformedDelta;
            Target += transformedDelta;
            UpdateViewMatrix();
        }

        public void Rotate(float pitchDelta, float yawDelta)
        {
            pitch -= pitchDelta;
            yaw -= yawDelta;

            pitch = MathHelper.Clamp(pitch, -MathHelper.PiOver2, MathHelper.PiOver2);

            UpdateRotationMatrix();

            Vector3 forward = Vector3.Transform(Vector3.Forward, rotationMatrix);
            Target = Position + forward;

            UpdateViewMatrix();
        }

        private void UpdateViewMatrix()
        {
            ViewMatrix = Matrix.CreateLookAt(Position, Target, Up);
        }

        private void UpdateProjectionMatrix(GraphicsDevice graphicsDevice)
        {
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45), 
                graphicsDevice.Viewport.AspectRatio, 
                0.1f, 
                100f);
        }

        private void UpdateRotationMatrix()
        {
            rotationMatrix = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);
        }
    }
}
