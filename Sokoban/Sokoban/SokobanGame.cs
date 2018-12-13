using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SokobanGame : Game
    {
        private Robot robot; // todo
        
        Texture2D robotTexture; // todo
        Vector2 robotPosition; // todo
        float robotSpeed; // todo
        private float scale;// todo ???

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SokobanGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            scale = 0.5f;
            robotPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);
            robotSpeed = 500f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

//            robot = new Robot(Content.Load<Texture2D>("Robot_1"), 
//                new Vector2(graphics.PreferredBackBufferWidth / 2,
//                    graphics.PreferredBackBufferHeight / 2));
            robotTexture = Content.Load<Texture2D>("Robot_1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                robotPosition.Y -= robotSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                robotPosition.Y += robotSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                robotPosition.X -= robotSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                robotPosition.X += robotSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;

//            if (robotPosition.X > this.GraphicsDevice.Viewport.Width)
//                robotPosition.X = 0;
//            if (robotPosition.X < 0)
//                robotPosition.X = this.GraphicsDevice.Viewport.Width;
//            if (robotPosition.Y > this.GraphicsDevice.Viewport.Height)
//                robotPosition.Y = 0;
//            if (robotPosition.Y < 0)
//                robotPosition.Y = this.GraphicsDevice.Viewport.Height;
            robotPosition.X = Math.Min(Math.Max(robotTexture.Width / 2 * scale, robotPosition.X),
                graphics.PreferredBackBufferWidth - robotTexture.Width / 2*scale);
            robotPosition.Y = Math.Min(Math.Max(robotTexture.Height / 2 * scale, robotPosition.Y),
                graphics.PreferredBackBufferHeight - robotTexture.Height / 2*scale);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(
                robotTexture,
                robotPosition,
                null,
                Color.White,
                0f,
                new Vector2(robotTexture.Width / 2, robotTexture.Height / 2),
                new Vector2(scale, scale),
                SpriteEffects.None,
                0f
            );

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}