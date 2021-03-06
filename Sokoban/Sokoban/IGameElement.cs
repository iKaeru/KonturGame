using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public interface IGameElement
    {
        Texture2D Texture { get; }
        void Draw(SpriteBatch spriteBatch);
        Vector2 Position();
    }
}