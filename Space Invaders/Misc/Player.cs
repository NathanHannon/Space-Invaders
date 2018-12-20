using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders.Misc
{
    public class Player : BaseObject
    {
        private const float Speed = 3f;
        private const float ShootDelay = 0.5f;
        private float _timer;

        public Player(Texture2D texture, Vector2 position, Vector2 scale, string objectTag) : base(texture, position, scale, objectTag)
        {
            IsVisible = true;
        }

        public override void Update()
        {
            PlayerController();
            Position += Velocity * Speed;
            Velocity = Vector2.Zero;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, GetRectangle(), Color.White);
        }

        private void PlayerController()
        {
            if (KeyboardController.GetKey(Keys.A) || KeyboardController.GetKey(Keys.Left))
            {
                Velocity.X -= 1;
            }

            if (KeyboardController.GetKey(Keys.D) || KeyboardController.GetKey(Keys.Right))
            {
                Velocity.X += 1;
            }

            _timer += Global.DelayTime;
            if (KeyboardController.GetKey(Keys.Space) && _timer >= ShootDelay)
            {
                Shoot();
                _timer = 0f;
            }

            CheckCollision();
        }

        private void Shoot()
        {
            SoundEffect laserSound = ContentLoader.GetSfx("Sounds/laserfire");
            float laserX = (Scale.X / 2f) + Position.X;
            float laserY = Position.Y;
            Laser lsr = new Laser(ContentLoader.GetTexture("Images/laser"), new Vector2(laserX, laserY), new Vector2(10f, 20f), "Laser");
            SceneController.CurrentScene.AddGameObject(lsr);
            laserSound.Play();
        }

        private void CheckCollision()
        {
            for (int i = 0; i < SceneController.CurrentScene.GameObjects.Count; i++)
            {
                BaseObject currentEnemy = SceneController.CurrentScene.GameObjects[i];
                if (currentEnemy.ObjectTag == "Enemy" && currentEnemy.IsVisible)
                {
                    if (Collision(currentEnemy))
                    {
                        //Quits to main menu upon game over
                        SceneController.ChangeScene(0);
                    }
                }
            }
        }

        private bool Collision(BaseObject baseObject)
        {
            Rectangle laser = GetRectangle();
            //Gets Enemy rectangle
            Rectangle enemy = baseObject.GetRectangle();

            return laser.Intersects(enemy);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          