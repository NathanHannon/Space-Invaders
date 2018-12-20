using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Space_Invaders.Controllers
{
    public static class MouseController
    {
        private static MouseState _previousMouse;
        private static MouseState _currentMouse;
        private static Vector2 _mousePosition;

        /// <summary>
        /// Updates which keys are pressed/released
        /// </summary>
        public static void UpdateInput()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            _mousePosition.X = _currentMouse.Position.X;
            _mousePosition.Y = _currentMouse.Position.Y;
        }

        public static bool MouseButtonDown(int index) //LMB = 0, RMB = 1;
        {
            if (_currentMouse.LeftButton == ButtonState.Pressed &&
                _previousMouse.LeftButton == ButtonState.Released && index == 0)
            {
                //left
                return true;
            }

            if (_currentMouse.RightButton == ButtonState.Pressed &&
                _previousMouse.RightButton == ButtonState.Released && index == 1)
            {
                //right
                return true;
            }

            return false;

        }

        public static bool MouseButtonUp(int index) //LMB = 0, RMB = 1;
        {
            if (_currentMouse.LeftButton == ButtonState.Released &&
                _previousMouse.LeftButton == ButtonState.Pressed && index == 0)
            {
                //left
                return true;
            }

            if (_currentMouse.RightButton == ButtonState.Released &&
                _previousMouse.RightButton == ButtonState.Pressed && index == 1)
            {
                //right
                return true;
            }

            return false;

        }

        public static Vector2 GetMousePosition()
        {
            return _mousePosition;
        }
    }
}