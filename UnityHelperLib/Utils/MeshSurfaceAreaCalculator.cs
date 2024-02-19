using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PMP.UnityLib {
    public static class MeshSurfaceAreaCalculator {

        /// <summary>
        /// メッシュの表面積を計算して返します
        /// </summary>
        public static float CalcSurfaceArea(Transform transform, Mesh mesh) {
            // メッシュがない場合は return
            if (!mesh) return -1;

            int[] meshTris = mesh.triangles;   // 三角ポリゴンの頂点配列
            Vector3[] meshVerts = mesh.vertices;   // 頂点のローカル座標配列
            int triangleCount = meshTris.Length / 3;   // 三角ポリゴン数

            // 上記の配列が空の場合は return
            if ((meshTris == null || meshTris.Length == 0) || (meshVerts == null || meshVerts.Length == 0) || (triangleCount == 0))
                return -1;

            // 頂点のワールド座標 二次元配列
            Vector3[,] vertsWS = new Vector3[triangleCount, 3];

            // 頂点のワールド座標を計算
            // i => n番目の三角ポリゴン
            // j => 三角ポリゴンの各頂点
            for (int i = 0; i < triangleCount; i++)
                for (int j = 0; j < 3; j++) vertsWS[i, j] = transform.TransformPoint(meshVerts[meshTris[j + (i * 3)]]);

            // 合計面積
            float result = 0;

            // 各ポリゴンの面積を計算 & 合計に加算
            for (int i = 0; i < triangleCount; i++) {
                // ３頂点
                Vector3 A = vertsWS[i, 0];
                Vector3 B = vertsWS[i, 1];
                Vector3 C = vertsWS[i, 2];

                // BベクトルとCベクトルの外積
                Vector3 D = Vector3.Cross(B - A, C - A);

                // 平行四辺形の面積 / 2
                float S = D.magnitude / 2;

                result += S;
            }

            return result;
        }
    }
}