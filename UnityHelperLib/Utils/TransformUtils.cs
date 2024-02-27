using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Transformクラスの汎用関数
    /// </summary>
    public static class TransformUtils {

        /// <summary>
        /// 中間地点をVector3型で返します。
        /// </summary>
        public static Vector3 GetMiddlePoint(Vector3 firstPoint, Vector3 secondPoint) {
            return Vector3.Lerp(firstPoint, secondPoint, 0.5f);
        }

        /// <summary>
        /// 中間地点をVector2型で返します。
        /// </summary>
        public static Vector2 GetMiddlePoint(Vector2 firstPoint, Vector2 secondPoint) {
            return Vector2.Lerp(firstPoint, secondPoint, 0.5f);
        }

        /// <summary>
        /// 中間地点をVector3型で返します。
        /// </summary>
        public static Vector3 GetMiddlePoint(Transform firstPoint, Transform secondPoint) {
            return GetMiddlePoint(firstPoint.position, secondPoint.position);
        }

    }
}