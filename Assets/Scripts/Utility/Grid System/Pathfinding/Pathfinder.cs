using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MartianChild.Utility.Grid_System.Pathfinding
{
    public class Pathfinder
    {
        private readonly int _moveStraightCost;
        private readonly int _moveDiagonalCost;

        private readonly AStarGrid _aStarGrid;

        private List<PathNode> _openList;
        private List<PathNode> _closedList;

        public Pathfinder(AStarGrid grid, int moveStraightCost, int moveDiagonalCost)
        {
            _moveDiagonalCost = moveDiagonalCost;
            _moveStraightCost = moveStraightCost;
            _aStarGrid = grid;
        }

        public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition,
            PathNode.Type[] traversableTypes)
        {
            _aStarGrid.GridPosFromWorldPos(startWorldPosition, out int startX, out int startY);
            _aStarGrid.GridPosFromWorldPos(endWorldPosition, out int endX, out int endY);

            List<PathNode> path = FindPath(startX, startY, endX, endY, traversableTypes);

            return path?.Select(pathNode => pathNode.GetWorldPosition()).ToList();
        }

        public List<PathNode> FindPath(int startX, int startY, int endX, int endY, PathNode.Type[] traversableTypes)
        {
            PathNode startNode = _aStarGrid.GetPathNode(startX, startY);
            PathNode endNode = _aStarGrid.GetPathNode(endX, endY);

            if (startNode == null || endNode == null) // Invalid Path
                return null;


            _openList = new List<PathNode> {startNode};
            _closedList = new List<PathNode>();

            _aStarGrid.ResetPathNodes();

            startNode.distFromStartNode = 0;
            startNode.estDistToDestinationNode = CalculateDistanceCost(startNode, endNode);

            while (_openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(_openList);
                if (currentNode == endNode) return CalculatePath(endNode);

                _openList.Remove(currentNode);
                _closedList.Add(currentNode);

                foreach (PathNode neighbourNode in currentNode.GetNeighbors<PathNode>())
                {
                    if (_closedList.Contains(neighbourNode)) continue;
                    if (!traversableTypes.Contains(neighbourNode.type))
                    {
                        _closedList.Add(neighbourNode);
                        continue;
                    }

                    int tentativeGCost = currentNode.distFromStartNode +
                                         CalculateDistanceCost(currentNode, neighbourNode);
                    if (tentativeGCost >= neighbourNode.distFromStartNode) continue;

                    neighbourNode.link = currentNode;
                    neighbourNode.distFromStartNode = tentativeGCost;
                    neighbourNode.estDistToDestinationNode = CalculateDistanceCost(neighbourNode, endNode);

                    if (!_openList.Contains(neighbourNode)) _openList.Add(neighbourNode);
                }
            }

            // Out of nodes on the openList
            return null;
        }

        private List<PathNode> CalculatePath(PathNode endNode)
        {
            List<PathNode> path = new List<PathNode> {endNode};
            PathNode currentNode = endNode;
            while (currentNode.link != null)
            {
                path.Add(currentNode.link);
                currentNode = currentNode.link;
            }

            path.Reverse();
            return path;
        }

        private int CalculateDistanceCost(PathNode a, PathNode b)
        {
            int xDistance = Mathf.Abs(a.GetGridPosition().x - a.GetGridPosition().x);
            int yDistance = Mathf.Abs(a.GetGridPosition().y - a.GetGridPosition().y);
            int remaining = Mathf.Abs(xDistance - yDistance);
            return _moveDiagonalCost * Mathf.Min(xDistance, yDistance) + _moveStraightCost * remaining;
        }

        private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
        {
            PathNode lowestFCostNode = pathNodeList[0];
            for (int i = 1; i < pathNodeList.Count; i++)
            {
                if (pathNodeList[i].Cost < lowestFCostNode.Cost) lowestFCostNode = pathNodeList[i];
            }

            return lowestFCostNode;
        }
    }
}