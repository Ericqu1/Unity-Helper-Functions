namespace VRTK.Utilities
{
	using System.Collections;
	using UnityEngine;
	using VRTK;

	public class AttachTransformToHMD : MonoBehaviour 
	{
		[SerializeField]
		private bool saveLocalTransform = false;

		private MonoBehaviour[] attachedComponents;

		IEnumerator Start () 
		{
			attachedComponents = GetComponents (typeof(MonoBehaviour)) as MonoBehaviour[];
			ToggleOtherComponents (false);

			float timeout = 0f;

			while (VRTK_DeviceFinder.HeadsetTransform() == null)
			{
				timeout += Time.deltaTime;
				if (timeout > 2)
				{
					Debug.LogWarning ("Timeout: VRTK_DeviceFinder could not find HeadsetTransform, fail to attach " + gameObject.name + " to HMD.");
					yield break;
				}
				yield return new WaitForEndOfFrame ();
			}

			transform.SetParent (VRTK_DeviceFinder.HeadsetTransform (), !saveLocalTransform);
			ToggleOtherComponents (true);
		}

		void ToggleOtherComponents(bool state)
		{
			if (attachedComponents != null)
				foreach (MonoBehaviour comp in attachedComponents)
					if (comp != this)
						comp.enabled = state;
		}
	}
}
