namespace Utilities.Mesh
{
	using UnityEngine;

    public static class MeshUtilities
    {
        public static Vector3 GetBarycentric(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 p)
        {
            Vector3 B = new Vector3();
            B.x = ((v2.y - v3.y) * (p.x - v3.x) + (v3.x - v2.x) * (p.y - v3.y)) /
                ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
            B.y = ((v3.y - v1.y) * (p.x - v3.x) + (v1.x - v3.x) * (p.y - v3.y)) /
                ((v3.y - v1.y) * (v2.x - v3.x) + (v1.x - v3.x) * (v2.y - v3.y));
            B.z = 1 - B.x - B.y;
            return B;
        }

        public static bool InTriangle(Vector3 barycentric)
        {
            return (barycentric.x >= 0.0f) && (barycentric.x <= 1.0f)
                && (barycentric.y >= 0.0f) && (barycentric.y <= 1.0f)
                && (barycentric.z >= 0.0f); //(barycentric.z <= 1.0f)
        }

        public static bool InTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 p)
        {
            Vector3 barycentric = GetBarycentric(v1, v2, v3, p);
            return InTriangle(barycentric);
        }
    }
}
