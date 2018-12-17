using Microsoft.Xna.Framework;

namespace Sokoban
{
    public interface IDynamic
    {
        Vector2 Position();
        void Move(GameTime gameTime);
    }
}