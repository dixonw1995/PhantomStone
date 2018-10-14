using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class TransformExtension
	{

		public static void DestroyAllChildren(this Transform parent) {
			foreach (Transform child in parent) {
				child.parent = null;
				GameObject.Destroy (child.gameObject);
			}
		}
	}
}

