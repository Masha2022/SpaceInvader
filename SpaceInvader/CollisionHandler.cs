namespace Space_Invader;

public class CollisionHandler
{
    private Player _player;
    private EnemyManager _enemyManager;
    private  AnimationManager _animationManager;
    private ScoreManager _scoreManager;

    public CollisionHandler(Player player, EnemyManager enemyManager, AnimationManager animationManager, ScoreManager scoreManager)
    {
        _player = player;
        _enemyManager = enemyManager;
        _animationManager = animationManager;
        _scoreManager = scoreManager;
    }
   
    private bool WasCollisionEnemyWithBullet(Enemy enemy)
    {
        var enemySprite = enemy.Sprite;
        var bullets = _player.GetBullets();

        for (int i = 0; i < bullets.Count; i++)
        {
            var bullet = bullets[i];
            if (enemySprite.GetGlobalBounds().Intersects(bullet.BulletShape.GetGlobalBounds()))
            {
                var explosion = new ExplosionAnimation(bullet.BulletShape.Position);
                _animationManager.AddNewExplosion(explosion);
                _scoreManager.IncreaseScore();
                
                _player.RemoveBullet(bullet);
                return true;
            }
        }

        return false;
    }
    
    private void RemoveDeadEnemies()
    {
        for (var i = 0; i < _enemyManager.Enemies.Count; i++)
        {
            var enemies = _enemyManager.Enemies;
            var enemyPosition = enemies[i].Sprite.Position;
        
            if (enemyPosition.Y > Game.HEIGHT || WasCollisionEnemyWithBullet(enemies[i]))
            {
                enemies.RemoveAt(i);
            }
        }
    }
    
    public void Update()
    {
        RemoveDeadEnemies();
    }
    
    private bool WasCollisionEnemyWithPlayer(Enemy enemy)
    {
        var enemySprite = enemy.Sprite;
        var playerSprite = _player.Sprite;
        if (playerSprite.GetGlobalBounds().Intersects(enemySprite.GetGlobalBounds()))
        {
            return true;
        }

        return false;
    }
    
    public bool IsGameOver()
    {
        for (var i = 0; i < _enemyManager.Enemies.Count; i++)
        {
            var enemies = _enemyManager.Enemies;

            if (WasCollisionEnemyWithPlayer(enemies[i]))
            {
                return true;
            }
        }

        return false;
    }
}