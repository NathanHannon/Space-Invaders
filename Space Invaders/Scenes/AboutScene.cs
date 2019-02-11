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
            spriteBatch.DrawString(_titleFont, "Space Invaders", new Vector2(320, 40f), Color.White);
            spriteBatch.DrawString(_spriteFont, "Nathan Hannon", new Vector2(320f, 80f), Color.White);
            base.Draw(spriteBatch);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            SceneController.ChangeScene(0);
        }
    }
}
