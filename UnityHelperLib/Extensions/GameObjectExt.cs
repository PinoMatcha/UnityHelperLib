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