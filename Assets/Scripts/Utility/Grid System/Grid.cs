using System;
using JetBrains.Annotations;
using MartianChild.Utility.Unity_Extensions;
using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
    public abstract class Grid : MonoBehaviour
    {
        public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

        public class OnGridObjectChangedEventArgs : EventArgs
        {
            public Vector2Int gridObjPosition;
        }
        
        [SerializeField] [Min(1)]
        protected float cellSize = 1f;
        protected Vector2 scale = Vector2.one;
        protected Vector3 position = Vector3.zero;
        
        public Vector2 Scale => scale;
        public Vector3 Position => position;
        public float CellSize => cellSize;
        
        protected GridObject[,] gridObjs;

        protected virtual void Initialize()
        {
            scale = new Vector2(transform.localScale.x, transform.localScale.y);
            position = transform.position;
            gridObjs = new GridObject[(int)scale.x, (int)scale.y];
        }
        
        protected void Generate(Func<Grid, Vector2Int, GridObject> createGridObject, [CanBeNull] Action<GridObject> onGridObjAdded)
        {
            for (int x = 0; x < gridObjs.GetLength(0); x++)
            {
                for (int y = 0; y < gridObjs.GetLength(1); y++)
                {
                    GridObject gridObject = createGridObject(this, new Vector2Int(x, y));
                    gridObject.UpdateWorldPosition(WorldPosFromGridPos(x, y));
                    gridObjs[x, y] = gridObject;
                    onGridObjAdded?.Invoke(gridObject);
                }
            }
        }
        public abstract void Generate();

        public bool InGridBounds(int x, int y)
        {
            if (x < 0 || y < 0 || x >= (int)scale.x || y >= (int)scale.y) return false;
            return true;
        }
        
        public bool InGridBounds(Vector3 worldPosition)
        {
            GridPosFromWorldPos(worldPosition, out int x, out int y);
            if (InGridBounds(x, y)) return false;
            return true;
        }
        
        public Vector3 WorldPosFromGridPos(int x, int y)
        {
            Vector3 worldPos = new Vector3(x - scale.x/2 + cellSize/2, y - scale.y/2 + cellSize/2) * cellSize + position;
            worldPos.RotateAroundPivot(position, transform.rotation.eulerAngles);
            return worldPos;
        }
        
        public Vector3 WorldPosFromGridPos(Vector2Int gridPos)
        {
            return WorldPosFromGridPos(gridPos.x, gridPos.y);
        }

        public void GridPosFromWorldPos(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt(((worldPosition - position).x - (float)scale.x/2 - cellSize/2) / cellSize);
            y = Mathf.FloorToInt(((worldPosition - position).y - (float)scale.y/2 - cellSize/2) / cellSize);
        }

        public void SetGridObject(int x, int y, GridObject value)
        {
            if(!InGridBounds(x, y)) return;
            gridObjs[x, y] = value;
            TriggerGridObjectChanged(x, y);
        }

        public void SetGridObject(Vector3 worldPosition, GridObject value)
        {
            GridPosFromWorldPos(worldPosition, out int x, out int y);
            SetGridObject(x, y, value);
        }

        public GridObject GetGridObject(int x, int y)
        {
            if(InGridBounds(x, y)) return gridObjs[x, y];
            return null;
        }

        public GridObject GetGridObject(Vector3 worldPosition)
        {
            GridPosFromWorldPos(worldPosition, out int x, out int y);
            return GetGridObject(x, y);
        }
        
        public GridObject[,] GetGridObjects()
        {
            return gridObjs;
        }

        public void TriggerGridObjectChanged(int x, int y)
        {
            OnGridObjectChanged?.Invoke(this, 
                new OnGridObjectChangedEventArgs {gridObjPosition = new Vector2Int(x,y)});
        }
    }
}