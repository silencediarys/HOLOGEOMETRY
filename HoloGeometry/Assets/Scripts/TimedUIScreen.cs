using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class TimedUIScreen : UIScreen
    {
        #region Variables
        [Header("Timed Screen Properties")]
        public float m_ScreenTime = 4f;
        public UnityEvent onTimeCompleted = new UnityEvent();

        public float startTime;
        #endregion

        #region Helper Methods
        public override void StartScreen()
        {
            base.StartScreen();

            startTime = Time.time;
            StartCoroutine(WaitForTime());
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(m_ScreenTime);

            if(onTimeCompleted != null)
            {
                onTimeCompleted.Invoke();
            }
        }
        #endregion
    }
}
