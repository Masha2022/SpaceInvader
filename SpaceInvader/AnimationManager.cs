using SFML.Graphics;

namespace Space_Invader;

public class AnimationManager
{
    private List<ExplosionAnimation> _explosionAnimations = new List<ExplosionAnimation>();

    public void Update()
    {
        for (var i = 0; i < _explosionAnimations.Count; i++)
        {
            var explosionAnimation = _explosionAnimations[i];
            explosionAnimation.Update();

            if (explosionAnimation.IsAnimationFinished())
            {
                _explosionAnimations.Remove(explosionAnimation);
            }
        }
    }

    public void Draw(RenderWindow window)
    {
        for (int i = 0; i < _explosionAnimations.Count; i++)
        {
            _explosionAnimations[i].Draw(window);
        }
    }

    public void AddNewExplosion(ExplosionAnimation explosion)
    {
        _explosionAnimations.Add(explosion);
    }
}