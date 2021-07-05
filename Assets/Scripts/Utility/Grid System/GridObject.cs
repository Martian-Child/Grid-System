using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
    public abstract class GridObject
    {
        protected readonly Grid grid;
        protected readonly Vector2Int gridPosition;
        protected Vector3 worldPosition;

        public GridObject(Grid grid, Vector2Int gridPosition)
        {
            this.grid = grid;
            this.gridPosition = gridPosition;
        }

        public Vector2Int GetGridPosition() => gridPosition;
        public Vector3 GetWorldPosition() => worldPosition; //grid.WorldPosFromGridPos(gridPosition.x, gridPosition.y);
        public void UpdateWorldPosition(Vector3 updatedPosition) => worldPosition = updatedPosition;
    }
}
