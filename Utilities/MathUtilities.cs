namespace Utilities.Math
{
	using UnityEngine;

	public static class MathUtilities
	{
		public static float[] QuadraticFormula(float a, float b, float c)
		{
			float[] roots = new float[2];

			float determinant = Mathf.Pow (b, 2) - 4f * a * c;

			if (determinant < 0)
			{
				roots [0] = roots [1] = float.NaN;
				Debug.Log("Most recent call of QuadraticFormula produced imaginary roots! Assigning null values to return roots.");
			}
			else
			{
				roots [0] = (-b + Mathf.Sqrt (determinant)) / (2 * a);
				roots [1] = (-b - Mathf.Sqrt (determinant)) / (2 * a);
			}
			return roots;
		}
	}

	public static class RNG
	{
		public static float GaussianRange(float min, float max)
		{
			float u, v, S;

			do
			{
				u = 2.0f * Random.value - 1.0f;
				v = 2.0f * Random.value - 1.0f;
				S = u * u + v * v;
			}
			while (S >= 1.0);

			float fac = Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
			float mean = (min + max) / 2f;
			float sigma = (max - mean) / 3f;
			return (u * fac) * sigma + mean;
		}
	}
}