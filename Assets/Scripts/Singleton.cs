using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityUtils
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;

        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<T>();
                }

                return instance;
            }
        }

        /// <summary>
        /// Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake() {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton() {
            if (!Application.isPlaying) return;

            if (instance == null)
            {
                instance = this as T;
                Setup();

                DontDestroyOnLoad(gameObject);

                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void Setup()
        {

        }

        protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ResetProperties();
        }

        protected virtual void ResetProperties()
        {

        }

        protected virtual void OnDestroy()
        {
            if (instance != this) return;

            SceneManager.sceneLoaded -= OnSceneLoaded;
            instance = null;
        }
    }
}
