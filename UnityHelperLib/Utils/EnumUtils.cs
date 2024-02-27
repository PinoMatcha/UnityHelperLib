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
        /// 指定された文字列を列挙型に変換して成功したかどうかを返します。
        /// </summary>
        /// <typeparam name="TEnum">列挙型</typeparam>
        /// <param name="value">変換する文字列</param>
        /// <param name="result">列挙型のオブジェクト</param>
        /// <returns>正常に変換された場合は true</returns>
        public static bool TryParse<TEnum>(string value, out TEnum result) {
            return TryParse<TEnum>(value, true, out result);
        }

        /// <summary>
        /// 指定された文字列を列挙型に変換して成功したかどうかを返します。
        /// </summary>
        /// <typeparam name="T">列挙型</typeparam>
        /// <param name="value">変換する文字列</param>
        /// <param name="ignoreCase">大文字と小文字を区別しない場合は true</param>
        /// <param name="result">列挙型のオブジェクト</param>
        /// <returns>正常に変換された場合は true</returns>
        public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) {
            try {
                result = (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
                return true;
            } catch {
                result = default(TEnum);
                return false;
            }
        }

        /// <summary>
        /// ランダムに値を返します。
        /// </summary>
        public static TEnum GetRandom<TEnum>() {
            var random = new Random();
            return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .OrderBy(c => random.Next())
            .FirstOrDefault();
        }

        /// <summary>
        /// Enum型の値の数を返します。
        /// </summary>
        public static int GetLength<TEnum>() {
            return Enum.GetValues(typeof(TEnum)).Length;
        }

        /// <summary>
        /// 指定された整数値を列挙メンバーに変換して返します。
        /// </summary>
        public static TEnum ToObject<TEnum>(int value) {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }

    }
}