namespace EditorExtension
{
	using UnityEditor;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using System.Collections.Generic;

	public class ProjectAndSceneCreationTools : MonoBehaviour
	{
		[MenuItem("Custom Tools/ProjectAndSceneCreationTools/CreateSceneStructure")]
		static void CreateSceneStructure()
		{
			string[] BasicSceneStructure = {
				"Debug",
				"Managers",
				"Cameras",
				"Lights",
				"UI",
				"World",
				"World/Structures",
				"World/Props",
				"Gameplay",
				"Gameplay/Items",
				"_Dynamic"
			};
			int nestedItemsNum = 0;
			for (int i = 0; i < BasicSceneStructure.Length; i++)
			{
				string GOname = BasicSceneStructure [i];
				if (GOname.Contains("/"))
				{
					nestedItemsNum++;
					int slashIndex = GOname.IndexOf ("/");
					TryInstantiate (GOname.Substring (slashIndex + 1, GOname.Length - (slashIndex + 1)), 0, GOname.Substring (0, slashIndex));
				}
				else
					TryInstantiate (GOname, i - nestedItemsNum);
			}
		}

		static void TryInstantiate(string newGO, int siblingIndex, string parentGO = null)
		{
			Scene scene = SceneManager.GetActiveScene();
			var existingGOs = new List<GameObject>();
			scene.GetRootGameObjects(existingGOs);

			GameObject existingParentGO = null;
			foreach (GameObject GO in existingGOs)
			{
				if (parentGO != null && GO.name == parentGO)
				{
					existingParentGO = GO;
					if (existingParentGO.transform.Find (newGO) != null)
						return;
				}
				if (GO.name == newGO)
					return;
			}
			if (GameObject.Find ("newGO") != null)
				return;
			 
			GameObject createdGO = new GameObject (newGO);
			if (existingParentGO != null)
				createdGO.transform.parent = existingParentGO.transform;
			else
				createdGO.transform.SetSiblingIndex (siblingIndex);
		}
	}
}