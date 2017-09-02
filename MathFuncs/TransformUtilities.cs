namespace MathFuncs
{
	using UnityEngine;
	
	public static Vector3 TotalScale(this Transform t)
		{
			Vector3 parentScale = (t.parent) ? t.parent.TotalScale () : Vector3.one;
			return Vector3.Scale(t.localScale, parentScale);
		}
}