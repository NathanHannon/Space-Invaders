using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Invaders.Shared
{
    public class Global
    {
        public static GameTime gameTime;
        public static int ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static int ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static float DelayTime;
        public static ushort Score;
        public static byte FirstScene = 0;
        public static bool CursorVisible = false;
    }
}
