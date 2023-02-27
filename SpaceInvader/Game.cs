using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invader;

public class Game
{
    public const int WIDTH = 640;
    public const int HEIGHT = 480;
    private const string TITLE = "Space Invader";
    private RenderWindow _window;
    private Sprite _background;
    
    private Player _player;
    private EnemyManager _enemyManager;
    
    private AnimationManager _animationManage;
    private CollisionHandler _collisionHandler;
    
    private ScoreManager _scoreManager;
    public Game()
    {
        var mode = new VideoMode(WIDTH,HEIGHT);
        _window = new RenderWindow(mode,TITLE);
        _window.SetVerticalSyncEnabled(true);
        _window.Closed += (_, _) => _window.Close();

        _background = new Sprite();
        _background.Texture = TextureManager.BackgroundTexture;

        _player = new Player();
        _enemyManager = new EnemyManager();
        _animationManage = new AnimationManager();
        _scoreManager = new ScoreManager();
        _collisionHandler = new CollisionHandler(_player, _enemyManager, _animationManage, _scoreManager);
    }
    public void Run()
    {
        while (_window.IsOpen && !_collisionHandler.IsGameOver())
        {
            HandleEvents();
            Update();
            Draw();
        }
    }
    private void HandleEvents()
    {
        _window.DispatchEvents();
    }
    private void Update()
    {
        _player.Update();
        _enemyManager.Update();
        _collisionHandler.Update();
        _animationManage.Update();
        _scoreManager.Update();
    }
    private void Draw()
    {
        _window.Draw(_background);
        _player.Draw(_window);
        _animationManage.Draw(_window);
        _enemyManager.Draw(_window);
        _scoreManager.Draw(_window);
        
        _window.Display();
        
    }
    
    public void ShowGameOverScreen()
    {
        while (_window.IsOpen)
        {
            HandleEvents();
            _window.Clear(Color.Black);
            ShowGameOverText();
            
            _window.Display();
        }
    }
    
    private void ShowGameOverText()
    {
        var gameOverText = new TextManager("Game\nOver", "FreeMonospacedBold", 80, Color.White, new Vector2f(0f, 0f));
        var textBounds = gameOverText.GetGlobalBounds();
        var centerTextPosition = new Vector2f((WIDTH- textBounds.Width) / 2f, (HEIGHT- textBounds.Height) / 2f);
        gameOverText.ChangeTextPosition(centerTextPosition);

        gameOverText.Draw(_window);
    }
}