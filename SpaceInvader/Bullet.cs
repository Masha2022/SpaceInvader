using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public class Bullet
{
    private const float BULLET_SPEED = 20f;
    private const float BULLET_RADIUS = 3f;
    public CircleShape BulletShape;
    
    public Bullet(Vector2f position)
    {
        BulletShape = new CircleShape(BULLET_RADIUS);
        BulletShape.FillColor = Color.Red;
        BulletShape.Position = position;
    }
    
    public void Update()
    {
        var currentPosition = BulletShape.Position;
        var newPosition = new Vector2f(currentPosition.X, currentPosition.Y - BULLET_SPEED);
        BulletShape.Position = newPosition;
    }
    public bool IsOnScreen()
    {
        return BulletShape.Position.Y > 0;
    }
}