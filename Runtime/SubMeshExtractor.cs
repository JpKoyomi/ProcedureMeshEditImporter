using System;
using UnityEngine;

namespace KLabs.MeshEdit
{
    public static class SubMeshExtractor
    {
        public static Mesh Extract(Mesh src, int index)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }
            if (index >= src.subMeshCount || index < 0)
            {
                throw new ArgumentException(nameof(index));
            }
            var dst = UnityEngine.Object.Instantiate(src);

            var subMesh = dst.GetSubMesh(index);
            var triangles = new Span<int>(dst.triangles, subMesh.indexStart, subMesh.indexCount).ToArray();
            dst.subMeshCount = 0;
            dst.triangles = triangles;
            return dst;
        }

        public static Mesh ExtractSubMesh(this Mesh src, int index)
        {
            return Extract(src, index);
        }
    }
}
