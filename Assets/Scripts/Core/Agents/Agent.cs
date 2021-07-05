/*
using System.Collections.Generic;
using MartianChild.GridSystem.Pathfinder;
using UnityEngine;

namespace MartianChild.GridSystem.Agents
{
    public abstract class Agent : MonoBehaviour
    {
        private AStarPathfinder AStarPathfinder;
        private Queue<Node> moveQueue;
        private Node occupiedNode;

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnEnabled() { }
        
        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void OnEnable()
        {
            OnEnabled();
        }

        protected void MoveTo(Vector3 destination)
        {
            
        }

        protected void FindPath(Node destinationNode)
        {
            IEnumerable<Node> path = AStarPathfinder.FindPath(occupiedNode.gridPosition, destinationNode.gridPosition);
        }
    }
}
*/
