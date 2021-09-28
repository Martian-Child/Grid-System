using System;
using MartianChild.Utility.Physics;
using MartianChild.Utility.Unity_Extensions;
using UnityEngine;

namespace MartianChild.Utility.Grid_System.Pathfinding
{
    public class AStarGrid : Grid
    {
        [Header("Dependencies")]
        [SerializeField]
        private PathManager pathManager;
        private PathNode[,] _pathNodes;

        public sealed override void Generate()
        {
            base.Initialize();
            base.Generate((grid, gridPosition) => new PathNode(grid, gridPosition), OnNodeAdded);
            CalculateNodeConnections();
        }

        public PathNode GetPathNode(int x, int y)
        {
            return GetGridObject(x, y) as PathNode;
        }

        public PathNode[,] GetPathNodes()
        {
            return _pathNodes;
        }

        public void ResetPathNodes()
        {
            foreach (PathNode pathNode in _pathNodes)
            {
                pathNode.Reset();
            }
        }

        private void CalculateNodeConnections()
        {
            _pathNodes = new PathNode[gridObjs.GetLength(0), gridObjs.GetLength(1)];
            Array.Copy(gridObjs, _pathNodes, gridObjs.Length);

            foreach (PathNode pathNode in _pathNodes)
            {
                pathNode.CalculateNeighbors(pathManager.numberNodeConnections);
            }
        }

        private void OnNodeAdded(GridObject gridObject)
        {
            //Debug.Log(gridObject.GetGridPosition());
            PathNode pathNode = gridObject as PathNode;
            if (pathNode == null) return;

            Vector3 rayOrigin = WorldPosFromGridPos(gridObject.GetGridPosition()) + new Vector3(0, transform.localScale.y, 0);
            bool hit = Raycaster.ShootRay(rayOrigin, transform.forward, rayOrigin.y * 2, out RaycastHit raycastHit);
            
            switch (hit)
            {
                case true when pathManager.traversableLayers.Contains(raycastHit.transform.gameObject.layer):
                    pathNode.UpdateWorldPosition(raycastHit.point);
                    pathNode.type = PathNode.Type.Land;
                    break;
                case true:
                    pathNode.UpdateWorldPosition(raycastHit.point);
                    pathNode.type = PathNode.Type.NonTraversable;
                    break;
                default:
                    pathNode.type = PathNode.Type.Air;
                    break;
            }
        }
    }
}