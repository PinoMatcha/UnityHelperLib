namespace PMP.UnityLib {
    /// <summary>
    /// Randomクラスの汎用関数
    /// </summary>
    public static class RandomUtils {

        /// <summary>
        /// 0.0 から 1.0 の浮動小数点数をランダムに返します
        /// </summary>
        public static float Value { get { return UnityEngine.Random.value; } }

        /// <summary>
        /// true か false をランダムに返します
        /// </summary>
        public static bool Flag { get { return UnityEngine.Random.Range(0, 2) == 0; } }

        /// <summary>
        /// min から max の浮動小数点数をランダムに返します
        /// </summary>
        public static float Range(float min, float max) => UnityEngine.Random.Range(min, max);

    }
}