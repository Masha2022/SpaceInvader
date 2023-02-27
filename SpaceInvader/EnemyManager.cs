using SFML.Graphics;

namespace Space_Invader;

public class EnemyManager
{
    private const int SPAWN_COOLDOWN = 20;
    public List<Enemy> Enemies = new List<Enemy>();
    private int _spawnCooldownTimer;
    
    private void SpawnEnemy()
    {
        _spawnCooldownTimer++;

        if (_spawnCooldownTimer < SPAWN_COOLDOWN)
        {
            return;
        }
        
        var enemy = new Enemy();
        Enemies.Add(enemy);
        _spawnCooldownTimer = 0;
    }
    
    public void Update()
    {
        SpawnEnemy();

        foreach (var enemy in Enemies)
        {
            enemy.Update();
        }
    }
    
    public void Draw(RenderWindow window)
    {
        foreach (var enemy in Enemies)
        {
            enemy.Draw(window);
        }
    }
}