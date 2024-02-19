using System;
using System.Collections;
using System.Collections.Generic;

namespace PMP.UnityLib {
    /// <summary>
    /// Array型の拡張メソッド
    /// </summary>
    public static class ArrayExt {

        /// <summary>
        /// ランダムな要素を取得して返します
        /// </summary>
        public static T GetRandom<T>(this T[] self) {
            if (self.IsNullOrEmpty()) return default(T);

            int index = new System.Random().Next(self.Length);
            return self[index];
        }

        /// <summary>
        /// Arrayがnullまたは空のときtrueを返します
        /// </summary>
        public static bool IsNullOrEmpty<T>(this T[] self) {
            return !(self?.Length > 0);
        }

        public static void ForEach<T>(this T[] self, UnityEngine.Events.UnityAction unityAction) {
            if (self.IsNullOrEmpty()) return;

            self.Length.LoopAction(unityAction);
        }

        public static void ForEach<T>(this T[] self, UnityEngine.Events.UnityAction<int> unityAction) {
            if (self.IsNullOrEmpty()) return;

            self.Length.LoopAction(i => unityAction(i));
        }

        /// <summary>
        /// Arrayの要素をシャッフルします
        /// </summary>
        public static void Shuffle<T>(this T[] self) {
            if (self.IsNullOrEmpty()) return;

            var random = new System.Random();
            int n = self.Length;

            while (1 < n) {
                n--;
                int k = random.Next(n + 1);
                var tmp = self[k];
                self[k] = self[n];
                self[n] = tmp;
            }
        }

        /// <summary>
        /// Array全体の要素の並び順を反転させます
        /// </summary>
        public static T[] Reverse<T>(this T[] self) {
            Array.Reverse(self);
            return self;
        }

        /// <summary>
        /// Array指定範囲内の要素の並び順を反転させます
        /// </summary>
        public static T[] Reverse<T>(this T[] self, int index, int length) {
            Array.Reverse(self, index, length);
            return self;
        }
    }
}