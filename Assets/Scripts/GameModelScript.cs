﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.ComponentModel;
using System;
using System.Collections.Generic;

/// <summary>
/// Model publisher is the only script which store game data.
/// Other script can only subscribe it to fetch game data.
/// 
/// </summary>
public class GameModelScript : MonoBehaviour, INotifyPropertyChanged
{

	Game game;

	[ReadOnly] public string id;
	[ReadOnly] public string[] players;
	[ReadOnly] public int turns;
	[ReadOnly] public Timing timing;
	[ReadOnly] public string[] region;
	[ReadOnly] public string[] cardStates;

	[ContextMenu("Initialize")]
	void Initialize ()
	{
		Player player0 = new Player ("000", "John Doe", "A", new List<Card> ());
		Player player1 = new Player ("001", "Jane Roe", "B", new List<Card> ());
		game = new Game ("demo", new Player[]{ player0, player1 }, "standard");
		Revert ();
		PropertyChanged += Revert;
	}

	[ContextMenu("Revert")]
	void Revert ()
	{
		id = game.Id;
		players = game.Players.ToStrings ();
		turns = game.Turns;
		timing = game.Timing;
		region = game.Region.ToStrings ();
		cardStates = game.CardStates.ToStrings ();
	}

	void Revert (object sender, PropertyChangedEventArgs propertyName)
	{
		switch (propertyName.PropertyName) {
		case "Players":
			players = game.Players.ToStrings ();
			break;
		case "Turns":
			turns = game.Turns;
			break;
		case "Timing":
			timing = game.Timing;
			break;
		case "Region":
			region = game.Region.ToStrings ();
			break;
		case "CardStates":
			cardStates = game.CardStates.ToStrings ();
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

