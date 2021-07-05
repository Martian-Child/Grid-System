using System.Collections.Generic;
using MartianChild.Utility.DataManipulation;
using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
    
    public abstract class Node : GridObject
    {
        protected List<Node> neighbors;

        public enum NumberConnections
        {
            Zero, Four, Eight
        }

        public Node(Grid grid, Vector2Int gridPosition) : base(grid, gridPosition)
        {
            neighbors = new List<Node>();
        }
        
        public void AddNeighbor(Node n)
        {
            neighbors.Add(n);
        }

        public IList<TNode> GetNeighbors<TNode>() where TNode : Node
        {
            return neighbors.CastList<Node, TNode>();
        }
        
        public void CalculateNeighbors(NumberConnections numberConnections)
        {
            if (numberConnections == NumberConnections.Zero) return;

            Vector2Int[] potentialNeighborPositions =
            {
                gridPosition + new Vector2Int(0, 1), gridPosition + new Vector2Int(0, -1),
                gridPosition + new Vector2Int(1, 0), gridPosition + new Vector2Int(-1, 0),
                gridPosition + new Vector2Int(1, -1), gridPosition + new Vector2Int(-1, 1),
                gridPosition + new Vector2Int(1, 1), gridPosition + new Vector2Int(-1, -1)
            };

            for (int p = 0; p < potentialNeighborPositions.Length; p++)
            {
                if (numberConnections != NumberConnections.Eight && p >= 4) return;
                
                Vector2Int potentialNeighborPosition = potentialNeighborPositions[p];
                if (grid.InGridBounds(potentialNeighborPosition.x, potentialNeighborPosition.y))
                {
                    AddNeighbor(grid.GetGridObject(potentialNeighborPosition.x, potentialNeighborPosition.y) as Node);
                }
            }
        }
        
        public void AddNeighbors(List<Node> nList)
        {
            foreach (Node n in nList) 
                neighbors.Add(n);
        }
        
        public void SetNeighbors(List<Node> nList)
        {
            neighbors = nList;
        }
    }
}
