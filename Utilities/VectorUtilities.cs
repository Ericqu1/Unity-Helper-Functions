namespace Utilities
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
	}
}