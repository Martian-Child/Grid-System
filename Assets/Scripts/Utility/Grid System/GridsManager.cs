using MartianChild.Utility.Serialization;
using UnityEngine;

namespace MartianChild.Utility.Grid_System
{
    [ExecuteInEditMode] public partial class GridsManager : MonoBehaviour
    {
        [SerializeField]
        protected SerializableDictionary<string, Grid> grids;

        public T GetGrid<T>(string key) where T : Grid => grids[key] as T;
        public void AddGrid(string key, Grid grid) => grids.Add(key, grid);
        public void RemoveGrid(string key) => grids.Remove(key);
    }
    
}
