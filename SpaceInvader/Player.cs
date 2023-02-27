using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invader;

public class Player
{
    private const float PLAYER_SPEED = 4f;
    public Sprite Sprite;

    private ShootManager _shootManager;

    public Player()
    {
        Sprite = new Sprite();
        Sprite.Texture = TextureManager.PlayerTexture;

        var spriteSize = new Vector2f(Sprite.TextureRect.Width, Sprite.TextureRect.Height);
        var screenCenter = new Vector2f(Game.WIDTH / 2f, Game.HEIGHT / 2f);
        var startPosition = screenCenter - spriteSize / 2f;
        Sprite.Position = startPosition;

        _shootManager = new ShootManager(this);
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(Sprite);
        foreach (var bullet in _shootManager.Bullets)
        {
            window.Draw(bullet.BulletShape);
        }
    }

    private void Move()
    {
        bool shouldMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool shouldMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
        bool shouldMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool shouldMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool shouldMove = shouldMoveLeft || shouldMoveRight || shouldMoveUp || shouldMoveDown;

        if (!shouldMove)
        {
            return;
        }

        var position = Sprite.Position;

        if (shouldMoveLeft)
        {
            position.X -= PLAYER_SPEED;
        }

        if (shouldMoveRight)
        {
            position.X += PLAYER_SPEED;
        }

        if (shouldMoveUp)
        {
            position.Y -= PLAYER_SPEED;
        }

        if (shouldMoveDown)
        {
            position.Y += PLAYER_SPEED;
        }

        Sprite.Position = position;
    }

    public void Update()
    {
        Move();
        _shootManager.Shoot();
        _shootManager.UpdateBullets();
    }
    
    public List<Bullet> GetBullets()
    {
        return _shootManager.Bullets;
    }
    
    public void RemoveBullet(Bullet bullet)
    {
        _shootManager.Bullets.Remove(bullet);
    }
}