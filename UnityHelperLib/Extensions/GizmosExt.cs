using System;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;



#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PMP.UnityLib {
    /// <summary>
    /// Gizmos型、Handles型の拡張メソッド
    /// </summary>
    public static class GizmosExt {
#if UNITY_EDITOR

        private static void DrawCircleCross(Vector2 center, float radius, float thickness = 0.0f) {
            var top = center + (Vector2.up * radius);
            Handles.DrawLine(top, top + (Vector2.down * radius * 2), thickness);
            var left = center + (Vector2.left * radius);
            Handles.DrawLine(left, left + (Vector2.right * radius * 2), thickness);
        }

        public static void DrawHitPointAndNormal(Vector2 point, Vector2 normal) {
            if (normal == Vector2.zero) return;

            var tempColor = Handles.color;
            Handles.color = Color.red;
            DrawSolidCircleWithOutline(point, 0.05f, faceColor: Handles.color.SetAlphaAsNew(0.25f));
            Handles.DrawLine(point, point + (normal * 0.5f), 1.0f);
            Handles.color = tempColor;
        }

        private static void DrawLine(bool hit, Vector3 start, Vector3 end, Vector3 hitPoint, Vector3 hitNormal, float thickness = 0.0f, bool displayHitInfo = true) {
            if (hit) {
                Handles.color = Color.green;
                Handles.DrawLine(start, hitPoint, thickness);
                Handles.color = Color.white;
                Handles.DrawLine(hitPoint, end, thickness);

                if (displayHitInfo) DrawHitPointAndNormal(hitPoint, hitNormal);
            } else {
                Handles.color = Color.red;

                Handles.DrawLine(start, end, thickness);
            }
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用して塗りつぶし+アウトラインの円を表示します
        /// </summary>
        public static void DrawSolidCircleWithOutline(Vector2 center, float radius, float thickness = 0.0f, Color faceColor = default(Color), Color outlineColor = default(Color)) {
            var tempColor = Handles.color;

            // Draw solid disc
            Handles.color = faceColor != default ? faceColor : tempColor;
            Handles.DrawSolidDisc(center, Vector3.forward, radius);

            // Draw wire dics
            Handles.color = outlineColor != default ? outlineColor : tempColor;
            Handles.DrawWireDisc(center, Vector3.forward, radius, thickness);

            Handles.color = tempColor;
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用して、クロス付きの円を表示します
        /// </summary>
        public static void DrawCrossedWireCircle(Vector2 center, float radius, float thickness = 0.0f) {
            Handles.DrawWireDisc(center, Vector3.forward, radius, thickness);
            DrawCircleCross(center, radius, thickness);
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用して、塗りつぶし+クロス+アウトラインの円を表示します
        /// </summary>
        public static void DrawSolidCircleWithCrossedOutline(Vector2 center, float radius, float thickness = 0.0f, Color faceColor = default(Color), Color outlineColor = default(Color)) {
            var tempColor = Handles.color;

            // DrawSolidCircleWithOutline
            DrawSolidCircleWithOutline(center, radius, thickness, faceColor, outlineColor);

            // Draw cross
            DrawCircleCross(center, radius, thickness);

            Handles.color = tempColor;
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用してPhysics2D.CircleCast()を可視化します
        /// </summary>
        public static void DrawCircleCast(RaycastHit2D hitInfo, Vector2 origin, float radius, Vector2 direction, float distance = Mathf.Infinity, float thickness = 0.0f, bool displayHitInfo = true) {
            var tempColor = Handles.color;

            Handles.color = Color.white;

            if (direction.magnitude > 0 && direction.magnitude != 1) direction.Normalize();

            Vector2 fullCastEndPoint = origin + (direction * distance);

            Vector2 castEndPoint = origin + (direction * distance);

            if (hitInfo.collider) {
                DrawCrossedWireCircle(fullCastEndPoint, radius, thickness);

                distance = hitInfo.distance;
                castEndPoint = origin + (direction * distance);

                Handles.DrawLine(castEndPoint + (direction * radius), fullCastEndPoint, thickness);

                if (displayHitInfo) DrawHitPointAndNormal(hitInfo.point, hitInfo.normal);

                Handles.color = Color.green;
            } else {
                Handles.color = Color.red;
            }

            Handles.DrawLine(origin, castEndPoint, thickness);
            DrawSolidCircleWithCrossedOutline(castEndPoint, radius, thickness, faceColor: Handles.color.SetAlphaAsNew(0.1f));

            Handles.color = tempColor;
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用してPhysics2D.Raycast()を可視化します
        /// </summary>
        public static void DrawRaycast(RaycastHit2D hitInfo, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity, float thickness = 0.0f, bool displayHitInfo = true) {
            var tempColor = Handles.color;

            Handles.color = Color.white;

            DrawSolidCircleWithOutline(origin, 0.025f, thickness, faceColor: Handles.color.SetAlphaAsNew(0.25f));

            var end = origin + (direction * distance);

            DrawLine(hitInfo, origin, end, hitInfo.point, hitInfo.normal, thickness, displayHitInfo);

            Handles.color = tempColor;
        }

        /// <summary>
        /// UnityEditor.Handlesクラスを使用してPhysics2D.Linecast()を可視化します
        /// </summary>
        public static void DrawLinecast(RaycastHit2D hitInfo, Vector2 start, Vector2 end, float thickness = 0.0f, bool displayHitInfo = true) {
            var tempColor = Handles.color;

            Handles.color = Color.white;

            DrawSolidCircleWithOutline(start, 0.025f, thickness, faceColor: Handles.color.SetAlphaAsNew(0.25f));
            DrawSolidCircleWithOutline(end, 0.025f, thickness, faceColor: Handles.color.SetAlphaAsNew(0.25f));

            DrawLine(hitInfo, start, end, hitInfo.point, hitInfo.normal, thickness, displayHitInfo);

            Handles.color = tempColor;
        }

        public static void DrawOverlapCircle(Collider2D hit, Vector2 point, float radius) {
            DrawOverlapCircle(hit, point, radius);
        }
        
        public static void DrawOverlapCircle(Collider2D[] hits, Vector2 point, float radius) {
            DrawOverlapCircle((bool)!hits.IsNullOrEmpty(), point, radius);
        }

        private static void DrawOverlapCircle(bool hit, Vector2 point, float radius) {
            var tempColor = Handles.color;

            Color color;
            if (hit) {
                color = Color.green;
            } else {
                color = Color.red;
            }

            DrawSolidCircleWithOutline(point, radius, 2.0f, color.SetAlphaAsNew(0.25f), color);

            Handles.color = tempColor;
        }

        public static void DrawOverlapBox(Collider2D hit, Vector2 center, Vector2 size, float angle) {
            DrawOverlapBox((bool)hit, center, size, angle);
        }

        public static void DrawOverlapBox(Collider2D[] hits, Vector2 center, Vector2 size, float angle) {
            DrawOverlapBox((bool)!hits.IsNullOrEmpty(), center, size, angle);
        }

        private static void DrawOverlapBox(bool hit, Vector2 center, Vector2 size, float angle) {
            var tempColor = Handles.color;

            float w = size.x * 0.5f;
            float h = size.y * 0.5f;
            Quaternion q = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

            var verts = new Vector3[4] {
                new Vector3(-w, h, 0),
                new Vector3(w, h, 0),
                new Vector3(w, -h, 0),
                new Vector3(-w, -h, 0),
            };

            for (int i = 0; i < 4; i++) {
                verts[i] = (Vector2)(q * verts[i]) + center;
            }

            Color color;
            if (hit) {
                color = Color.green;
            } else {
                color = Color.red;
            }

            Handles.DrawSolidRectangleWithOutline(verts, color.SetAlphaAsNew(0.25f), color);

            Handles.color = tempColor;
        }

        private static void DrawWireSphere(Vector3 center, float radius) {
            var camera = Camera.current;

            Handles.DrawWireDisc(center, Vector3.forward, radius);
            Handles.DrawWireDisc(center, Vector3.right, radius);
            Handles.DrawWireDisc(center, Vector3.up, radius);
            Handles.DrawWireDisc(center, camera.transform.position - center, radius);
        }

        public static void DrawWireSphere(Vector3 center, float radius, bool useZTest = false) {
            var tempColor = Handles.color;

            if (useZTest) Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            DrawWireSphere(center, radius);

            if (useZTest) Handles.zTest = UnityEngine.Rendering.CompareFunction.Greater;

            Handles.color = Handles.color.SetAlphaAsNew(0.1f);

            DrawWireSphere(center, radius);

            Handles.color = tempColor;
        }

        private static void DrawSphere(Vector3 center, float radius) {
            Handles.SphereHandleCap(0, center, Quaternion.identity, radius * 2, EventType.Repaint);
        }

        public static void DrawSphere(Vector3 center, float radius, bool useZTest = false) {
            var tempColor = Handles.color;

            if (useZTest) Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            DrawSphere(center, radius);

            if (useZTest) Handles.zTest = UnityEngine.Rendering.CompareFunction.Greater;

            Handles.color = Handles.color.SetAlphaAsNew(0.1f);

            DrawSphere(center, radius);

            Handles.color = tempColor;
        }
#endif
    }
}