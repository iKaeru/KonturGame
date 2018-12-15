using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Robot
    {
        public Texture2D Texture { get; }
        private Vector2 position;
        public float Speed { get; }

        public Robot(Texture2D texture, float positionX, float positionY)
        {
            Texture = texture;
            position = new Vector2(positionX, positionY);
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

        public void checkDirection(float scale, GraphicsDeviceManager graphics)
        {
            position.X = Math.Min(Math.Max(Texture.Width / 2 * scale, position.X),
                graphics.PreferredBackBufferWidth - Texture.Width / 2 * scale);
            position.Y = Math.Min(Math.Max(Texture.Height / 2 * scale, position.Y),
                graphics.PreferredBackBufferHeight - Texture.Height / 2 * scale);
        }
    }
}