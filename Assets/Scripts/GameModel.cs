using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.ComponentModel;
using System;
using System.Collections.Generic;

public delegate void AreaCallback (Coordinate coord, Fertility fertility);

public interface IGameModel {
	void ForeachArea (AreaCallback callback);
}

/// <summary>
/// GameModel publishes game data.
/// Other script can subscribe it and fetch game data.
/// 
/// </summary>
public class GameModel : MonoBehaviour, INotifyPropertyChanged, IGameModel
{
	Game game;

	[ReadOnly][SerializeField] string id;
	[ReadOnly][SerializeField] string[] players;
	[ReadOnly][SerializeField] int turns;
	[ReadOnly][SerializeField] Timing timing;
	[SerializeField] string regionType = "standard";
	[ReadOnly][SerializeField] string[] region;
	[ReadOnly][SerializeField] string[] cardStates;

	[SerializeField] UserModel userModel;
	Player player;

	public string Id {
		get {
			this.id = game.Id;
			return this.id;
		}
	}

	public string[] Players {
		get {
			this.players = game.Players.ToStrings ();
			return this.players;
		}
	}

	public int Turns {
		get {
			this.turns = game.Turns;
			return this.turns;
		}
	}

	public Timing Timing {
		get {
			this.timing = game.Timing;
			return this.timing;
		}
	}

	public string[] Region {
		get {
			this.region = game.Region.ToStrings ();
			return this.region;
		}
	}

	public string[] CardStates {
		get {
			this.cardStates = game.CardStates.ToStrings ();
			return this.cardStates;
		}
	}

	public Player Player {
		get {
			if (player == null && game != null && game.Players != null && userModel != null) {
				player = game.FindPlayer (userModel.Id);
			}
			return this.player;
		}
	}

	protected void Awake() {
		Initialize ();
	}

	void UserUpdate (object sender, PropertyChangedEventArgs propertyName) {
		switch (propertyName.PropertyName) {
		case "User":
		case "Name":
			Player.Name = userModel.Name;
			OnPropertyChanged ("Players");
			break;
		}
	}

	[ContextMenu("Initialize")]
	void Initialize ()
	{
		Player player0 = new Player ("000", "John Doe", "A", new List<Card> ());
		Player player1 = new Player ("001", "Jane Roe", "B", new List<Card> ());
		game = new Game ("demo", new Player[]{ player0, player1 }, regionType);
		PropertyChanged += Revert;
		OnPropertyChanged ("Game");
		userModel.PropertyChanged += UserUpdate;
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
		case "Game":
			Revert ();
			break;
		case "Id":
			id = game.Id;
			break;
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

	#region IGameModel implementation

	public void ForeachArea (AreaCallback callback)
	{
		foreach (KeyValuePair<Coordinate, Area> pair in game.Region) {
			callback (pair.Key, pair.Value.Fertility);
		}
	}

	#endregion
}

