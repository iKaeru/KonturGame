using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Background : IGameElement
    {
        public Texture2D Texture { get; }
        private int windowWidth;
        private int windowHeight;

        public Background(Texture2D texture, int windowWidth, int windowHeight)
        {
            Texture = texture;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, 
                new Rectangle(0, 0, windowWidth, windowHeight), 
                Color.White);
        }
    }
}