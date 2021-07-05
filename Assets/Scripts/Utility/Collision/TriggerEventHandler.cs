using MyBox;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MartianChild.Utility.Collision
{
    public class TriggerEventHandler : MonoBehaviour
    {
        [Tag] [Tooltip("Only game objects with the specified tags will trigger, if there are no specified tags" +
                      "then all game objects regardless of tag will trigger.")]
        public List<string> tagsAllowedToTrigger;
        [Tooltip("Triggered when something enters trigger box.")]
        public TriggerEvent onTriggerEnter;
        [Tooltip("Triggered while something is in trigger box.")]
        public TriggerEvent onTriggerStay;
        [Tooltip("Triggered when something exits trigger box.")]
        public TriggerEvent onTriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (tagsAllowedToTrigger.Count == 0 || tagsAllowedToTrigger.Contains(other.tag))
            {
                onTriggerEnter.Invoke(gameObject, other.gameObject);
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (tagsAllowedToTrigger.Count == 0 || tagsAllowedToTrigger.Contains(other.tag))
            {
                onTriggerStay.Invoke(gameObject, other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (tagsAllowedToTrigger.Count == 0 || tagsAllowedToTrigger.Contains(other.tag))
            {
                onTriggerExit.Invoke(gameObject, other.gameObject);
            }
        }
    }
}

/// <summary>
/// Events for triggers being triggered, the first gameobject is the gameobject that triggered the event,
/// the second is the gameobject that collided with the one that triggers the event
/// </summary>
[System.Serializable]
public class TriggerEvent : UnityEvent<GameObject, GameObject> { }
