using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Invaders.Shared
{
    public abstract class BaseObject
    {

        /// <summary>
        /// Base class that everything being draw/updated will inherit from 
        /// </summary>


        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Scale;
        public Vector2 Velocity;
        public string ObjectTag; //Designator for object types to help me differentiate.
        public bool IsCollidable; //Flags enemy collision
        public bool IsVisible = true; //Flags enemy visibility

        public BaseObject(Texture2D texture, Vector2 position, Vector2 scale, string objectTag)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            ObjectTag = objectTag;
            Velocity = Vector2.Zero;
        }
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public Rectangle GetRectangle()
        {
            Rectangle r = new Rectangle((int)Position.X, (int)Position.Y, (int)Scale.X, (int)Scale.Y);
            return r;
        }
    }
}
