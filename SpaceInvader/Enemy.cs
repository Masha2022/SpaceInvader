using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public class Enemy
{
    private const float ENEMY_SPEED= 5f;
    public Sprite Sprite;
    private Random _random = new Random();
    
    public Enemy()
    {
        Sprite = new Sprite();
        Sprite.Texture = TextureManager.EnemyTexture;
        var randomPositionX = _random.Next(0, Game.WIDTH);
        var spawnPosition = new Vector2f(randomPositionX, -Game.HEIGHT);
        Sprite.Position = spawnPosition;
    }
    
    public void Update()
    {
        Sprite.Position += new Vector2f(0, ENEMY_SPEED);
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(Sprite);
    }
}