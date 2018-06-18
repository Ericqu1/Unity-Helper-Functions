namespace Utilities.Vector
{
	using UnityEngine;

	public static class Vector2Utilities
	{
		public static Vector2 SmoothStep(Vector2 a, Vector2 b, float t)
		{
			return new Vector2(
				Mathf.SmoothStep(a.x, b.x, t),
				Mathf.SmoothStep(a.y, b.y, t));
		}
	}

	public static class Vector3Utilities
	{
		public static Vector3 SmoothStep(Vector3 a, Vector3 b, float t)
		{
			return new Vector3(
				Mathf.SmoothStep(a.x, b.x, t), 
				Mathf.SmoothStep(a.y, b.y, t), 
				Mathf.SmoothStep(a.z, b.z, t));
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
