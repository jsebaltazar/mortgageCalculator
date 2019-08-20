using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SoundApp.UI
{
    public class UISystem : MonoBehaviour
    {
        #region Variables
        public Component[] _screens;
        public UIScreen _currentScreen;
        public UIScreen _previousScreen;
        public UIScreen _startScreen;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            _screens = GetComponentsInChildren<UIScreen>(true);

            // Turn off all screens except the start screen so that they don't cover the start screen.
            foreach (var item in _screens)
            {
                if (item.gameObject != _startScreen.gameObject)
                    item.gameObject.SetActive(false);
            }

            if (_startScreen)
            {
                SwitchScreens(_startScreen);
            }
        }

        public void SwitchScreens(UIScreen aScreen)
        {
            if (aScreen)
            {
                if (_currentScreen)
                {
                    // TODO: Close the current screen
                    // _currentScreen.Close();
                    _currentScreen.gameObject.SetActive(false); // Instead of animation.
                    _previousScreen = _currentScreen;
                }
                _currentScreen = aScreen;
                _currentScreen.gameObject.SetActive(true);
            }

        }

        public void GoToPreviousScreen()
        {
            SwitchScreens(_previousScreen);
        }
    }
}
