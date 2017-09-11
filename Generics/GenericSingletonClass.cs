namespace Generics
{
	using System;
	using UnityEngine;

	public abstract class GenericSingletonClass<T> : MonoBehaviour where T : Component
	{
		private static T _instance;
		public static T instance 
		{
			get {
				if (_instance == null) 
				{
					_instance = FindObjectOfType<T> ();
					if (_instance == null && !applicationIsQuitting) 
					{
						GameObject obj = new GameObject ();
						obj.name = typeof(T).Name;
						_instance = obj.AddComponent<T> ();
					}
				}
				return _instance;
			}
		}

		private static bool applicationIsQuitting = false;

		public virtual void Awake ()
		{
			if (_instance == null || gameObject == this.gameObject) 
			{
				_instance = this as T;
				//DontDestroyOnLoad (this.gameObject);
			} else 
			{
				Destroy (gameObject);
			}
		}

		protected virtual void OnApplicationQuit()
		{
			applicationIsQuitting = true;
		}
	}
}