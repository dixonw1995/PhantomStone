using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEditor;
using System.ComponentModel;
using System;

/// <summary>
/// UserModel publishes user data.
/// Other script can subscribe it and fetch user data.
/// 
/// </summary>
public class UserModel : MonoBehaviour, INotifyPropertyChanged
{
	User user = new User ("000", "John Doe");

	[ReadOnly][SerializeField] string id;
	[SerializeField] new string name;
	[SerializeField] GameModel gameModel;

	public string Id {
		get {
			this.id = user.Id;
			return this.id;
		}
	}

	public string Name {
		get {
			this.name = user.Name;
			return this.name;
		}
		set {
			name = value;
		}
	}

	protected void Awake() {
		Initialize ();
	}

	[ContextMenu("Initialize")]
	void Initialize ()
	{
		user = new User ("000", "John Doe");
		PropertyChanged += Revert;
		OnPropertyChanged ("User");
	}

	[ContextMenu("Apply")]
	void Apply ()
	{
		user.Name = name;
		OnPropertyChanged ("Name");
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

	void Revert (object sender, PropertyChangedEventArgs propertyName)
	{
		switch (propertyName.PropertyName) {
		case "User":
			Revert ();
			break;
		case "Id":
			id = user.Id;
			break;
		case "Name":
			name = user.Name;
			break;
		}
	}

	#region INotifyPropertyChanged implementation

	private event PropertyChangedEventHandler propertyChanged;

	private object eventLock = new object ();

	public event PropertyChangedEventHandler PropertyChanged {
		add {
			lock (eventLock) {
				propertyChanged -= value;
				propertyChanged += value;
			}
		}
		remove {
			lock (eventLock) {
				propertyChanged -= value;
			}
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChangedEventHandler handler = propertyChanged;
		if (handler != null)
			handler (this, new PropertyChangedEventArgs (propertyName));
	}

	#endregion
}
