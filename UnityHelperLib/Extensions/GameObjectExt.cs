using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PMP.UnityLib {
    public static class GameObjectExt {

        /// <summary>
        /// 子オブジェクトを持っているかを返します。
        /// </summary>
        /// <returns>bool</returns>
        public static bool HasChild (this GameObject self) {
            return self.transform.childCount > 0;
        }

        /// <summary>
        /// すべての子オブジェクトを返します。
        /// 子オブジェクトがない場合はnullを返します。
        /// </summary>
        /// <returns>GameObject[]</returns>
        public static GameObject[] GetAllChildren (this GameObject self, bool includeInactive = false) {
            return self
                .GetComponentsInChildren<Transform>(includeInactive)
                .Where(c => c != self.transform)
                .Select(c => c.gameObject)
                .ToArray();
        }
    }
}