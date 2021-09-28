using MartianChild.Utility.Unity_Extensions;
using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
    [ExecuteInEditMode] public class SnapToGrid : MonoBehaviour
    {
        [SerializeField]
        private Grid grid;

        public bool useLocalPos = true;
        public bool snapToGrid = true;
        public bool sizeToGrid = true;
        
        // Adjust size and gridPosition
        private void Update()
        {
            Snap();
        }

        public void Snap()
        {
            if (snapToGrid)
            {
                if (useLocalPos)
                {
                    Vector3 position = transform.localPosition;
                    position.Snap(grid.CellSize);
                    transform.localPosition = position;
                }
                else
                {
                    Vector3 position = transform.position;
                    position.Snap(grid.CellSize);
                    transform.position = position;
                }
                
            }

            if (sizeToGrid)
            {
                Vector3 localScale = transform.localScale;
                localScale.Snap(grid.CellSize);
                transform.localScale = localScale;
            }
        }
    }  
}