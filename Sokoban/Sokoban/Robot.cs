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
        KeyboardState previousKeyState;

        public Robot(Texture2D texture)
        {
            Texture = texture;
            position = new Vector2(Constants.WindowWidth - Constants.FieldCellWidth,
                Constants.WindowHeight - Constants.FieldCellHeight); // todo: add coordinates
            Speed = 500f;
        }

        public Vector2 Position()
        {
            return position;
        }

        public void Move(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            
            if (kstate.IsKeyDown(Keys.Up) && previousKeyState != kstate)
                position.Y -= Constants.FieldCellHeight;

            if (kstate.IsKeyDown(Keys.Down) && previousKeyState != kstate)
                position.Y += Constants.FieldCellHeight;

            if (kstate.IsKeyDown(Keys.Left) && previousKeyState != kstate)
                position.X -= Constants.FieldCellWidth;

            if (kstate.IsKeyDown(Keys.Right) && previousKeyState != kstate)
                position.X += Constants.FieldCellWidth;
            
            previousKeyState = Keyboard.GetState();
            CheckDirection();
        }

        public void CheckDirection() // todo: maybe place in another class
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