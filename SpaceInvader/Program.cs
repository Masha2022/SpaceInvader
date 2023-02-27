using SFML.Graphics;
using SFML.Window;

namespace Space_Invader;

class Program
{
   static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
        game.ShowGameOverScreen();
    }
}