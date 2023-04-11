using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MySprite
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Color Color { get; set; }
    public float Rotation { get; set; }
    public Vector2 Origin { get; set; }
    public Vector2 Scale { get; set; }
    public SpriteEffects Effects { get; set; }
    public float LayerDepth { get; set; }

    public MySprite(Texture2D texture)
    {
        Texture = texture;
        Position = Vector2.Zero;
        Color = Color.White;
        Rotation = 0f;
        Origin = Vector2.Zero;
        Scale = Vector2.One;
        Effects = SpriteEffects.None;
        LayerDepth = 0f;
    }
}
