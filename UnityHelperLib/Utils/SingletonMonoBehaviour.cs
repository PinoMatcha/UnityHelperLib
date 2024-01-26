using UnityEngine;
using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;   // AssetDatabaseを使うために必要
#endif

namespace PMP.UnityLib {
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

        private static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    Type t = typeof(T);
                    instance = (T)FindObjectOfType(t);

                    // 見つからなかった場合は非アクティブのものも検索する
                    if (instance == null)
                        instance = FindObjectInHierarchy(t);

                    if (instance == null)
                        Debug.LogError(t + " をアタッチしているGameObjectはありません。");
                    else
                        instance.gameObject.SetActive(true);
                }

                return instance;
            }
        }

        static T FindObjectInHierarchy(Type target) {
            return Resources.FindObjectsOfTypeAll<T>()
#if UNITY_EDITOR
                .Where(go => AssetDatabase.GetAssetOrScenePath(go).Contains(".unity"))
#endif
                .First(go => go.GetType() == target);
        }

        /// <summary>
        /// 初期化
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        void Initialize() {
            // インスタンスチェック
            CheckInstance();
        }

        protected bool CheckInstance() {
            if (instance == null) {
                instance = this as T;
                return true;
            } else if (Instance == this) {
                return true;
            }
            Destroy(this);
            return false;
        }
    }
}