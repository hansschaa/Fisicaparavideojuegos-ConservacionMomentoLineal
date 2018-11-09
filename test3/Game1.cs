using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test3.Desktop
{
    //Dudas:
    //¿El viento afecta en todo momento a las pelotas? si es asi, las movera siempre porque no estamos trabajando con roce estatico
    //

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static float gravity =                9.8f;

        #region "Entities"
        public static PlayerBall playerBall;
        public static Ball enemyBall;
        private static Ball targetBall;
        public static MouseArrow mouseArrow;
        public static WindArrow windArrow;
        #endregion

        #region "Parameters"
        public static int ballRadius =                 9;
        public static int windowWidth =              900;
        public static int windowHeigth =             450;
        public static float frictionCoefficient =    0.5f;
        #endregion


        public Game1()
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
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeigth;
            graphics.ApplyChanges();

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

            playerBall = new PlayerBall(new Vector2(ballRadius*2,graphics.PreferredBackBufferHeight/2), 0, Vector2.Zero, Vector2.Zero, ballRadius,Color.White);
            enemyBall = new Ball(new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight / 2), 0, Vector2.Zero, Vector2.Zero, ballRadius, Color.Yellow);
            targetBall = new Ball(new Vector2(300, 400), 0, Vector2.Zero, Vector2.Zero, ballRadius, Color.Red);
            mouseArrow = new MouseArrow(new Vector2(ballRadius * 4, graphics.PreferredBackBufferHeight / 2), 0,
                                        Vector2.Zero, Vector2.Zero, Content.Load<Texture2D>("arrow"));
            windArrow = new WindArrow(new Vector2(700, 400), 0,
                                       Vector2.Zero, Vector2.Zero, Content.Load<Texture2D>("arrow"));

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            playerBall.Update();
            enemyBall.Update();
            targetBall.Update();
            windArrow.Update(gameTime);

            if (playerBall.playerState == PlayerState.STATIC)
                mouseArrow.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            playerBall.Draw(spriteBatch);
            enemyBall.Draw(spriteBatch);
            targetBall.Draw(spriteBatch);
            windArrow.Draw(spriteBatch);

            if (playerBall.playerState == PlayerState.STATIC)
                mouseArrow.Draw(spriteBatch, Mouse.GetState().Position);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
