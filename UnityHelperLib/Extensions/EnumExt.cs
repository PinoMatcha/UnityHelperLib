using System;
using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Enum型の拡張メソッド
    /// </summary>
    public static class EnumExt {

        /// <summary>
        /// 前の値を返します。最小値を超える場合は止まります。
        /// </summary>
        public static Enum Prev<Enum>(this Enum self) {
            int intValue = Convert.ToInt32(self);
            int nextValue = Mathf.Max(0, intValue - 1);
            Enum enumValue = EnumUtils.ToObject<Enum>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 次の値を返します。最大値を超える場合は止まります。
        /// </summary>
        public static Enum Next<Enum>(this Enum self) {
            int intValue = Convert.ToInt32(self);
            int nextValue = Mathf.Min(EnumUtils.GetLength<Enum>(), intValue + 1);
            Enum enumValue = EnumUtils.ToObject<Enum>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 前の値を返します。最小値を超える場合は最大値に戻ります。
        /// </summary>
        public static Enum PrevLoop<Enum>(this Enum self) {
            int intValue = Convert.ToInt32(self);
            int length = EnumUtils.GetLength<Enum>();
            int nextValue = (intValue - 1 + length) % length;
            Enum enumValue = EnumUtils.ToObject<Enum>(nextValue);

            return enumValue;
        }

        /// <summary>
        /// 次の値を返します。最大値を超える場合は初期値に戻ります。
        /// </summary>
        public static Enum NextLoop<Enum>(this Enum self) {
            int intValue = Convert.ToInt32(self);
            int length = EnumUtils.GetLength<Enum>();
            int nextValue = (intValue + 1) % length;
            Enum enumValue = EnumUtils.ToObject<Enum>(nextValue);

            return enumValue;
        }

        public static void Randomize<TEnum>(this TEnum self) {
            var temp = self;
            temp = EnumUtils.GetRandom<TEnum>();
            self = temp;
        }

    }
}