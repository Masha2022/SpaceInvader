using SFML.Graphics;
using SFML.System;

namespace Space_Invader;

public class TextManager
{
    private const string FONT_PATH = "E:/SpaceInvader/SpaceInvader/Fonts/";
    private Text _text;
    
    public TextManager(string text, string fontName, uint fontSize, Color textColor, Vector2f textPosition)
    {
        var font = new Font(FONT_PATH + fontName + ".ttf");
        _text = new Text(text, font, fontSize);
        _text.FillColor = textColor;
        _text.Position = textPosition;
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(_text);
    }
    
    public void UpdateText(string text)
    {
        _text.DisplayedString = text;
    }
    
    public void ChangeTextPosition(Vector2f position)
    {
        _text.Position = position;
    }
    
    public FloatRect GetGlobalBounds()
    {
        return _text.GetGlobalBounds();
    }
}