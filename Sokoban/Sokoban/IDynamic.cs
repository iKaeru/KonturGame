using Microsoft.Xna.Framework;

namespace Sokoban
{
    public interface IDynamic
    {
        void Move(Vector2 position, DrawController drawController);
    }
}