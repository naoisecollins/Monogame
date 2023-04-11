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
        // Add these fields to the Camera class
private float pitch;
private float yaw;

// Add a method to rotate the camera
public void Rotate(float pitchDelta, float yawDelta)
{
    pitch -= pitchDelta;
    yaw -= yawDelta;

    pitch = MathHelper.Clamp(pitch, -MathHelper.PiOver2, MathHelper.PiOver2);

    Vector3 forward = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw));
    Target = Position + forward;

    UpdateViewMatrix();
}
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
    Matrix rotationMatrix = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);
    Vector3 transformedDelta = Vector3.Transform(delta, rotationMatrix);
    Position += transformedDelta;
    Target += transformedDelta;
    UpdateViewMatrix();
}
    }
}
