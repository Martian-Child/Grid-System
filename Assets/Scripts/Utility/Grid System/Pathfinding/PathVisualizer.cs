using System.Collections.Generic;
using MyBox;
using UnityEngine;


namespace MartianChild.Utility.Grid_System.Pathfinding
{
#if UNITY_EDITOR
    [ExecuteInEditMode] public class PathVisualizer : MonoBehaviour
    {

        [Header("Dependencies")] 
        [SerializeField] 
        private PathManager pathManager;

        [Header("Visualization")] public bool drawNodes;
        public Color nodeAirColor = Color.cyan;
        public Color nodeWaterColor = Color.blue;
        public Color nodeLandColor = Color.green;
        public Color nodeNonTraversableColor = Color.red;
        public bool drawNodeConnections;
        public Color connectionsColor = Color.white;
        public bool drawPath;
        public Color pathColor = Color.green;

        
        private void OnDrawGizmos()
        {
            DrawGridGizmos();
        }

        private void DrawGridGizmos()
        {
            DrawNodes();
            DrawNodeConnections();
        }

        private void OnValidate()
        {
            GenerateAStarGrid();
        }
        
        private void GenerateAStarGrid()
        {
            pathManager.GetAStarGrid().Generate();
        }

        private void DrawNodes()
        {
            if (!drawNodes || pathManager.GetAStarGrid().GetGridObjects().Length == 0) return;

            foreach (PathNode pathNode in pathManager.GetAStarGrid().GetPathNodes())
            {
                Gizmos.color = pathNode.type switch
                {
                    PathNode.Type.Air => nodeAirColor,
                    PathNode.Type.Water => nodeWaterColor,
                    PathNode.Type.Land => nodeLandColor,
                    _ => nodeNonTraversableColor
                };
                
                Gizmos.DrawSphere(pathNode.GetWorldPosition(), 0.1f);
            }
        }

        public void DrawPath(List<Vector3> path)
        {
            if (!drawPath || pathManager.GetAStarGrid().GetGridObjects().Length == 0 || path.IsNullOrEmpty()) return;

            for (int p = 0; p < path.Count; p++)
            {
                Gizmos.color = pathColor;
                if (p != path.Count - 1) Gizmos.DrawLine(path[p], path[p+1]);
                Gizmos.DrawSphere(path[p], 0.15f);
            }
        }

        private void DrawNodeConnections()
        {
            if (!drawNodeConnections || pathManager.GetAStarGrid().GetGridObjects().Length == 0) return;

            Gizmos.color = connectionsColor;

            foreach (GridObject gridObj in pathManager.GetAStarGrid().GetGridObjects())
            {
                Node node = (Node) gridObj;
                IList<Node> nodeNeighbors = node.GetNeighbors<Node>();
                if (nodeNeighbors.IsNullOrEmpty()) continue;

                foreach (Node neighbor in nodeNeighbors)
                {
                    Gizmos.DrawLine(node.GetWorldPosition(), neighbor.GetWorldPosition());
                }
            }
        }
    }
}
#endif
