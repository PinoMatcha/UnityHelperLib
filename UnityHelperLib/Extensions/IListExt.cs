using System;
using System.Collections.Generic;

namespace PMP.UnityLib {
    public static class IListExt {

        /// <summary>
        /// ランダムな要素を取得して返します。
        /// </summary>
        public static T GetRandom<T> (this IList<T> self) {
            int index = new System.Random().Next(self.Count);
            return self[index];
        }

        /// <summary>
        /// リストがnullまたは空のときtrueを返します。
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty<T> (this IList<T> self) {
            return self == null || self.Count == 0;
        }

        /// <summary>
        /// ランダムに並び替えた新しいリストを返します。
        /// </summary>
        public static List<T> Shuffle<T> (this IList<T> self) {
            int length = self.Count;
            List<T> result = new List<T>(self);

            var random = new Random();
            int n = length;
            while (1 < n) {
                n--;
                int k = random.Next(n + 1);
                var tmp = result[k];
                result[k] = result[n];
                result[n] = tmp;
            }

            return result;
        }
    }
}