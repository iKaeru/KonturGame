using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class BoxPlace : IGameElement
    {
        public Texture2D Texture { get; }

        public BoxPlace(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(Texture,
                new Rectangle(x, y, Constants.FieldCellWidth, Constants.FieldCellHeight),
                Color.White);
        }
    }
}