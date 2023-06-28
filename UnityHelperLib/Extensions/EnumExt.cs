using System;

namespace PMP.UnityLib {
    public static class EnumExt {

        /// <summary>
        /// int型からEnum型へ変換します。
        /// </summary>
        public static TEnum TryParse<TEnum> (int value) {
            if (Enum.IsDefined(typeof(TEnum), value)) {
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            } else {
                throw new ArgumentException($"'{value}' is not found.");
            }
        }

    }
}