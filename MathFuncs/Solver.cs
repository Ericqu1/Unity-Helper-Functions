namespace MathFuncs
{
	using UnityEngine;

	public class Solver
	{
		public static float[] QuadraticFormula(float a, float b, float c)
		{
			float[] roots = new float[2];

			float determinant = Mathf.Pow (b, 2) - 4 * a * c;
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
}