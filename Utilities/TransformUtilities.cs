namespace Utilities.Transform
{
	using UnityEngine;
	using System.Collections.Generic;

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

		public static List<GameObject> FindObjectsWithTag(this Transform parent, string tag)
		{
			List<GameObject> taggedGameObjects = new List<GameObject>();

			for (int i = 0; i < parent.childCount; i++)
			{
				Transform child = parent.GetChild(i);
				if (child.tag == tag)
				{
					taggedGameObjects.Add(child.gameObject);
				}
				if (child.childCount > 0)
				{
					taggedGameObjects.AddRange(FindObjectsWithTag(child, tag));
				}
			}
			return taggedGameObjects;
		}
	}

	public struct SavedTransform
	{
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 localScale;

		public SavedTransform(Vector3 positionInput, Quaternion rotationInput, Vector3 localScaleInput)
		{
			position = positionInput;
			rotation = rotationInput;
			localScale = localScaleInput;
		}
	}
}
