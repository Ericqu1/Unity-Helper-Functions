namespace TransformUtilities
{
	using UnityEngine;

	public static class TransformUtilities
	{
		public static Vector3 TotalScale(this Transform t)
		{
			Vector3 parentScale = (t.parent) ? t.parent.TotalScale () : Vector3.one;
			return Vector3.Scale(t.localScale, parentScale);
		}

		//Breadth-first search
		public static Transform FindDeepChild(this Transform aParent, string aName)
		{
			var result = aParent.Find(aName);
			if (result != null)
				return result;
			foreach(Transform child in aParent)
			{
				result = child.FindDeepChild(aName);
				if (result != null)
					return result;
			}
			return null;
		}
	}
}