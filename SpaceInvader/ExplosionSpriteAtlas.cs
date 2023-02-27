using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public static class ExplosionSpriteAtlas
{
    public const int SPRITE_ATLAS_ROWS= 4;
    public const int SPRITE_ATLAS_COLUMNS= 4;

    private static int _singleSpriteWidth;
    private static int _singleSpriteHeight;
    private static Sprite _spriteAtlas;
    
    static ExplosionSpriteAtlas()
    {
        var atlasExplosionTexture = TextureManager.AtlasExplosionTexture;
        _spriteAtlas = new Sprite(atlasExplosionTexture);

        _singleSpriteWidth = (int)(atlasExplosionTexture.Size.X /SPRITE_ATLAS_ROWS);
        _singleSpriteHeight = (int)(atlasExplosionTexture.Size.Y /SPRITE_ATLAS_COLUMNS);
    }
    
    public static IntRect GetSpriteRectangle(int rowIndex, int columnIndex)
    {
        return _spriteAtlas.TextureRect = new IntRect(columnIndex * _singleSpriteWidth, rowIndex * _singleSpriteHeight, _singleSpriteWidth, _singleSpriteHeight);
    }
    
    public static Sprite GetSprite()
    {
        return _spriteAtlas;
    }
    
    public static Vector2f GetSingleSpriteCenter()
    {
        return new Vector2f(_singleSpriteWidth, _singleSpriteHeight) / 2f;
    }
}