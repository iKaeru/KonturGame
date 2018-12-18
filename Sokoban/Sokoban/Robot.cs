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
        public float Speed { get; }

        public Robot(Texture2D texture)
        {
            Texture = texture;
            position = new Vector2(Constants.WindowWidth / 2 - Constants.FieldCellWidth / 2,
                Constants.WindowHeight / 2 - Constants.FieldCellHeight / 2); // todo: add coordinates
            Speed = 500f;
        }

        public Vector2 Position()
        {
            return position;
        }

        public void Move(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                position.Y -= Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                position.Y += Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                position.X -= Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                position.X += Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void checkDirection() // todo: maybe place in another class
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