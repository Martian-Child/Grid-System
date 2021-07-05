using UnityEngine;

namespace MartianChild.Utility.Design_Patterns
{
    [ExecuteInEditMode]
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// The instance of your singleton.
        /// </summary>
        private static T instance;
        
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = FindObjectOfType<T>();
                if (instance != null) return instance;

                GameObject obj = new GameObject {name = typeof(T).Name};
                instance = obj.AddComponent<T>();

                return instance;
            }
        }

        /// <summary>
        /// Use this for initialization, if no instance of singleton already then
        /// assigns this as the singleton instance else destroy this.
        /// </summary>
        protected virtual void Awake()
        {
            if (instance == null && Application.isPlaying)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}