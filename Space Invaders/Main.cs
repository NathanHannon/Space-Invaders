using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ContentLoader.Init(this); // Initializes content loader
            Global.ScreenWidth = graphics.PreferredBackBufferWidth; // sets preferred width
            Global.ScreenHeight = graphics.PreferredBackBufferHeight;// sets preferred Height
            SceneController.LoadScenes();//load all the scenes
            SceneController.ChangeScene(Global.FirstScene);//start the first scene in the list          
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
            Global.DelayTime = (float)gameTime.ElapsedGameTime.TotalSeconds; //sets the base delay time
            Global.gameTime = gameTime; // sets global gameTime to local Gametime
            //Updating Inputs
            KeyboardController.UpdateInput();
            MouseController.UpdateInput();
            IsMouseVisible = Global.CursorVisible;
            SceneController.Update(); // updates scene being displayed
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

           SceneController.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
