namespace Utilities.Color
{
	using UnityEngine;

	public static class ColorUtilities
	{
		public static Color ChangeTransparency(this Color color, float alpha)
		{
			return new Color (color.r, color.g, color.b, alpha);
		}
	}
}
