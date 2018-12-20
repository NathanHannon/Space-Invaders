using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Shared;

namespace Space_Invaders.Misc
{
    public class Enemy : BaseObject
    {
        private Vector2 _movement = new Vector2(1f, 0f);
        private float _enemySpeed = 1f;

        public Enemy(Texture2D texture, Vector2 position, Vector2 scale, string objectTag) : base(texture, position, scale, objectTag)
        {
        }

        public override void Update()
        {
            if (Position.X <= 50f || Position.X >= 700f)
            {
                _movement.X *= -1f;
                _movement.Y += 10f;
                _enemySpeed += 0.5f;
            }

            Position += _movement * _enemySpeed;
            _movement.Y = 0f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, GetRectangle(), Color.White);
        }
    }
}
