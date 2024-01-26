using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// int型の拡張メソッド
    /// </summary>
    public static class IntExt {

        /// <summary>
        /// 指定された回数UnityActionの実行を繰り返します。
        /// </summary>
        public static void LoopAction(this int self, UnityEngine.Events.UnityAction unityAction) {
            for (int i = 0; i < self; i++)
                unityAction?.Invoke();
        }

        /// <summary>
        /// 指定された回数UnityActionの実行を繰り返します。
        /// </summary>
        public static void LoopAction(this int self, UnityEngine.Events.UnityAction<int> unityAction) {
            for (int i = 0; i < self; i++)
                unityAction?.Invoke(i);
        }

        /// <summary>
        /// 数値を加算して、範囲を超えた分は 0 からの値として処理して返します。
        /// </summary>
        public static int Repeat(this int self, int value, int max) {
            if (max == 0) return self;
            return (self + value + max) % max;
        }

        /// <summary>
        /// 偶数かどうかを返します。
        /// </summary>
        public static bool IsEvenNum(this int self) {
            return self % 2 == 0;
        }

        /// <summary>
        /// 奇数かどうかを返します。
        /// </summary>
        public static bool IsOddNum(this int self) {
            return self % 2 == 1;
        }

        /// <summary>
        /// 値を範囲内に制限して返します。
        /// </summary>
        public static float Clamp(this int value, int min, int max) {
            return Mathf.Clamp(value, min, max);
        }
    }
}