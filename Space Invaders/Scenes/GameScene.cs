using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;
using Space_Invaders.Misc;
using Space_Invaders.Shared;

namespace Space_Invaders.Scenes
{
    public class GameScene : BaseScene
    {
        /// <summary>
        /// Game scene. Loads and runs all of the gameobjects for this scene. IE player, enemies, text......
        /// </summary>

        private SpriteFont _font;
        private string _scoreText = "Score: ";
        private BaseObject _player;
        private EnemyController _controller;

        public GameScene(int SceneID) : base(SceneID)
        {
        }

        public override void LoadContent()
        {
            _font = ContentLoader.GetFont("Fonts/Regular");
            _player = new Player(ContentLoader.GetTexture("Images/ship"), new Vector2(200f, 100f), new Vector2(100f, 100f), "Player");
            _player.Position.Y = Global.ScreenHeight - _player.Scale.Y;
            GameObjects.Add(_player);

            GenerateEnemies();
            Global.CursorVisible = false;
        }

        private void GenerateEnemies()
        {
            _controller = new EnemyController(5, 2, this);
        }

        public override void Update()
        {
            _controller.EnemyCount();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _scoreText + Global.Score, new Vector2(100f, 10f), Color.White);
            base.Draw(spriteBatch);
        }
    }
}
