using MartianChild.Utility.Unity_Extensions;
using MyBox;
using UnityEditor;
using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
#if UNITY_EDITOR
    [ExecuteInEditMode] public class GridVisualizer : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField] 
        private Grid grid;
        
        [Header("Visualization")]
        public bool drawGrid;
        public Color gridColor = Color.white;
        public bool drawGridBounds;
        public Color boundsColor = Color.white;
        
        
        private void LateUpdate()
        {
            if (transform.hasChanged) UpdateGrid();
        }

        private void UpdateGrid()
        {
            grid.Generate();
        }
        private void OnDrawGizmos()
        {
           DrawGridGizmos();
        }

        private void DrawGridGizmos()
        {
            if (grid == null) UpdateGrid();
            DrawGrid();
            DrawGridBounds();
        }

        private void DrawGrid()
        {
            if (!drawGrid ) return;
            
            Gizmos.color = gridColor;
            
            // draw the cells
            foreach (GridObject gridObj in grid.GetGridObjects())
            {
                if (grid.transform.rotation.eulerAngles.x != 0)
                {
                     Gizmos.DrawWireCube(
                        grid.WorldPosFromGridPos(gridObj.GetGridPosition()), 
                        new Vector3(1, 0, 1) * grid.CellSize);
                }
                else
                {
                    Gizmos.DrawWireCube(
                        grid.WorldPosFromGridPos(gridObj.GetGridPosition()), 
                        new Vector3(1, 1, 0) * grid.CellSize);
                }
                
                Handles.Label(grid.WorldPosFromGridPos(gridObj.GetGridPosition()) - new Vector3(grid.CellSize - 0.1f, 0, grid.CellSize - 0.4f)/2, "" + gridObj.GetGridPosition());
               
            }
        }
        
        private void DrawGridBounds()
        {
            if (!drawGridBounds ) return;
            
            Gizmos.color = boundsColor;
            
            // draw the bounds
            //gridScale.RotateAroundPivot(grid.transform.position, grid.transform.rotation.eulerAngles);
            
            if (grid.transform.rotation.eulerAngles.x == 0)
                Gizmos.DrawWireCube(grid.transform.position, grid.transform.localScale * grid.CellSize);
            else 
                Gizmos.DrawWireCube(grid.transform.position, new Vector3(grid.Scale.x, grid.transform.localScale.z, grid.Scale.y) * grid.CellSize);
                
            
        }
    }
#endif
}
