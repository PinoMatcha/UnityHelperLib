using System;
using System.Collections.Generic;

namespace PMP.UnityLib {
    /// <summary>
    /// List型の拡張メソッド
    /// </summary>
    public static class ListExt {

        /// <summary>
        /// ランダムな要素を取得して返します
        /// </summary>
        public static T GetRandom<T>(this List<T> self) {
            if (self.IsNullOrEmpty()) return default(T);

            int index = new System.Random().Next(self.Count);
            return self[index];
        }

        /// <summary>
        /// Listがnullまたは空のときtrueを返します
        /// </summary>
        public static bool IsNullOrEmpty<T>(this List<T> self) {
            return !(self?.Count > 0);
        }

        /// <summary>
        /// Listの要素をシャッフルします
        /// </summary>
        public static void Shuffle<T>(this List<T> self) {
            if (self.IsNullOrEmpty()) return;

            var random = new System.Random();
            int n = self.Count;

            while (1 < n) {
                n--;
                int k = random.Next(n + 1);
                var tmp = self[k];
                self[k] = self[n];
                self[n] = tmp;
            }
        }
    }
}