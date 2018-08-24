using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEditor;

public class GameScript : MonoBehaviour {

	public Game game = new Game ("demo", new Player[2], new List2D<Area> ());
}

[CustomPropertyDrawer(typeof(Game))]
public class GameDrawer : PropertyDrawer
{
	const int height = 16;
	
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		position.height = height;

		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);

		Game game = this.fieldInfo.GetValue (property.serializedObject.targetObject) as Game;

		GUI.enabled = false;

		EditorGUI.TextField (position, "ID", game.Id);
		position.y += height;
		EditorGUI.IntField (position, "Turns", game.Turns);
		position.y += height;
		EditorGUI.TextField (position, "Timing", game.Timing.ToString ());
		position.y += height;
		EditorGUI.TextField (position, "Region", game.Region.PrintOut ());
		position.y += height;
		EditorGUI.TextField (position, "Card States", game.CardStates.PrintOut ());
		position.y += height;

		GUI.enabled = true;

		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return height * 6;
	}
}
