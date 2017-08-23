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
			"Gameplay",
			"_Dynamic"
		};
		for (int i = 0; i < BasicSceneStructure.Length; i++)
			TryInstantiate (BasicSceneStructure [i], i);
	}

	static void TryInstantiate(string newGO, int siblingIndex)
	{
		Scene scene = SceneManager.GetActiveScene();
		var existingGOs = new List<GameObject>();
		scene.GetRootGameObjects(existingGOs);

		foreach (GameObject GO in existingGOs)
			if (GO.name == newGO)
				return;

		GameObject createdGO = new GameObject (newGO);
		createdGO.transform.SetSiblingIndex (siblingIndex);
	}
}
