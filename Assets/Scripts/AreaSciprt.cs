using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class AreaSciprt : MonoBehaviour
{

	[SerializeField] new Renderer renderer;
	[SerializeField] TextMesh fertility;
	[SerializeField] Transform cards;

	public float Width {
		get {
			return this.renderer.bounds.size.x;
		}
	}

	public float Height {
		get {
			return this.renderer.bounds.size.y;
		}
	}

	public Fertility Fertility {
		get {
			return (Fertility) Int32.Parse (fertility.text);
		}
		set {
			if (value == Fertility.Hollow)
				gameObject.SetActive (false);
			fertility.text = ((int)value).ToString ();
		}
	}
}
