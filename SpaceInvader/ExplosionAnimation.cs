using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public class ExplosionAnimation
{
    private const float ANIMATION_TIME= 0.2f;
    private const float DELTA_TIME= 0.1f;
    private float _currentAnimationTime;
    private int _currentColumnIndex;
    private int _currentRowIndex;
    private Sprite _sprite;
    private bool _isAnimationFinished;
    
    public ExplosionAnimation(Vector2f position)
    {
        var spawnExplosionPosition = position - ExplosionSpriteAtlas.GetSingleSpriteCenter();
        
        var atlasSprite = ExplosionSpriteAtlas.GetSprite();
        _sprite = new Sprite(atlasSprite);
        _sprite.Position = spawnExplosionPosition;
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
    }
    
    public void Update()
    {
        if (_currentAnimationTime < ANIMATION_TIME)
        {
            _currentAnimationTime += DELTA_TIME;
            return;
        }

        if (_currentRowIndex > ExplosionSpriteAtlas.SPRITE_ATLAS_ROWS)
        {
            _isAnimationFinished = true;
            return;
        }

        _sprite.TextureRect = ExplosionSpriteAtlas.GetSpriteRectangle(_currentRowIndex, _currentColumnIndex);
        
        IncreaseCurrentColumn();
        
        _currentColumnIndex++;
        _currentAnimationTime = 0;
    }
    
    public bool IsAnimationFinished()
    {
        return _isAnimationFinished;
    }
    
    private void IncreaseCurrentColumn()
    {
        if (_currentColumnIndex == ExplosionSpriteAtlas.SPRITE_ATLAS_COLUMNS)
        {
            _currentRowIndex++;
            _currentColumnIndex = 0;
        }
    }
}