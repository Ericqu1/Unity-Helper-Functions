namespace Utilities.Resources
{
	using UnityEngine;

	public static class ResourcesUtilities
	{
		public static string StreamingAssetsFilePath(string fileName)
		{
			#if UNITY_ANDROID && !UNITY_EDITOR
			return "jar:file://" + Application.dataPath + "!/assets/" + fileName;
			#else
			return System.IO.Path.Combine (Application.streamingAssetsPath, fileName);
			#endif
		}
	}
}
