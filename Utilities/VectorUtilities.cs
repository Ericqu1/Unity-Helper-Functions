namespace Utilities.Vector
{
	using UnityEngine;

	public static class Vector2Utilities
	{
        /// <summary>
        /// Similar functionality as Mathf.SmoothStep but for Vector2
        /// </summary>
		public static Vector2 SmoothStep(Vector2 a, Vector2 b, float t)
		{
			return new Vector2(
				Mathf.SmoothStep(a.x, b.x, t),
				Mathf.SmoothStep(a.y, b.y, t));
		}

        /// <summary>
        /// Similar functionality as Mathf.InverseLerp but for Vector2. This ignores the components of the vector not along AB
        /// </summary>
        public static float InverseLerp(Vector2 a, Vector2 b, Vector2 value)
        {
            Vector2 AB = b - a;
            Vector2 AV = value - a;
            return Mathf.Clamp01(Vector2.Dot(AV, AB) / Vector2.Dot(AB, AB));
        }
    }

	public static class Vector3Utilities
	{
        /// <summary>
        /// Similar functionality as Mathf.SmoothStep but for Vector3
        /// </summary>
		public static Vector3 SmoothStep(Vector3 a, Vector3 b, float t)
		{
			return new Vector3(
				Mathf.SmoothStep(a.x, b.x, t), 
				Mathf.SmoothStep(a.y, b.y, t), 
				Mathf.SmoothStep(a.z, b.z, t));
		}

        /// <summary>
        /// Similar functionality as Mathf.InverseLerp but for Vector3. This ignores the components of the vector not along AB
        /// </summary>
        public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
        {
            Vector3 AB = b - a;
            Vector3 AV = value - a;
            return Mathf.Clamp01(Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB));
        }

        /// <summary>
        /// Compares two floating point Vector3s and returns true if they are similar
        /// </summary>
        public static bool Approximately(this Vector3 a, Vector3 b)
        {
            if (Mathf.Approximately(a.x, b.x) &&
                Mathf.Approximately(a.y, b.y) &&
                Mathf.Approximately(a.z, b.z))
                return true;
            else
                return false;
        }
	}
}