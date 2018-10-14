using UnityEngine;
using System.Collections;
using System.ComponentModel;
using AssemblyCSharp;

public class RegionScript : MonoBehaviour
{
	
	[SerializeField] AreaSciprt areaPref;
	float width, height;
	[SerializeField] float margin;

	[SerializeField] GameModel gameModel;

	void Awake() {
		width = areaPref.Width;
		height = areaPref.Height;
		gameModel.PropertyChanged += CreateRegion;
	}

	void CreateRegion (object sender, PropertyChangedEventArgs args) {
		if (gameModel.Equals (sender) &&
			(args.PropertyName == "Game" || args.PropertyName == "Region")) {
			transform.DestroyAllChildren ();
			gameModel.ForeachArea(CreateArea);
		}
	}

	void CreateArea (Coordinate coord, Fertility fertility) {
		AreaSciprt area = Instantiate (areaPref,
			new Vector3 (coord.y * (width + margin), coord.x * (height + margin)),
			Quaternion.identity, this.transform);
		area.Fertility = fertility;
	}
}

