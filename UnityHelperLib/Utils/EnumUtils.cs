using System;
using System.Linq;

namespace PMP.UnityLib {
    /// <summary>
    /// Enumクラスの汎用関数
    /// </summary>
    public static class EnumUtils {

        /// <summary>
        /// int型からEnum型へ変換します。
        /// </summary>
        public static TEnum TryParse<TEnum>(int value) {
            if (Enum.IsDefined(typeof(TEnum), value)) {
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            } else {
                throw new ArgumentException($"'{value}' is not found.");
            }
        }

        /// <summary>
        /// ランダムに値を返します。
        /// </summary>
        public static T GetRandom<T>() {
            var random = new Random();
            return Enum.GetValues(typeof(T))
            .Cast<T>()
            .OrderBy(c => random.Next())
            .FirstOrDefault();
        }

        /// <summary>
        /// Enum型の値の数を返します。
        /// </summary>
        public static int GetLength<T>() {
            return Enum.GetValues(typeof(T)).Length;
        }

        /// <summary>
        /// 指定された整数値を列挙メンバーに変換して返します。
        /// </summary>
        public static T ToObject<T>(int value) {
            return (T)Enum.ToObject(typeof(T), value);
        }

    }
}