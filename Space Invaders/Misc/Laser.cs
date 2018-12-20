using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders.Misc
{
    public class Laser: BaseObject
    {
        private const float _deathDelay = 1f;
        private float _timer;
        private const float _speed = 4f;

        public Laser(Texture2D texture, Vector2 position, Vector2 scale, string objectTag) : base(texture, position, scale, objectTag)
        {

        }

        public override void Update()
        {
            _timer += Global.DelayTime;
            if (_timer>= _deathDelay)
            {
                IsVisible = false;
            }

            Velocity.Y -= _speed;
            Position += Velocity;
            Velocity = Vector2.Zero;

            CollisionCheck();
        }

        private void CollisionCheck()
        {
            foreach (var currentEnemy in SceneController.CurrentScene.GameObjects)
            {
                if (currentEnemy.IsVisible)
                {
                    if (Collision(currentEnemy) && currentEnemy.ObjectTag == "Enemy")
                    {
                        Global.Score += 1;
                        currentEnemy.IsVisible = false;
                        IsVisible = false;
                    }
                }
            }
        }

        private bool Collision(BaseObject baseObject)
        {
            Rectangle laser = GetRectangle();
            Rectangle enemy = baseObject.GetRectangle();
            return laser.Intersects(enemy);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, GetRectangle(), Color.White);
        }
    }
}
