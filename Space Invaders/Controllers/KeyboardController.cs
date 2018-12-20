using Microsoft.Xna.Framework.Input;

namespace Space_Invaders.Controllers
{
    public static class KeyboardController
    {
        private static KeyboardState _currentKeyboard;
        private static KeyboardState _previousKeyboard;

        /// <summary>
        /// Updates which keys are pressed/released
        /// </summary>
        public static void UpdateInput()
        {
            _previousKeyboard = _currentKeyboard;
            _currentKeyboard = Keyboard.GetState();

            if (GetKeyDown(Keys.Escape)) //returns to the main menu when escape is pressed;
            {
                SceneController.ChangeScene(0);
            }
        }

        public static bool GetKeyDown(Keys key)
        {
            return _currentKeyboard.IsKeyDown(key) && _previousKeyboard.IsKeyUp(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return _currentKeyboard.IsKeyUp(key) && _previousKeyboard.IsKeyDown(key);
        }

        public static bool GetKey(Keys key)
        {
            return _previousKeyboard.IsKeyDown(key) && _currentKeyboard.IsKeyDown(key);
        }
    }
}
