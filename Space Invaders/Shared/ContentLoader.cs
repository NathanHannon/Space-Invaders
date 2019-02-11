using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Space_Invaders.Shared
{
    public static class ContentLoader
    {
        private static Main _game;

        public static void Init(Main game)
        {
            _game = game;
        }
        /// <summary>
        /// Gets Sprite Textures
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Texture2D GetTexture(string path)
        {
            Texture2D texture = _game.Content.Load<Texture2D>(path);
            return texture;
        }
        /// <summary>
        /// Gets Fonts
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SpriteFont GetFont(string path)
        {
            SpriteFont font = _game.Content.Load<SpriteFont>(path);
            return font;
        }
        /// <summary>
        /// Gets Background Music
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Song GetSong(string path)
        {
            Song backgroundSong = _game.Content.Load<Song>(path);
            return backgroundSong;
        }
        /// <summary>
        /// Gets Sound Effects
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SoundEffect GetSfx(string path)
        {
            SoundEffect soundEffect = _game.Content.Load<SoundEffect>(path);
            return soundEffect;
        }
    }
}
