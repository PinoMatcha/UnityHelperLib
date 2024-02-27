using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace PMP.UnityLib {
    /// <summary>
    /// 遅延処理クラス
    /// </summary>
    public class DelayedCall {
        /// <summary>
        /// delay 秒後に action を実行します。
        /// </summary>
        public static void Run(float delay, UnityAction action) {
            Task.Run(async () => {
                await Task.Delay(TimeSpan.FromSeconds(delay));
                action?.Invoke();
            });
        }
    }
}
