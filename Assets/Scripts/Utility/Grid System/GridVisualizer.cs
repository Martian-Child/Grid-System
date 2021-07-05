using MartianChild.Utility.Unity_Extensions;
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
        
        
        private void Update()
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
                Gizmos.DrawWireCube(
                    grid.WorldPosFromGridPos(gridObj.GetGridPosition()), 
                    new Vector3(1, 0, 1) * grid.CellSize);
            }
        }
        
        private void DrawGridBounds()
        {
            if (!drawGridBounds ) return;
            
            Gizmos.color = boundsColor;
            
            // draw the bounds
            Vector3 gridScale = grid.transform.localScale;
            gridScale.RotateAroundPivot(grid.transform.position, grid.transform.rotation.eulerAngles);
            
            Gizmos.DrawWireCube(grid.transform.position, gridScale);
            
        }
    }
#endif
}
