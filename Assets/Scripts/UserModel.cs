using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEditor;

public class UserModel : MonoBehaviour
{
	// Static instance of GameModel which allows it to be accessed by any other script.
	public static UserModel instance = null;

	User user = new User ("000", "John Doe");
	[ReadOnly] public string id;
	public new string name;

	//Awake is always called before any Start functions
	void Awake()
	{
		// Check if instance already exists
		if (instance == null)
			// if not, set instance to this.
			instance = this;
		// If instance already exists and it's not this:
		else if (instance != this)
			// Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a UserModel.
			Destroy(gameObject);
	}

	[ContextMenu("Initialize")]
	void Initialize ()
	{
		user = new User ("000", "John Doe");
		Revert ();
	}

	[ContextMenu("Apply")]
	void Apply ()
	{
		user.Name = name;
		GUI.FocusControl (null);
	}

	[ContextMenu("Revert")]
	void Revert ()
	{
		if (user != null) {
			id = user.Id;
			name = user.Name;
		}
		GUI.FocusControl (null);
	}
}
