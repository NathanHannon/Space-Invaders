using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Space_Invaders.Misc;
using Space_Invaders.Scenes;
using Space_Invaders.Shared;

namespace Space_Invaders.Controllers
{
    public class EnemyController
    {
        private ushort _enemyRows;
        private ushort _enemyColumns;
        private const float EnemySpacing = 20f;
        private ushort _visibleEnemies;

        private List<BaseObject> _enemyList = new List<BaseObject>();
        private BaseScene _gameScene;
        /// <summary>
        /// Controls how many enemies are on screen at a given time
        /// </summary>
        /// <param name="enemyRows"></param>
        /// <param name="enemyColumns"></param>
        /// <param name="gameScene"></param>
        public EnemyController(ushort enemyRows, ushort enemyColumns, BaseScene gameScene)
        {
            _enemyRows = enemyRows;
            _enemyColumns = enemyColumns;
            _gameScene = gameScene;
            GenerateEnemies();
        }
        /// <summary>
        /// Generates enemies
        /// </summary>
        private void GenerateEnemies()
        {
            Texture2D enemyTexture = ContentLoader.GetTexture("Images/invader");
            for (ushort rows = 0; rows < _enemyRows; rows++)
            {
                for (byte columns = 0; columns < _enemyColumns; columns++)
                {
                    Vector2 scale = new Vector2(70f, 70f);
                    float xPosition = ((scale.X + EnemySpacing) * rows) + 100f;
                    float yPosition = ((scale.Y + EnemySpacing) * columns) + 100f;
                    BaseObject enemy = new Enemy(enemyTexture, new Vector2(xPosition, yPosition), scale, "Enemy");
                    _gameScene.AddGameObject(enemy);
                    _enemyList.Add(enemy);
                }
            }
        }
        /// <summary>
        /// Periodically counts how many enemies are visible.
        /// If 0, the game ends.
        /// </summary>
        public void EnemyCount()
        {
            _visibleEnemies = 0;
            
            foreach (var currentEnemy in _enemyList)
            {
                if (currentEnemy.IsVisible)
                {
                    _visibleEnemies += 1;
                }
            }
            //Changes scene to main menu when all enemies are gone
            if (_visibleEnemies == 0)
            {
                SceneController.ChangeScene(0);
            }
        }
    }
}
