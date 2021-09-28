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
        private Pathfinder _pathfinder;

        [Header("A Star Settings")] 
        public int moveStraightCost = 10;
        public int moveDiagonalCost = 14;
        public Node.NumberConnections numberNodeConnections;
        public LayerMask traversableLayers;
        
        
        private void Awake()
        {
            base.Awake();
            _aStarGrid = gridsManager.GetGrid<AStarGrid>("A Star Grid");
            _pathfinder = new Pathfinder(_aStarGrid, moveStraightCost, moveDiagonalCost);
        }

        public AStarGrid GetAStarGrid()
        {
            if (_aStarGrid == null) 
                _aStarGrid = gridsManager.GetGrid<AStarGrid>("A Star Grid");
            return _aStarGrid;
        }
        
        public List<Vector3> FindPath(GameObject requester, Vector3 startWorldPosition, Vector3 desiredWorldDestination, PathNode.Type[] traversableNodeTypes)
        {
            List<Vector3> path = _pathfinder.FindPath(startWorldPosition, desiredWorldDestination, traversableNodeTypes);
            onPathFoundEvent.Invoke(requester, path);
            return path;
        }
    }
    
    /// <summary>
    /// <para> The event fired when the pathmanager finds a path. </para>
    /// <param name="GameObject"> The gameobject that requested a path. </param>
    /// <param name="List<Vector3>"> The path that is returned. </param>
    /// </summary>
    [Serializable] public class PathEvent : UnityEvent<GameObject, List<Vector3>> { }
}
