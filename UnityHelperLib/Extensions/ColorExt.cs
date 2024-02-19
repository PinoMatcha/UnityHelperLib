using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// Color型の拡張メソッド
    /// </summary>
    public static class ColorExt {

        /// <summary>
        /// 指定したR値を代入して返します
        /// </summary>
        public static Color SetR(this Color baseColor, float newR) {
            baseColor.r = newR;
            return baseColor;
        }

        /// <summary>
        /// 指定したG値を代入して返します
        /// </summary>
        public static Color SetG(this Color baseColor, float newG) {
            baseColor.g = newG;
            return baseColor;
        }

        /// <summary>
        /// 指定したB値を代入して返します
        /// </summary>
        public static Color SetB(this Color baseColor, float newB) {
            baseColor.b = newB;
            return baseColor;
        }

        /// <summary>
        /// 元のカラーを基に、指定したR値でColorをnewして返します
        /// </summary>
        public static Color SetRAsNew(this Color baseColor, float newR) {
            var newColor = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a);
            newColor.r = newR;
            return newColor;
        }

        /// <summary>
        /// 元のカラーを基に、指定したG値でColorをnewして返します
        /// </summary>
        public static Color SetGAsNew(this Color baseColor, float newG) {
            var newColor = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a);
            newColor.g = newG;
            return newColor;
        }

        /// <summary>
        /// 元のカラーを基に、指定したB値でColorをnewして返します
        /// </summary>
        public static Color SetBAsNew(this Color baseColor, float newB) {
            var newColor = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a);
            newColor.b = newB;
            return newColor;
        }

        /// <summary>
        /// 指定したRGB値を代入して返します
        /// </summary>
        public static Color SetRGB(this Color baseColor, float newR, float newG, float newB) {
            baseColor.r = newR;
            baseColor.g = newG;
            baseColor.b = newB;
            return baseColor;
        }

        /// <summary>
        /// 元のカラーを基に、指定したRGB値でColorをnewして返します
        /// </summary>
        public static Color SetRGBAsNew(this Color baseColor, float newR, float newG, float newB) {
            var newColor = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a);
            newColor.r = newR;
            newColor.g = newG;
            newColor.b = newB;
            return newColor;
        }

        /// <summary>
        /// 指定したアルファ値を代入して返します
        /// </summary>
        public static Color SetAlpha(this Color baseColor, float newAlpha) {
            baseColor.a = newAlpha;
            return baseColor;
        }

        /// <summary>
        /// 元のカラーを基に、指定したアルファ値でColorをnewして返します
        /// </summary>
        public static Color SetAlphaAsNew(this Color baseColor, float newAlpha) {
            return new Color(baseColor.r, baseColor.g, baseColor.b, newAlpha);
        }

    }
}