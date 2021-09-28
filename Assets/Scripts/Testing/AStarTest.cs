using MartianChild.Utility.Grid_System;
using MartianChild.Utility.Grid_System.Pathfinding;
using UnityEngine;

namespace MartianChild.VoxelDungeon.Testing
{
    [ExecuteInEditMode] public class AStarTest : MonoBehaviour
    {
        public Camera cam;
        public PathManager pathManager;


        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            Plane plane = new Plane(Vector3.up, 0);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldClickPosition = ray.GetPoint(distance);
                Debug.Log("TESTING");
                Debug.Log("Mouse Click Pos: " + worldClickPosition);
                PathNode.Type[] traversableNodeTypes = {
                    PathNode.Type.Air, PathNode.Type.Water, PathNode.Type.Land
                };
                 
                pathManager.FindPath(
                    gameObject, 
                    Vector3.zero, 
                    worldClickPosition, 
                    traversableNodeTypes);
            }
        }
    }
}
