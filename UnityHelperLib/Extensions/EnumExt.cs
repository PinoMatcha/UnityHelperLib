using System;
using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Enum型の拡張メソッド
    /// </summary>
    public static class EnumExt {

        /// <summary>
        /// 前の値に進みます。最小値を超える場合は止まります。
        /// </summary>
        public static T Prev<T>(this T self) {
            var intValue = Convert.ToInt32(self);
            var nextValue = Mathf.Max(0, intValue - 1);
            var enumValue = EnumUtils.ToObject<T>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 次の値に進みます。最大値を超える場合は止まります。
        /// </summary>
        public static T Next<T>(this T self) {
            var intValue = Convert.ToInt32(self);
            var nextValue = Mathf.Min(EnumUtils.GetLength<T>(), intValue + 1);
            var enumValue = EnumUtils.ToObject<T>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 前の値に進みます。最小値を超える場合は最大値に戻ります。
        /// </summary>
        public static T PrevLoop<T>(this T self) {
            var intValue = Convert.ToInt32(self);
            var length = EnumUtils.GetLength<T>();
            var nextValue = (intValue - 1 + length) % length;
            var enumValue = EnumUtils.ToObject<T>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 次の値に進みます。最大値を超える場合は初期値に戻ります。
        /// </summary>
        public static T NextLoop<T>(this T self) {
            var intValue = Convert.ToInt32(self);
            var nextValue = (intValue + 1) % EnumUtils.GetLength<T>();
            var enumValue = EnumUtils.ToObject<T>(nextValue);

            return enumValue;
        }

    }
}