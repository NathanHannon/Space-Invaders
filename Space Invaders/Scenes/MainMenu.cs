using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders.Scenes
{
    public class MainMenu : BaseScene
    {
        public Button playButton;
        public Button helpButton;
        public Button aboutButton;
        public Button quitButton;
        private SpriteFont titleFont;
        private Song backgroundMusic;

        public MainMenu(int SceneID) : base(SceneID)
        {
        }

        public override void LoadContent()
        {
            titleFont = ContentLoader.GetFont("Fonts/Title");
            backgroundMusic = ContentLoader.GetSong("Sounds/song");

            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
        
            //Play Button
            playButton = new Button(ContentLoader.GetTexture("Images/button"), new Vector2(200f, 100f), new Vector2(Button.buttonScaleX, Button.buttonScaleY), "Play", "Button");
            playButton.Position.X = (Global.ScreenWidth / 2f) - (playButton.Scale.X / 2f);
            playButton.ClickButton += PlayButton_Click;

            GameObjects.Add(playButton);

            Global.CursorVisible = true;
            Global.Score = 0;
            
            //Help Button
            helpButton = new Button(ContentLoader.GetTexture("Images/button"), new Vector2(200f, 200f), new Vector2(Button.buttonScaleX, Button.buttonScaleY), "Help", "Button");
            helpButton.Position.X = (Global.ScreenWidth / 2f) - (helpButton.Scale.X / 2f);
            helpButton.ClickButton += HelpButton_Click;

            GameObjects.Add(helpButton);

            Global.CursorVisible = true;
            Global.Score = 0;

            //About Button
            aboutButton = new Button(ContentLoader.GetTexture("Images/button"),  new Vector2(200f, 300f), new Vector2(Button.buttonScaleX, Button.buttonScaleY), "About", "Button");
            aboutButton.Position.X = (Global.ScreenWidth / 2f) - (aboutButton.Scale.X / 2f);
            aboutButton.ClickButton += AboutButton_Click;

            GameObjects.Add(aboutButton);

            Global.CursorVisible = true;
            Global.Score = 0;

            //Quit Button
            quitButton = new Button(ContentLoader.GetTexture("Images/button"), new Vector2(200f, 400f), new Vector2(Button.buttonScaleX, Button.buttonScaleY), "Quit", "Button");
            quitButton.Position.X = (Global.ScreenWidth / 2f) - (quitButton.Scale.X / 2f);
            quitButton.ClickButton += QuitButton_Click;

            GameObjects.Add(quitButton);

            Global.CursorVisible = true;
            Global.Score = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(titleFont, "Space Invaders", new Vector2(320f, 40f), Color.White);

            base.Draw(spriteBatch);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            SceneController.ChangeScene(1);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            SceneController.ChangeScene(2);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            SceneController.ChangeScene(3);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
