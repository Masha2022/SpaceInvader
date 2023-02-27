using SFML.System;
using SFML.Window;

namespace Space_Invader;

public class ShootManager
{
    private const int SHOOTING_COOLDOWN = 15;
    public List<Bullet> Bullets = new List<Bullet>();
    private int _shootingCooldownTimer;
    private Player _player;


    public ShootManager(Player player)
    {
        _player = player;
    }
    
    public void Shoot()
    {
        if (!Keyboard.IsKeyPressed(Keyboard.Key.Space))
        {
            return;
        }

        if (_shootingCooldownTimer >= SHOOTING_COOLDOWN)
        {
            var playerCenterX = new Vector2f(_player.Sprite.TextureRect.Width / 2f, 0f);
            var spawnBulletPosition = _player.Sprite.Position + playerCenterX;
            var bullet = new Bullet(spawnBulletPosition);
            Bullets.Add(bullet);
            _shootingCooldownTimer = 0;
        }

        else
        {
            _shootingCooldownTimer++;
        }
    }

    public void UpdateBullets()
    {
        for (var i = 0; i < Bullets.Count; i++)
        {
            var bullet = Bullets[i];
            bullet.Update();

            if (!bullet.IsOnScreen())
            {
                Bullets.RemoveAt(i);
            }
        }
    }
}