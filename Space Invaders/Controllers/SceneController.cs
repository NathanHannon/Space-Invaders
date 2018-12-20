using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Scenes;

namespace Space_Invaders.Controllers
{
    public static class SceneController
    {
        /// <summary>
        /// Controls which scene is being displayed
        /// </summary>

        public static BaseScene CurrentScene;
        public static List<BaseScene> Scenes = new List<BaseScene>();

        public static void LoadScenes()
        {
            BaseScene mainMenuScene = new MainMenu(0);
            BaseScene gameScene = new GameScene(1);
            BaseScene helpScene = new HelpScene(2);
            BaseScene aboutScene = new AboutScene(3);
        }

        public static void AddScene(BaseScene scene)
        {
            Scenes.Add(scene);
        }

        public static void ChangeScene(int SceneID)
        {
            CurrentScene?.UnloadContent();//Unloads Current Scene.
            CurrentScene = Scenes[SceneID];//Changes scene based on ID.
            CurrentScene.LoadContent();//Loads New Scene
        }

        public static void Update()
        {
            CurrentScene.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            CurrentScene.Draw(spriteBatch);
        }

    }
}
