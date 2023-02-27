using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public class ScoreManager
{
    private const int SCORE_PER_ENEMY= 1;
    private int _score;
    private Vector2f _scoreLabelPosition = new Vector2f(10f, 10f);
    private TextManager _textManager;
    
    public ScoreManager()
    {
        _textManager = new TextManager($"Score: {_score}","FreeMonospaced", 25, Color.White, _scoreLabelPosition);
    }
    
    private void UpdateScoreLabel()
    {
        _textManager.UpdateText($"Score: {_score}");
    }
    
    public void Update()
    {
        UpdateScoreLabel();
    }
    
    public void Draw(RenderWindow window)
    {
        _textManager.Draw(window);
    }
    
    public void IncreaseScore()
    {
        _score +=SCORE_PER_ENEMY;
    }
}