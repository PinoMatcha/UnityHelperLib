using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Transform�N���X�̔ėp�֐�
    /// </summary>
    public static class TransformUtils {

        /// <summary>
        /// ���Ԓn�_��Vector3�^�ŕԂ��܂��B
        /// </summary>
        public static Vector3 GetMiddlePoint(Vector3 firstPoint, Vector3 secondPoint) {
            return Vector3.Lerp(firstPoint, secondPoint, 0.5f);
        }

        /// <summary>
        /// ���Ԓn�_��Vector2�^�ŕԂ��܂��B
        /// </summary>
        public static Vector2 GetMiddlePoint(Vector2 firstPoint, Vector2 secondPoint) {
            return Vector2.Lerp(firstPoint, secondPoint, 0.5f);
        }

        /// <summary>
        /// ���Ԓn�_��Vector3�^�ŕԂ��܂��B
        /// </summary>
        public static Vector3 GetMiddlePoint(Transform firstPoint, Transform secondPoint) {
            return GetMiddlePoint(firstPoint.position, secondPoint.position);
        }

    }
}