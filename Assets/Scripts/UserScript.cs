using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEditor;

public class UserScript : MonoBehaviour, IApplyChange
{
	User user = new User ("000", "John Doe");
	[ReadOnly] public string id;
	public new string name;

	#region IApplyChange implementation

	[ContextMenu("Initialize")]
	void IApplyChange.Initialize ()
	{
		user = new User ("000", "John Doe");
		((IApplyChange)this).Revert ();
	}

	[ContextMenu("Apply")]
	void IApplyChange.Apply ()
	{
		user.Name = name;
		GUI.FocusControl (null);
	}

	[ContextMenu("Revert")]
	void IApplyChange.Revert ()
	{
		if (user != null) {
			id = user.Id;
			name = user.Name;
		}
		GUI.FocusControl (null);
	}

	#endregion
}
