using SFML.Graphics;

namespace Space_Invader;

public class TextureManager
{
    private const string ASSETS_PATH = "E:/SpaceInvader/SpaceInvader/";
    public static Texture BackgroundTexture;
    public static Texture PlayerTexture;
    public static Texture EnemyTexture;
    public static Texture AtlasExplosionTexture;
    
    static TextureManager()
    {
        BackgroundTexture = new Texture(ASSETS_PATH + "/Backgrounds/gameBG.png");
        PlayerTexture = new Texture(ASSETS_PATH+ "Ships/playerShip2_red.png");
        EnemyTexture = new Texture(ASSETS_PATH + "Enemies/enemyBlue1.png");
        AtlasExplosionTexture = new Texture(ASSETS_PATH+ "Explosions/explosionsAtlas.png");
    } 
}