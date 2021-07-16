using MyBox;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MartianChild.Utility.Collision
{
    public class CollideEventHandler : MonoBehaviour
    {
        [Tag] [Tooltip("Only game objects with the specified tags will register collisions, if there are no specified tags" +
                       "then all game objects regardless of tag will register a collision.")]
        public List<string> tagsAllowedToCollide;
        [Tooltip("Triggered when collision is first registered.")]
        public CollisionEvent onCollisionEnter;
        [Tooltip("Triggered while colliding.")]
        public CollisionEvent onCollisionStay;
        [Tooltip("Triggered when collision ends.")]
        public CollisionEvent onCollisionExit;
        
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (tagsAllowedToCollide.Count == 0 || tagsAllowedToCollide.Contains(collision.gameObject.tag))
            {
                onCollisionEnter.Invoke(gameObject, collision.gameObject);
            }
        }

        private void OnCollisionStay(UnityEngine.Collision collision)
        {
            if (tagsAllowedToCollide.Count == 0 || tagsAllowedToCollide.Contains(collision.gameObject.tag))
            {
                onCollisionStay.Invoke(gameObject, collision.gameObject);
            }
        }

        private void OnCollisionExit(UnityEngine.Collision collision)
        {
            if (tagsAllowedToCollide.Count == 0 || tagsAllowedToCollide.Contains(collision.gameObject.tag))
            {
                onCollisionExit.Invoke(gameObject, collision.gameObject);
            }
        }
    }

    /// <summary>
    /// Events for collisions, the first gameobject is the gameobject that this monobehavior is attached to,
    /// the second is the gameobject that collided with the the one this is attached to.
    /// </summary>
    [System.Serializable]
    public class CollisionEvent : UnityEvent<GameObject, GameObject> { }

}
