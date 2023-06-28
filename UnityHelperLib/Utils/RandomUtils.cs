using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PMP.UnityLib {
    public static class RandomUtils {

        /// <summary>
        /// 0.0 から 1.0 をランダムに返します。
        /// </summary>
        public static float Value01 { get { return UnityEngine.Random.value; } }

        /// <summary>
        /// -1.0 から 1.0 をランダムに返します。
        /// </summary>
        public static float Value { get { return Value01 - 0.5f * 2; } }

        /// <summary>
        /// true か false をランダムに返します。
        /// </summary>
        public static bool Flag { get { return UnityEngine.Random.Range(0, 2) == 0; } }
    }

}