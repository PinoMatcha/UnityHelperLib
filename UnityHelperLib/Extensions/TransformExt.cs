using UnityEngine;
using System.Linq;

namespace PMP.UnityLib {
    /// <summary>
    /// Transform型の拡張メソッド
    /// </summary>
    public static class TransformExt {

        /// <summary>
        /// 親オブジェクトを持っているかを返します
        /// </summary>
        public static bool HasParent(this Transform self) {
            return self.parent != null;
        }

        /// <summary>
        /// 子オブジェクトを持っているかを返します
        /// </summary>
        public static bool HasChild(this Transform self) {
            return self.childCount > 0;
        }

        /// <summary>
        /// すべての子オブジェクトを返します
        /// 子オブジェクトがない場合はnullを返します
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
        /// すべての子オブジェクトを削除します
        /// </summary>
        public static void DestroyAllChildren(this Transform self) {
            for (var i = self.childCount - 1; i >= 0; i--) {
                Object.Destroy(self.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// ワールド座標系の位置を指定します
        /// </summary>
        public static void SetPosition(this GameObject gameObject, Vector3 position) {
            gameObject.transform.position = position;
        }

        /// <summary>
        /// ワールド座標系のX座標を指定します
        /// </summary>
        public static void SetPositionX(this Transform transform, float x) {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// ワールド座標系のY座標を指定します
        /// </summary>
        public static void SetPositionY(this Transform transform, float y) {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        /// <summary>
        /// ワールド座標系のZ座標を指定します
        /// </summary>
        public static void SetPositionZ(this Transform transform, float z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        /// <summary>
        /// ワールド座標系のX座標に加算します
        /// </summary>
        public static void AddPositionX(this Transform transform, float x) {
            transform.SetPositionX(x + transform.position.x);
        }

        /// <summary>
        /// ワールド座標系のY座標に加算します
        /// </summary>
        public static void AddPositionY(this Transform transform, float y) {
            transform.SetPositionY(y + transform.position.y);
        }

        /// <summary>
        /// ワールド座標系のZ座標に加算します
        /// </summary>
        public static void AddPositionZ(this Transform transform, float z) {
            transform.SetPositionZ(z + transform.position.z);
        }

        /// <summary>
        /// ローカル座標系の位置を指定します
        /// </summary>
        public static void SetLocalPosition(this GameObject gameObject, Vector3 localPosition) {
            gameObject.transform.localPosition = localPosition;
        }

        /// <summary>
        /// ローカル座標系のX座標を指定します
        /// </summary>
        public static void SetLocalPositionX(this Transform transform, float x) {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }

        /// <summary>
        /// ローカル座標系のY座標を指定します
        /// </summary>
        public static void SetLocalPositionY(this Transform transform, float y) {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }

        /// <summary>
        /// ローカル座標系のZ座標を指定します
        /// </summary>
        public static void SetLocalPositionZ(this Transform transform, float z) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
        }

        /// <summary>
        /// ローカル座標系のX座標に加算します
        /// </summary>
        public static void AddLocalPositionX(this Transform transform, float x) {
            transform.SetLocalPositionX(x + transform.localPosition.x);
        }

        /// <summary>
        /// ローカル座標系のY座標に加算します
        /// </summary>
        public static void AddLocalPositionY(this Transform transform, float y) {
            transform.SetLocalPositionY(y + transform.localPosition.y);
        }

        /// <summary>
        /// ローカル座標系のZ座標に加算します
        /// </summary>
        public static void AddLocalPositionZ(this Transform transform, float z) {
            transform.SetLocalPositionZ(z + transform.localPosition.z);
        }

        /// <summary>
        /// position、rotation、scaleをリセットします
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