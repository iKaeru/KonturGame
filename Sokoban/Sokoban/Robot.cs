using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Robot
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;
        
        public Robot(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }
    }
}