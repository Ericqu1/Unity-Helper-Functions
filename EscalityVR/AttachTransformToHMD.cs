namespace EscalityVR
{
	using System.Collections;
	using UnityEngine;
	using VRTK;

	public class AttachTransformToHMD : MonoBehaviour 
	{
		[SerializeField]
		private bool saveLocalTransform;

		private MonoBehaviour[] attachedComponents;

		IEnumerator Start () 
		{
			Vector3 savedLocalPosition = Vector3.zero;
			Quaternion savedLocalRotation = Quaternion.identity;
			if (saveLocalTransform)
			{
				savedLocalPosition = transform.localPosition;
				savedLocalRotation = transform.localRotation;
			}

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

				Debug.LogWarning (VRTK_DeviceFinder.HeadsetTransform ());
				yield return new WaitForEndOfFrame ();
			}

			transform.parent = VRTK_DeviceFinder.HeadsetTransform ();
			transform.localPosition = savedLocalPosition;
			transform.localRotation = savedLocalRotation;
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