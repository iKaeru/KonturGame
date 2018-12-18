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

        public void checkDirection(GraphicsDeviceManager graphics)
        {
            position.X = Math.Min(Math.Max(0, position.X),
                graphics.PreferredBackBufferWidth - 104);
            position.Y = Math.Min(Math.Max(0, position.Y),
                graphics.PreferredBackBufferHeight - 104);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
                new Rectangle((int) Position().X, (int) Position().Y, 104, 104),
                Color.White);
        }
    }
}