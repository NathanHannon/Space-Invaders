using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;

namespace Space_Invaders.Shared
{
    public class Button : BaseObject
    {
        public EventHandler ClickButton;
        public string ButtonText;
        private SpriteFont Font;
        public const float buttonScaleX = 100f;
        public const float buttonScaleY = 75f;

        public Button(Texture2D texture, Vector2 position, Vector2 scale, string text, string objectTag) : base(texture, position, scale, objectTag)
        {
            IsCollidable = false;
            ButtonText = text;
            Font = ContentLoader.GetFont("Fonts/Regular");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, GetRectangle(), Color.White);
            spriteBatch.DrawString(Font, ButtonText, FontPosition(), Color.White);
        }

        public override void Update()
        {
            if (CheckMouseIntersect() && MouseController.MouseButtonDown(0))
            {
                ClickButton.Invoke(this, new EventArgs()); //button click event
            }
        }

        private Vector2 FontPosition()
        {
            Vector2 middlePoint = new Vector2(Position.X + Scale.X / 2, Position.Y + Scale.Y / 2);
            Vector2 textSize = Font.MeasureString(ButtonText);
            Vector2 textPosition = new Vector2((int)(middlePoint.X - textSize.X), (int)(middlePoint.Y) - textSize.Y);
            return textPosition;
        }

        private bool CheckMouseIntersect()
        {
            Vector2 mousePosition = MouseController.GetMousePosition();
            Rectangle mouseRectangle = new Rectangle((int)mousePosition.X, (int)mousePosition.Y, 1, 1);
            return mouseRectangle.Intersects(GetRectangle());
        }
    }
}
