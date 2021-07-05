using System;
using System.Collections.Generic;
using MartianChild.Utility.Design_Patterns;
using UnityEngine;
using UnityEngine.Events;

namespace MartianChild.Utility.Grid_System.Pathfinding
{
    [ExecuteInEditMode] public class PathManager : Singleton<PathManager>
    {
        public PathEvent onPathFoundEvent;
        
        [Header("Dependencies")] 
        [SerializeField]
        private GridsManager gridsManager;
        private static AStarGrid _aStarGrid;
        //private Pathfinder _pathfinder;

        [Header("A Star Settings")] 
        public int moveStraightCost = 10;
        public int moveDiagonalCost = 14;
        public Node.NumberConnections numberNodeConnections;
        public LayerMask traversableLayers;
        
        
        private void Awake()
        {
            base.Awake();
            _aStarGrid = gridsManager.GetGrid<AStarGrid>("A Star Grid");
            //_pathfinder = new Pathfinder(_aStarGrid, moveStraightCost, moveDiagonalCost);
        }

        private void OnValidate()
        {
            base.Awake();
        }

        public AStarGrid GetAStarGrid()
        {
            if (_aStarGrid == null) 
                _aStarGrid = gridsManager.GetGrid<AStarGrid>("A Star Grid");
            return _aStarGrid;
        }
        
        public List<Vector3> FindPath(Vector3 startPosition, Vector3 desiredDestination, PathNode.Type[] traversableTypes)
        {
            //List<Vector3> path = _pathfinder.FindPath(startPosition, desiredDestination, traversableTypes);
            //onPathFoundEvent.Invoke(path);
            //return path;
            return null;
        }
    }
    
    [Serializable] public class PathEvent : UnityEvent<List<Vector3>> { }
}
