using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
    public class UISystem : MonoBehaviour
    {
        #region Variables
        [Header("Main Properties")]
        public UIScreen mStartScreen;

        [Header("System Events")]
        public static UnityEvent onSwitchedScreen = new UnityEvent();

        [Header("Fader Properties")]
        public Image mFader;
        public float mFadeInDuration = 1f;
        public float mFadeOutDuration = 1f;

        private Component[] screens = new Component[0];

        private static UIScreen previousScreen;
        public static UIScreen PreviousScreen { get { return previousScreen; } }

        private static UIScreen currentScreen;
        public static UIScreen CurrentScreen { get { return currentScreen; } }
        #endregion


        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UIScreen>(true);
            InitializeScreens();

            if (mStartScreen)
            {
                SwitchScreens(mStartScreen);
            }

            if (mFader)
            {
                mFader.gameObject.SetActive(true);
            }
            FadeIn();
        }
        #endregion



        #region Helper Methods
        public static void SwitchScreens(UIScreen aScreen)
        {
            if(aScreen)
            {
                if (currentScreen)
                {
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }

                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if (onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }
            }
        }

        public void FadeIn()
        {
            if(mFader)
            {
                mFader.CrossFadeAlpha(0f, mFadeInDuration, false);
            }
        }

        public void FadeOut()
        {
            if (mFader)
            {
                mFader.CrossFadeAlpha(1f, mFadeOutDuration, false);
            }
        }

        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreens(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        void InitializeScreens()
        {
            foreach(var screen in screens)
            {
                screen.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}
