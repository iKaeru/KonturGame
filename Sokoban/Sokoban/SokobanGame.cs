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
        private Robot robot;
        private Background background;
        private DrawController drawController;
        private Box box; // todo
        private BoxPlace boxPlace;

        private int cellWidth { get; }
        private int cellHeight { get; }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SokobanGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cellWidth = 104;
            cellHeight = 104;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = cellWidth*10;
            graphics.PreferredBackBufferHeight = cellHeight*6;
            graphics.ApplyChanges();
            drawController = new DrawController();
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

            robot = new Robot(Content.Load<Texture2D>("Robot_1"),
                graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            background = new Background(Content.Load<Texture2D>("BackGround"),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            box = new Box(Content.Load<Texture2D>("Box"));
            boxPlace = new BoxPlace(Content.Load<Texture2D>("Place_for_box"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
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

            robot.Move(gameTime);
            robot.checkDirection(graphics);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            drawController.DrawScene(spriteBatch, background, robot, box, boxPlace);

            base.Draw(gameTime);
        }
    }
}