using System;
using System.Collections.Generic;
using MartianChild.Utility.Design_Patterns;
using UnityEngine;

namespace MartianChild.Utility.Time
{
    public class TimersManager : Singleton<TimersManager>
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
}
