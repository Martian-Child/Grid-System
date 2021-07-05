using System.Collections.Generic;
using UnityEngine;

namespace MartianChild.Utility.Design_Patterns
{
    [System.Serializable]
    public class Pool
    {
        /// <summary>
        /// name to associate with objects in a pool.
        /// </summary>
        public string tag;
        /// <summary>
        /// size of pool.
        /// </summary>
        public int size;
        /// <summary>
        /// prefab to instantiate objects from for a pool.
        /// </summary>
        public GameObject prefab;
        /// <summary>
        /// place to parent and store objects in a pool.
        /// </summary>
        public Transform storage;
    }

    public class ObjectPooler : MonoBehaviour
    {
        [Tooltip("The pools of gameobjects to spawn from.")]
        public List<Pool> pools;

        /// <summary>
        /// stores queues for pools by cref="MartianChild.Utility.Pool.tag".
        /// </summary>
        public Dictionary<string, Queue<GameObject>> poolDict;

        private void Awake()
        {
            CreatePools();
        }

        /// <summary>
        /// <para> Spawns object from pool at a specified gridPosition and rotation. </para>
        /// <param name="tag"> cref="MartianChild.Utility.Pool.tag" given to item in cref="MartianChild.Utility.Pool". </param>
        /// <param name="position"> Position to spawn object. </param>
        /// <param name="rotation"> Rotation to spawn object. </param>
        /// </summary>
        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDict.ContainsKey(tag))
            {
                Debug.LogError("Pools does not contain a pool with tag: " + tag, this);
                return null;
            }
            
            GameObject gameObj = poolDict[tag].Dequeue();
            gameObj.transform.position = position;
            gameObj.transform.rotation = rotation;
            gameObj.SetActive(true);
            poolDict[tag].Enqueue(gameObj);
            
            return gameObj;
        }

        private void CreatePools()
        {
            poolDict = new Dictionary<string, Queue<GameObject>>();
            
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.parent = pool.storage;
                    obj.SetActive(false);
                    objPool.Enqueue(obj);
                }

                poolDict.Add(pool.tag, objPool);
            }
        }
    }
}