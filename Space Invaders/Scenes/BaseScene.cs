using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Controllers;
using Space_Invaders.Shared;

namespace Space_Invaders.Scenes
{
    public abstract class BaseScene
    {
        public int SceneIndex;
 
        public List<BaseObject> GameObjects = new List<BaseObject>();


        protected BaseScene(int SceneID)
        {
            SceneIndex = SceneID;
            SceneController.AddScene(this);
        }
        /// <summary>
        /// Add Objects to the object list
        /// </summary>
        /// <param name="baseObject"></param>
        public void AddGameObject(BaseObject baseObject)
        {
            GameObjects.Add(baseObject);
        }

        public abstract void LoadContent();
        public void UnloadContent()
        {
            GameObjects.Clear();
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Draw each object in the Game object list as visible.
            foreach (var obj in GameObjects)
            {
                if (obj.IsVisible)
                {
                    obj.Draw(spriteBatch);
                }
            }
        }
        public virtual void Update()
        {
            //Updates object visibility
            foreach (var obj in GameObjects.ToList())
            {
                if (obj.IsVisible)
                {
                    obj.Update();
                }
            }
        }
    }
}
