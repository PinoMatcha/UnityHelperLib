using UnityEngine;
using System.Linq;

namespace PMP.UnityLib {
    /// <summary>
    /// GameObject型の拡張メソッド
    /// </summary>
    public static class GameObjectExt {

        /// <summary>
        /// 子オブジェクトを持っているかを返します。
        /// </summary>
        public static bool HasChild (this GameObject self) {
            return self.transform.childCount > 0;
        }

        /// <summary>
        /// すべての子オブジェクトを返します。子オブジェクトがない場合はnullを返します。
        /// </summary>
        public static GameObject[] GetAllChildren (this GameObject self, bool includeInactive = false) {
            return self
                .GetComponentsInChildren<Transform>(includeInactive)
                .Where(c => c != self.transform)
                .Select(c => c.gameObject)
                .ToArray();
        }

        /// <summary>
        /// 指定されたコンポーネントがアタッチされているかどうかを返します。
        /// </summary>
        public static bool HasComponent<T>(this GameObject self) where T : Component {
            return self.GetComponent<T>() != null;
        }

        /// <summary>
        /// child を自身の子に追加します。
        /// </summary>
        public static void AddChild(this GameObject self, Transform child) {
            child.SetParent(self.transform);
        }

        /// <summary>
        /// child を自身の子に追加します。
        /// </summary>
        public static void AddChild(this GameObject self, GameObject child) {
            child.transform.SetParent(self.transform);
        }

        /// <summary>
        /// 自身を破棄します。
        /// </summary>
        public static void Destroy(this GameObject self) {
            Object.Destroy(self.gameObject);
        }

        /// <summary>
        /// 自身を破棄します。
        /// </summary>
        public static void Destroy(this GameObject self, float time) {
            Object.Destroy(self.gameObject, time);
        }

        /// <summary>
        /// DontDestroyOnLoadにします。
        /// </summary>
        public static GameObject DontDestroyOnLoad(this GameObject self) {
            Object.DontDestroyOnLoad(self);
            return self;
        }

        /// <summary>
        /// 位置を (0, 0, 0) にリセットします。
        /// </summary>
        public static void ResetPosition(this GameObject self) {
            self.transform.position = new Vector3();
        }

        /// <summary>
        /// 位置を返します。
        /// </summary>
        public static Vector3 GetPosition(this GameObject self) {
            return self.transform.position;
        }

        /// <summary>
        /// X座標を返します。
        /// </summary>
        public static float GetPositionX(this GameObject self) {
            return self.transform.position.x;
        }

        /// <summary>
        /// Y座標を返します。
        /// </summary>
        public static float GetPositionY(this GameObject self) {
            return self.transform.position.y;
        }

        /// <summary>
        /// Z座標を返します。
        /// </summary>
        public static float GetPositionZ(this GameObject self) {
            return self.transform.position.z;
        }

    }
}