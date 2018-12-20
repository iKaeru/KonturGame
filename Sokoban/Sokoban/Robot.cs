using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Robot : IGameElement, IDynamic
    {
        public Texture2D Texture { get; }
        private Vector2 position;

        public Robot(Texture2D texture, int x, int y)
        {
            Texture = texture;
            position = new Vector2(x, y);
        }

        public Vector2 Position()
        {
            return position;
        }

        public void Move(Vector2 position, DrawController drawController)
        {
            foreach (var gameElement in drawController.Map)
            {
                if (gameElement != null && gameElement.Position() == this.position + position)
                {
                    if (gameElement.Texture == Constants.WallTexture)
                        return;
                    if (gameElement.Texture == Constants.BoxTexture)
                    {
                        var box = gameElement as IDynamic;
                        var boxPosition = (box as IGameElement).Position();
                        box.Move(position, drawController);
                        if ((box as IGameElement).Position() == boxPosition)
                            return;
                    }
                }
            }

            this.position += position;
            CheckDirection();
        }

        public void CheckDirection()
        {
            position.X = Math.Min(Math.Max(0, position.X),
                Constants.WindowWidth - Constants.FieldCellWidth);
            position.Y = Math.Min(Math.Max(0, position.Y),
                Constants.WindowHeight - Constants.FieldCellHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
                new Rectangle((int) Position().X, (int) Position().Y,
                    Constants.FieldCellWidth, Constants.FieldCellHeight),
                Color.White);
        }
    }
}