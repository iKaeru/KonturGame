using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public static class Constants
    {
        public const int FieldCellWidth = 104;
        public const int FieldCellHeight = 104;
        public const int WindowWidth = FieldCellWidth * 10;
        public const int WindowHeight = FieldCellHeight * 6;

        public static Texture2D RobotTexture;
        public static Texture2D BoxTexture;
        public static Texture2D BoxPlaceTexture;
        public static Texture2D WallTexture;
        public static Texture2D BackGround;
        public static Background background;
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SokobanGame : Game
    {
        private DrawController drawController;
        
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
            graphics.PreferredBackBufferWidth = Constants.WindowWidth;
            graphics.PreferredBackBufferHeight = Constants.WindowHeight;
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

            Constants.RobotTexture = Content.Load<Texture2D>("Robot_1");
            Constants.BoxTexture = Content.Load<Texture2D>("Box");
            Constants.BoxPlaceTexture = Content.Load<Texture2D>("Place_for_box");
            Constants.WallTexture = Content.Load<Texture2D>("Wall");   
            Constants.BackGround = Content.Load<Texture2D>("BackGround");
            Constants.background = new Background(Constants.BackGround);
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

//            robot.Move(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            drawController.DrawScene(spriteBatch);

            base.Draw(gameTime);
        }
    }
}