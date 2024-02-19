using UnityEngine;

namespace PMP.UnityLib {
    /// <summary>
    /// float型の拡張メソッド
    /// </summary>
    public static class FloatExt {

        /// <summary>
        /// 四捨五入して整数で返します
        /// Round off.
        /// </summary>
        public static int RoundOff (this float self) {
            float dec = self - Mathf.FloorToInt(self);   // 整数部分を削除
            int intege = Mathf.FloorToInt(dec * 10);   // 小数第一位部分

            // 小数第一位部分が5以上なら切り上げ、以下なら切り捨て
            if (intege >= 5)
                return Mathf.CeilToInt(self);
            else
                return Mathf.FloorToInt(self);
        }

        /// <summary>
        /// 小数点第N位以下を切り捨てます
        /// </summary>
        public static float RoundDownToNDecimalPoint (this float self, int n) {
            int mul = (int)Mathf.Pow(10, n);
            float val = Mathf.FloorToInt(self * mul);
            return val / mul;
        }

        /// <summary>
        /// 小数点第N位以下を切り上げます
        /// </summary>
        public static float RoundUpToNDecimalPoint (this float self, int point) {
            int mul = (int)Mathf.Pow(10, point);
            float val = Mathf.CeilToInt(self * mul);
            return val / mul;
        }

        /// <summary>
        /// 小数点第N位以下を四捨五入します
        /// </summary>
        public static float RoundOffToNDecimalPoint (this float self, int n) {
            int mul = (int)Mathf.Pow(10, n);
            float val = (self * mul).RoundOff();
            return val / mul;
        }


        /// <summary>
        /// ターゲット値と等しいかどうかをしきい値で判断して返します
        /// </summary>
        public static bool SafeEquals (this float self, float obj, float threshold = 0.001f) {
            return Mathf.Abs(self - obj) <= threshold;
        }
        
        /// <summary>
        /// 値を指定した範囲内に制限して返します
        /// </summary>
        public static float Clamp(this float self, float min, float max) {
            return Mathf.Clamp(self, min, max);
        }

        /// <summary>
        /// 値をx～yの範囲内に制限して返します
        /// </summary>
        public static float Clamp(this float self, Vector2 minMax) {
            return Mathf.Clamp(self, minMax.x, minMax.y);
        }

        /// <summary>
        /// 値を０から１の範囲内に制限して返します
        /// </summary>
        public static float Clamp01(this float self) {
            return Mathf.Clamp01(self);
        }

        /// <summary>
        /// ０は０、０より大きければ１、小さければ-１を返します
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int Extremize(this float self) {
            if(Mathf.Approximately(self, 0.0f)) return 0;
            return self > 0 ? 1 : -1;
        }
    }
}