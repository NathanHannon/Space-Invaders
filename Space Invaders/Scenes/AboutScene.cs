using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders.Scenes
{
    public class AboutScene : BaseScene
    {
        private SpriteFont _spriteFont;
        private SpriteFont _titleFont;
        public Button backButton;
        public AboutScene(int SceneID) : base(SceneID)
        {
        }

        public override void LoadContent()
        {
            _titleFont = ContentLoader.GetFont("Fonts/Title");
            _spriteFont = ContentLoader.GetFont("Fonts/Regular");

            backButton = new Button(ContentLoader.GetTexture("Images/button"), new Vector2(200f, 200f), new Vector2(Button.buttonScaleX, Button.buttonScaleY), "Back", "Button");
            backButton.Position.X = (Global.ScreenWidth / 2f) - (backButton.Scale.X / 2f);
            backButton.ClickButton += BackButton_Click;

            GameObjects.Add(backButton);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_titleFont, "About", new Vector2(375f, 160f), Color.White);
            spriteBatch.DrawString(_spriteFont, "A remake of the classic game 'Space Invaders'.", new Vector2(187.5f, 200f), Color.White);
            spriteBatch.DrawString(_spriteFont, "Music From OpenGameArt.org by user 'maxstack'.", new Vector2(187.5f, 220f), Color.White);
            spriteBatch.DrawString(_spriteFont, "Sound Effects From OpenGameArt.org by user 'Triki Minut'.", new Vector2(187.5f, 240f), Color.White);
            base.Draw(spriteBatch);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            SceneController.ChangeScene(0);
        }
    }
}
