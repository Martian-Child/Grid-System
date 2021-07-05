using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MartianChild.Utility.Design_Patterns;
using UnityEngine;

namespace MartianChild.Utility.Time
{
    public class TimersManager : Singleton<MonoBehaviour>
    {
        /// <summary>
        /// Stores timers by guid.
        /// </summary>
        public Dictionary<Guid, Timer> runningTimers;

        private void Awake()
        {
            runningTimers = new Dictionary<Guid, Timer>();
        }

        /// <summary>
        /// <para> Starts a new timer that runs for the specified amount of seconds and returns the guid for the new timer. </para>
        /// <param name="seconds"> How many seconds the timer will run. </param>
        /// </summary>
        public Guid StartNewTimer(float seconds)
        {
            Timer timer = new Timer();
            Guid id = Guid.NewGuid();
            runningTimers.Add(id, timer);
            StartCoroutine(timer.StartTimerCoroutine(seconds, null, null, () => RemoveTimerFromDict(id)));
            return id;  
        }
        
        /// <summary>
        /// <para> Starts a new timer that runs for the specified amount of seconds and returns the guid for the new timer. </para>
        /// <param name="seconds"> How many seconds the timer will run. </param>
        /// <param name="onTimerEnd"> Calls this action on timer end. </param>
        /// </summary>
        public Guid StartNewTimer(float seconds, Action onTimerEnd)
        {
            Timer timer = new Timer();
            Guid id = Guid.NewGuid();
            runningTimers.Add(id, timer);
            StartCoroutine(timer.StartTimerCoroutine(seconds, null, onTimerEnd, () => RemoveTimerFromDict(id)));
            return id;  
        }
            
        /// <summary>
        /// <para> Starts a new timer that runs for the specified amount of seconds and returns the guid for the new timer. </para>
        /// <param name="seconds"> How many seconds the timer will run. </param>
        /// <param name="onUpdate"> Calls this action every tick of the timer. </param>
        /// </summary>
        public Guid StartNewTimer(Action onUpdate, float seconds)
        {
            Timer timer = new Timer();
            Guid id = Guid.NewGuid();
            runningTimers.Add(id, timer);
            StartCoroutine(timer.StartTimerCoroutine(seconds, onUpdate, null, () => RemoveTimerFromDict(id)));
            return id;   
        }
            
        /// <summary>
        /// <para> Starts a new timer that runs for the specified amount of seconds and returns the guid for the new timer. </para>
        /// <param name="seconds"> How many seconds the timer will run. </param>
        /// <param name="onUpdate"> Calls this action every tick of the timer. </param>
        /// <param name="onTimerEnd"> Calls this action on timer end. </param>
        /// </summary>
        public Guid StartNewTimer(float seconds, Action onUpdate, Action onTimerEnd)
        {
            Timer timer = new Timer();
            Guid id = Guid.NewGuid();
            runningTimers.Add(id, timer);
            StartCoroutine(timer.StartTimerCoroutine(seconds, onUpdate, onTimerEnd, () => RemoveTimerFromDict(id)));
            return id;  
        }

        private void RemoveTimerFromDict(Guid id)
        {
            runningTimers.Remove(id);
        }
    }
    
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
