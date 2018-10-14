using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEditor;
using System.ComponentModel;

public class GameScript : MonoBehaviour{

	public int turns;
	public Timing timing;

	[SerializeField] GameModel gameModel;

	public void Awake() {
		gameModel.PropertyChanged += this.GameUpdate;
	}

	protected void GameUpdate (object sender, PropertyChangedEventArgs propertyName) {
		switch (propertyName.PropertyName) {
		case "Turns":
			turns = gameModel.Turns;
			break;
		case "Timing":
			timing = gameModel.Timing;
			break;
		}
	}
}

