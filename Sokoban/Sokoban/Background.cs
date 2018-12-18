using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Background : IGameElement
    {
        public Texture2D Texture { get; }

        public Background(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
                new Rectangle(0, 0, Constants.WindowWidth, Constants.WindowHeight),
                Color.White);
        }
    }
}