using System;
using System.Collections;
using JetBrains.Annotations;

namespace MartianChild.Utility.Time
{
    public class Timer
    {
        /// <summary>
        /// How much time is remaining on a timer.
        /// </summary>
        public float timeRemaining { get; private set; }

        /// <summary>
        /// Whether or not a timer is running.
        /// </summary>
        public bool isRunning { get; private set; }
        
        private bool kill = false;

        /// <summary>
        /// Stops a timer.
        /// </summary>
        public void Kill()
        {
            kill = true;
            isRunning = false;
            timeRemaining = 0;
        }

        /// <summary>
        /// Starts timer coroutine.
        /// <param name="durationInSeconds"> How many seconds the timer will run. </param>
        /// <param name="onUpdate"> Calls this action every tick of the timer. </param>
        /// <param name="onTimerEnd"> Calls this action on timer end. </param>
        /// <param name="RemoveTimerFromDict"> Action to remove the timer from cref="MartianChild.Utility.TimersManager.runningTimers" on timer completion. </param>
        /// </summary>
        public IEnumerator StartTimerCoroutine(float durationInSeconds, [CanBeNull] Action onUpdate, [CanBeNull] Action onTimerEnd, Action RemoveTimerFromDict)
        {
            isRunning = true;
            float timeElapsed = 0;
            while(timeElapsed <= durationInSeconds)
            {
                if (kill)
                {
                    RemoveTimerFromDict.Invoke();
                    yield break;
                }
                
                onUpdate?.Invoke();
                timeElapsed += UnityEngine.Time.deltaTime;
                yield return null;
            }  
            onTimerEnd?.Invoke();
            RemoveTimerFromDict.Invoke();
            isRunning = false;
        }
    }
}