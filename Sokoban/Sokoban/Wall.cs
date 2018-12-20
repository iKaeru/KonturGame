using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Wall : IGameElement
    {
        public Texture2D Texture { get; }
        private Vector2 position;

        public Wall(Texture2D texture, int x, int y)
        {
            Texture = texture;
            position = new Vector2(x, y);
        }
        
        public Vector2 Position()
        {
            return position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
                new Rectangle((int) position.X, (int) position.Y,
                    Constants.FieldCellWidth, Constants.FieldCellHeight),
                Color.White);
        }
    }
}