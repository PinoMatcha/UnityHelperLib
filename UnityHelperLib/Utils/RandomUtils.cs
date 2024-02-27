using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Randomクラスの汎用関数
    /// </summary>
    public static class RandomUtils {

        /// <summary>
        /// 0.0 から 1.0 の浮動小数点数をランダムに返します。
        /// </summary>
        public static float Value { get { return Random.value; } }

        /// <summary>
        /// true か false をランダムに返します。
        /// </summary>
        public static bool Flag { get { return Random.Range(0, 2) == 0; } }

        /// <summary>
        /// min から max の浮動小数点数をランダムに返します。
        /// </summary>
        public static float Range(float min, float max) => Random.Range(min, max);

        /// <summary>
        /// Vector2 のxy成分をそれぞれ最小・最大として浮動小数点数をランダムに返します。
        /// </summary>
        public static float Range(Vector2 range) => Random.Range(range.x, range.y);

        /// <summary>
        /// Vector2 のxy成分をそれぞれ最小・最大として整数をランダムに返します。
        /// </summary>
        public static int Range(Vector2Int range) => Random.Range(range.x, range.y);

    }
}