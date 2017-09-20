namespace Generics
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class DynamicContainer : GenericSingletonClass<DynamicContainer> 
	{
		protected override void Awake ()
		{
			base.Awake ();
			gameObject.name = "_Dynamic";
		}
	}
}