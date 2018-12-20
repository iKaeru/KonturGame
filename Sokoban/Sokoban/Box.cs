using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Box : IGameElement, IDynamic
    {
        public Texture2D Texture { get; }
        private Vector2 position;
        private bool boxInPlace;

        public Box(Texture2D texture, int x, int y)
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
            var boxColor = Color.White;
            if (boxInPlace)
                boxColor = Color.Lime;
            spriteBatch.Draw(Texture,
                new Rectangle((int) position.X, (int) position.Y,
                    Constants.FieldCellWidth, Constants.FieldCellHeight),
                boxColor);
        }

        public void Move(Vector2 position, DrawController drawController)
        {
            if (CheckDirection(drawController, position))
                this.position += position;
        }

        public bool CheckDirection(DrawController drawController, Vector2 position)
        {
            foreach (var gameElement in drawController.Map)
            {
                if (gameElement != null && gameElement.Position() == this.position + position)
                {
                    if (gameElement.Texture == Constants.BoxPlaceTexture)
                        boxInPlace = true;

                    if (gameElement.Texture == Constants.WallTexture || gameElement.Texture == Constants.BoxTexture)
                        return false;
                }
            }

            return true;
        }
    }
}