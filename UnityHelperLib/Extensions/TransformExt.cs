using UnityEngine;
using System.Linq;

namespace PMP.UnityLib {
    /// <summary>
    /// Transform型の拡張メソッド
    /// </summary>
    public static class TransformExt {

        /// <summary>
        /// 親オブジェクトを持っているかを返します。
        /// </summary>
        public static bool HasParent(this Transform self) {
            return self.parent != null;
        }

        /// <summary>
        /// 子オブジェクトを持っているかを返します。
        /// </summary>
        public static bool HasChild(this Transform self) {
            return self.childCount > 0;
        }

        /// <summary>
        /// すべての子オブジェクトを返します。
        /// 子オブジェクトがない場合はnullを返します。
        /// </summary>
        public static Transform[] GetAllChildren(this Transform self, bool includeInactive = false) {
            if (!self.HasChild()) return null;

            return self
                .GetComponentsInChildren<Transform>(includeInactive)
                .Where(c => c != self.transform)
                .Select(c => c.transform)
                .ToArray();
        }

        /// <summary>
        /// すべての子オブジェクトを削除します。
        /// </summary>
        public static void DestroyAllChildren(this Transform self) {
            for (var i = self.childCount - 1; i >= 0; i--) {
                Object.Destroy(self.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// position、rotation、scaleをリセットします。
        /// </summary>
        public static void Reset(this Transform self, bool isLocal = false) {
            if (isLocal) {
                self.localPosition = Vector3.zero;
                self.localRotation = Quaternion.identity;
                self.localScale = Vector3.one;
            } else {
                self.position = Vector3.zero;
                self.rotation = Quaternion.identity;
                self.localScale = new Vector3(
                  self.localScale.x / self.lossyScale.x,
                  self.localScale.y / self.lossyScale.y,
                  self.localScale.z / self.lossyScale.z
                );
            }
        }
    }
}