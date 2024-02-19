using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PMP.UnityLib {
    /// <summary>
    /// ToggleGroup型の拡張メソッド
    /// </summary>
    public static class ToggleGroupExt {

        private static System.Reflection.FieldInfo _toggleListMember;

        /// <summary>
        /// 全てのトグルを取得して返します
        /// </summary>
        public static IList<Toggle> GetAllToggles(this ToggleGroup self) {
            if (_toggleListMember == null) {
                _toggleListMember = typeof(ToggleGroup).GetField("m_Toggles", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (_toggleListMember == null)
                    throw new System.Exception("UnityEngine.UI.ToggleGroup source code must have changed in latest version and is no longer compatible with this version of code.");
            }
            return _toggleListMember.GetValue(self) as IList<Toggle>;
        }

        /// <summary>
        /// 全てのトグルの数を取得して返します
        /// </summary>
        public static int Count(this ToggleGroup self) {
            return GetAllToggles(self).Count;
        }

        /// <summary>
        /// トグルをインデックスで取得して返します
        /// </summary>
        public static Toggle Get(this ToggleGroup self, int index) {
            return GetAllToggles(self)[index];
        }

        /// <summary>
        /// 各トグルにコールバックを登録します
        /// </summary>
        public static void ResisterActionEachToggle(this ToggleGroup self, UnityAction<Toggle, bool> action) {
            foreach (var toggle in self.GetAllToggles()) {
                toggle.onValueChanged.AddListener((bool isOn) => action?.Invoke(toggle, isOn));
            }
        }
    }
}