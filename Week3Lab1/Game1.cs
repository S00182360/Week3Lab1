using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week3Lab1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        string message, messageFade;
        SpriteFont font;
        byte alpha;
        string[] itemList = { "Item 1", "Item 2", "Item 3", "Item 4" };
        int[] itemYValues = { 0, 0, 0, 0 };
        float itemHeight;
        Vector2 itemSize;
        bool isFading;

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
            font = Content.Load<SpriteFont>("font");
            itemSize = font.MeasureString(itemList[0]);
            //itemHeight = (int)itemSize.Y + 20;

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
            int seconds = gameTime.TotalGameTime.Seconds;
            message = "Time elapsed: " + seconds;
            messageFade = "Message to fade";

            if(alpha == 0)
            {
                isFading = false;
            }
            else if (alpha == 255)
            {
                isFading = true;
            }

            if(isFading)
            {
                alpha--;
            }
            else
            {
                alpha++;
            }




            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Color MessageColour = new Color((byte)255, (byte)255, (byte)255, alpha);
            spriteBatch.DrawString(font, message, new Vector2(0, 0), Color.Wheat);
            spriteBatch.DrawString(font, messageFade, new Vector2(0, 50), MessageColour);
            Vector2 startItemDraw = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            foreach(var item in itemList)
            {
                spriteBatch.DrawString(font, item, startItemDraw, Color.WhiteSmoke);
                itemHeight = font.MeasureString(itemList[0]).Y;
                startItemDraw += new Vector2(0, itemHeight +10);
               
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
